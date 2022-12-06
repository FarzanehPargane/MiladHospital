using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MiladHospital.Models.Doctor;

namespace MiladHospital.Models.Reservation
{
    public class Appointment
    {
        public int Id { get; set; }

      
        public int DoctorId { get; set; }

        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public DateTime ReserveDate { get; set; }

        
        [Display(Name = "زمان رزرو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public TimeSpan StartTime { get; set; }

        [Display(Name = " زمان رزرو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "ظرفیت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Capacity { get; set; }
        public int UsedCapacity { get; set; }
        public bool Active { get; set; }



        #region Relation
       
   
        public virtual Doctor.Doctor Doctor { get; set; }
        public virtual ICollection<AppointmentReservation> AppointmentReservations { get; set; }

        #endregion
    }
}
