using MiladHospital.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Services.Interfaces
{
  public  interface ISpecialtyService
    {
        List<Specialty> GetSpecialtyList();
    }
}
