using Data.DB;
using System;
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

            using (dbEntities ctx = new dbEntities())
            {
                ctx.customers.Add(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            using (dbEntities ctx = new dbEntities())
            {
                customers customers = await ctx.customers.FindAsync(id);
                if (customers == null) throw new Exception("Cliente No Encontrado");
                ctx.customers.Remove(customers);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<customers>> GetAll()
        {
            return await Task.Run(() =>
              {
                  using (dbEntities ctx = new dbEntities())
                  {
                      IEnumerable<customers> customers = ctx.customers.ToList();
                      return customers;
                  }
              });

        }

        public async Task<customers> GetById(int id)
        {

            using (dbEntities ctx = new dbEntities())
            {
                customers customers = await ctx.customers.FindAsync(id);
                if (customers == null) throw new Exception("Cliente No Encontrado");

                return customers;
            }
        }

        public customers GetByEmail(string email)
        {
            using (dbEntities ctx = new dbEntities())
            {
                customers customers = ctx.customers.Where(key => key.customeremail == email).FirstOrDefault();
                if (customers == null) throw new Exception("Cliente No Encontrado");
                return customers;
            }
        }

        public async Task<string> GetRefreshToken(int id)
        {
            customers customers = await this.GetById(id);
            return customers.refreshtoken;

        }

        public async Task UpdateById(int id, customers entity)
        {
            using (dbEntities ctx = new dbEntities())
            {
                customers customers = await ctx.customers.FindAsync(id);
                if (customers == null) throw new Exception("Cliente No Encontrado");
                customers.customerdni = entity.customerdni;
                customers.customeremail = entity.customeremail;
                customers.customername = entity.customerlastname;
                customers.customerpassword = entity.customerpassword;
                customers.customerlastname = entity.customerlastname;
                customers.refreshtoken = entity.refreshtoken;


                await ctx.SaveChangesAsync();
            }
        }
    }
}
