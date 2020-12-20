using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext() : base(nameOrConnectionString: "MyConnection")
        //{

        //}

        public DatabaseContext()  { }

        public virtual DbSet<Customer> CustomerObj { get; set; }



    }
}
