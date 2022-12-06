using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Models.Doctor
{
    public class Specialty
    {
        public int Id { get; set; }
       

        [Display(Name = "تخصص")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Field { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
