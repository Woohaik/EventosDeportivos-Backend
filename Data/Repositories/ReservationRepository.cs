using Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {

        private static ReservationRepository instance = null;
        private ReservationRepository() { }
        public static ReservationRepository Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ReservationRepository();
                }
                return instance;
            }
        }

        public async Task Add(reservations entity)
        {
            using (dbEntities ctx = new dbEntities())
            {
                ctx.reservations.Add(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            using (dbEntities ctx = new dbEntities())
            {
                reservations reservation = await ctx.reservations.FindAsync(id);
                if (reservation == null) throw new Exception("Reserva No Encontrada");
                ctx.reservations.Remove(reservation);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<reservations>> GetAll()
        {
            return await Task.Run(() =>
             {
                 using (dbEntities ctx = new dbEntities())
                 {
                     IEnumerable<reservations> reservations = ctx.reservations.ToList();
                     return reservations;
                 }
             });
        }

        public async Task<reservations> GetById(int id)
        {
            using (dbEntities ctx = new dbEntities())
            {
                reservations reservation = await ctx.reservations.FindAsync(id);
                if (reservation == null) throw new Exception("Reserva No Encontrada");

                return reservation;
            }
        }

        public Task UpdateById(int id, reservations entity)
        {
            throw new NotImplementedException();
        }
    }
}
