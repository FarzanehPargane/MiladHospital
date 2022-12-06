using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiladHospital.Models.Reservation;
using MiladHospital.Services.Interfaces;
using static MiladHospital.Models.ViewModels.AppointmentReservationViewModel;

namespace MiladHospital.Pages.Reservation
{
    public class AppointmentReservationModel : PageModel
    {
        IAppointmentService _appointmentService;
        public AppointmentReservationModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty]
        public AppointmentReservation appointmentReservation { get; set; }
        public ReservationTrackingCodeViewModel ReservationTrackingCodeViewModel { get; set; }
        public void OnGet()
        {
            //appointmentReservation = new AppointmentReservation();
        }
        public IActionResult OnPost(int AppointmentId)
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                appointmentReservation.AppointmentId = AppointmentId;
              Task<int> result= _appointmentService.AddAppointmentReservation(appointmentReservation);
                if (result.Result != -1)
                {
                    if (result.Result == -2)
                    {
                        ViewData["Capacity"] = true;
                    }
                    else
                      if (result.Result == -3)
                    {
                        ReservationTrackingCodeViewModel = _appointmentService.GetAppointmentReservationByMellicode(AppointmentId,appointmentReservation.Mellicode);
                        ViewData["Appointment"] = ReservationTrackingCodeViewModel.ReservedNumber.ToString();
                        ViewData["TrackingCode"] = ReservationTrackingCodeViewModel.TrackingCode;
                        ViewData["Duplicate"] = true;
                    }
                    else
                    {
                        ReservationTrackingCodeViewModel = _appointmentService.GetAppointmentReservationById(result.Result);
                        ViewData["Appointment"] = ReservationTrackingCodeViewModel.ReservedNumber.ToString();
                        ViewData["TrackingCode"] = ReservationTrackingCodeViewModel.TrackingCode;
                    }
                }
                else
                    ViewData["faild"] = true;
                return Page();
            }
               
        }
    }
}
