using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MiladHospital.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Services.Interfaces
{
    public class SpecialtyService : ISpecialtyService
    {
        private IDbConnection db;


        public SpecialtyService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }
        public List<Specialty> GetSpecialtyList()
        {

            var Specialty = db.Query<Specialty>("Specialties_SelectAll", null, commandType: CommandType.StoredProcedure).ToList();

            return Specialty;
        }
    }
}
