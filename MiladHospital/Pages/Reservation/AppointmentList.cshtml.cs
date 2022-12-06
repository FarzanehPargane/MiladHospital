using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiladHospital.Models.Doctor;
using MiladHospital.Models.ViewModels;
using MiladHospital.Services.Interfaces;

namespace MiladHospital.Pages.Reservation
{
    public class AppointmentListModel : PageModel
    {
        IAppointmentService _appointmentService;
        ISpecialtyService _SpecialtyService;
        public AppointmentListModel(IAppointmentService appointmentService,ISpecialtyService specialtyService)
        {
            _appointmentService = appointmentService;
            _SpecialtyService = specialtyService;
        }

        public IQueryable<AppointmentInfoViewModel> appointmentInfoViewModels { get; set; }
        public List<Specialty> specialties { get; set; }
        public SelectList specialtyList { get; set; }
        public void OnGet(int filterfield=0)
        {
            appointmentInfoViewModels = _appointmentService.GetFreeTimeDoctors(filterfield);
            specialties = _SpecialtyService.GetSpecialtyList();
            specialtyList = new SelectList(specialties, "Id", "Field", "انتخاب کنید...");
        }
    }
}
