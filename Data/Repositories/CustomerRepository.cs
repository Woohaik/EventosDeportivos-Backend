using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static CustomerRepository instance = null;
        private CustomerRepository() { }
        public static CustomerRepository Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CustomerRepository();
                }
                return instance;
            }
        }


        public async Task Add(customers entity)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                ctx.customers.Add(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<customers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<customers> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(int id, customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
