using MiladHospital.Models.Reservation;
using MiladHospital.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MiladHospital.Models.ViewModels.AppointmentReservationViewModel;

namespace MiladHospital.Services.Interfaces
{
   public interface IAppointmentService
    {
        IQueryable<AppointmentInfoViewModel> GetFreeTimeDoctors(int filterfield);
        ReservationTrackingCodeViewModel GetAppointmentReservationById(int Id);
        ReservationTrackingCodeViewModel GetAppointmentReservationByMellicode(int AppointmentId,string Mellicode);
        Task<int> AddAppointmentReservation(AppointmentReservation appointmentReservation);
    }
}
