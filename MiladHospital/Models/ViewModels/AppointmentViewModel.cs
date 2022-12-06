using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Models.ViewModels
{
    public class AppointmentInfoViewModel
    {
        public int Id { get; set; }


        public int DoctorId { get; set; }
    

        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public DateTime ReserveDate { get; set; }


        [Display(Name = "زمان رزرو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public string AppointmentsTime { get; set; }
        public string DoctorName { get; set; }
        public string Field { get; set; }
        public int SpecialtuId { get; set; }


        [Display(Name = "ظرفیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Capacity { get; set; }
        public int UsedCapacity { get; set; }
        public int RemainCapacity { get; set; }
        public bool Active { get; set; }
    }
}
