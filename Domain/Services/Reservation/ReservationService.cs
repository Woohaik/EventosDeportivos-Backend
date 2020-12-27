using Domain.Services.IServicesContracts;
using Domain.Services.Reservation.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Reservation
{
    public class ReservationService : ReservationCrud , IReservationService
    {
        private static ReservationService instance = null;
        private ReservationService() { }
        public static ReservationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReservationService();
                }
                return instance;
            }
        }

    }
}
