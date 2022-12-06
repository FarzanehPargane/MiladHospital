using MiladHospital.Models.Reservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Models.Doctor
{
    public class Doctor
    {
        public int Id { get; set; }
        public int SpecialtyId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Surname { get; set; }

        [Display(Name = "کد ملی")]
        [MinLength(10, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        //[Required(ErrorMessage = "{0} را وارد کنید")]

        public string Mellicode { get; set; }

        [Display(Name = "نام کاربری (شماره موبایل)")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = " {0} حداکثر باید {1} کاراکتر باشد")]
        [MinLength(11, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        #region Relation
        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        #endregion




    }
}
