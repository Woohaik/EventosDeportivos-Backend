using Data.DBMODELS;
using Data.Repositories;
using Domain.Models.Customer;
using Domain.Models.Event;
using Domain.Models.IReservationContracts;
using Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Reservation.crud
{
    public class ReservationCrud : ICrud<IReservation>
    {
        protected IReservationRepository reservationRepository = ReservationRepository.Instance;

        public async Task Add(IReservation model)
        {
            reservations dbReservation = new reservations()
            {
                cantidad = model.quantity,
                customersid = model.reservationCustomer.id,
                eventsid = model.reservationEvent.id
            };

            await this.reservationRepository.Add(dbReservation);

        }

        public async Task DeleteById(int id) =>
            await this.reservationRepository.DeleteById(id);


        public async Task<IEnumerable<IReservation>> GetAll()
        {
            IEnumerable<reservations> dbReservations = await this.reservationRepository.GetAll();
            List<IReservation> domainReservation = new List<IReservation>();
            foreach (reservations dbReservation in dbReservations)
            {
                domainReservation.Add(new ReservationModel()
                {
                    quantity = dbReservation.cantidad,
                    reservationCustomer = new CustomerModel()
                    {
                        id = dbReservation.customers.customerid,
                        dni = dbReservation.customers.customerdni,
                        email = dbReservation.customers.customeremail,
                        lastname = dbReservation.customers.customerlastname,
                        name = dbReservation.customers.customername
                    }
                    ,
                    reservationEvent = new EventModel()
                    {
                        id = dbReservation.events.eventid,
                        name = dbReservation.events.eventname,
                        start = dbReservation.events.eventstart,
                        finish = dbReservation.events.eventfinish,
                        limit = dbReservation.events.eventlimit,
                        eventType = (EventTypes)dbReservation.events.eventtypecode
                    },
                    id = dbReservation.reservarionid
                });
            }
            return domainReservation;

        }

        public async Task<IReservation> GetById(int id)
        {
            reservations dbReservation = await this.reservationRepository.GetById(id);
            IReservation domainReservation = new ReservationModel()
            {
                quantity = dbReservation.cantidad,
                reservationCustomer = new CustomerModel()
                {
                    id = dbReservation.customers.customerid,
                    dni = dbReservation.customers.customerdni,
                    email = dbReservation.customers.customeremail,
                    lastname = dbReservation.customers.customerlastname,
                    name = dbReservation.customers.customername
                }
                    ,
                reservationEvent = new EventModel()
                {
                    id = dbReservation.events.eventid,
                    name = dbReservation.events.eventname,
                    start = dbReservation.events.eventstart,
                    finish = dbReservation.events.eventfinish,
                    limit = dbReservation.events.eventlimit,
                    eventType = (EventTypes)dbReservation.events.eventtypecode
                },
                id = dbReservation.reservarionid
            };
            return domainReservation;
        }

        public Task UpdateById(int id, IReservation model)
        {
            throw new NotImplementedException();
        }
    }
}
