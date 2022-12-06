using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MiladHospital.Models.Doctor;
using MiladHospital.Models.Reservation;
using MiladHospital.Models.ViewModels;
using MiladHospital.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static MiladHospital.Models.ViewModels.AppointmentReservationViewModel;

namespace MiladHospital.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IDbConnection db;
       

        public AppointmentService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

       

        public IQueryable<AppointmentInfoViewModel> GetFreeTimeDoctors(int filterfield=0)
        {
            //lazyload:این کویری تا زمانی که ریترن نشده اجرا نمی شود
            IQueryable<AppointmentInfoViewModel>  AppointmentInfo = db.Query<AppointmentInfoViewModel>("Appointments_SelectFreetimeDoctors", null, commandType: CommandType.StoredProcedure).ToList().AsQueryable();
            if(filterfield!=0)
            {
                AppointmentInfo= AppointmentInfo.Where(a => a.SpecialtuId == filterfield);
            }
            
            return AppointmentInfo;
        }
        public async Task<int> AddAppointmentReservation(AppointmentReservation appointmentReservation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", appointmentReservation.AppointmentId);
            parameters.Add("@Name", appointmentReservation.Name);
            parameters.Add("@Surname", appointmentReservation.Surname);
            parameters.Add("@Mellicode", appointmentReservation.Mellicode);
            parameters.Add("@Mobile", appointmentReservation.Mobile);
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await db.ExecuteAsync("AppointmentReservation_Insert", parameters, commandType: CommandType.StoredProcedure);
            int result = parameters.Get<int>("@Result");
            return result;

        }

        public ReservationTrackingCodeViewModel GetAppointmentReservationById(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var AppointmentReservation = db.Query<ReservationTrackingCodeViewModel>("AppointmentReservation_SelectById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            return AppointmentReservation;
        }

        public ReservationTrackingCodeViewModel GetAppointmentReservationByMellicode(int AppointmentId, string Mellicode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", AppointmentId);
            parameters.Add("@Mellicode", Mellicode);
            var AppointmentReservation = db.Query<ReservationTrackingCodeViewModel>("AppointmentReservation_SelectByMellicode", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            return AppointmentReservation;
        }

      
    }
}
