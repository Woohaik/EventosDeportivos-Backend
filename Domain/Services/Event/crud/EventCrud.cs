using Domain.Models.IEventContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Event.crud
{
    public class EventCrud : ICrud<IEvent>
    {
        public Task Add(IEvent model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEvent> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id, IEvent model)
        {
            throw new NotImplementedException();
        }
    }
}
