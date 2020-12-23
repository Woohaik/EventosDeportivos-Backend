using System.Collections.Generic;
using System.Linq;
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
            using (dbEntities ctx = new Data.dbEntities())
            {
                customers customer = await ctx.customers.FindAsync(id);
                ctx.customers.Remove(customer);
                await ctx.SaveChangesAsync();
            }
        }

        public IEnumerable<customers> GetAll()
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                IEnumerable<customers> customers = ctx.customers.ToList();
                return customers;
            }
        }

        public async Task<customers> GetById(int id)
        {

            using (dbEntities ctx = new Data.dbEntities())
            {
                customers customers = await ctx.customers.FindAsync(id);
                return customers;
            }
        }

        public async Task UpdateById(int id, customers entity)
        {
            using (dbEntities ctx = new Data.dbEntities())
            {
                customers customers = await ctx.customers.FindAsync(id);
                customers.customerdni = entity.customerdni;
                customers.customeremail = entity.customeremail;
                customers.customername = entity.customerlastname;
                customers.customerpassword = entity.customerpassword;
                customers.customerlastname = entity.customerlastname;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
