using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHospital.Models.ViewModels
{
    public class AppointmentReservationViewModel
    {
        public class ReservationTrackingCodeViewModel
        {
            public int ReservedNumber { get; set; }
            public string TrackingCode { get; set; }
        }
         
    }
}
