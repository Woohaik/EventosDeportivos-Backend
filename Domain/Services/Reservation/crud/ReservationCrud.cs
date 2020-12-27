using Domain.Models.IReservationContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Reservation.crud
{
    public class ReservationCrud : ICrud<IReservation>
    {
        public Task Add(IReservation model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IReservation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReservation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id, IReservation model)
        {
            throw new NotImplementedException();
        }
    }
}
