using DataAccess.Database;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository
    {

        public bool RegisterCustomer(Customer customer)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.CustomerObj.Add(customer);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
