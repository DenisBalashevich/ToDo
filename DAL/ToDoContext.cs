using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("EntityModel") { }
        public DbSet<DalToDo> ToDoes { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
