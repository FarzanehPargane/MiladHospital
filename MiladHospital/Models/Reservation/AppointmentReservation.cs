using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Models.Reservation
{
    public class AppointmentReservation
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Surname { get; set; }

        [Display(Name = "کد ملی")]
        [MinLength(10, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public string Mellicode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = " {0} حداکثر باید {1} کاراکتر باشد")]
        [MinLength(11, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        public int ReservedNumber { get; set; }
        public string TrackingCode { get; set; }
        public DateTime RegisterDate { get; set; }

        #region Relation

        public virtual Appointment Appointment { get; set; }
        #endregion



    }
}
