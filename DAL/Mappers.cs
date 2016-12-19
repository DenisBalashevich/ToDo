
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Mappers
    {
        public static DalToDo ToDalToDo(this DalToDo task)
        {
            return new DalToDo
            {
                Author = task.Author,
                Content = task.Content,
                Id = task.Id,
                Name = task.Name
            };
        }
        //public static ToDoes ToORMToDo(this DalToDo task)
        //{
        //    return new ToDoes
        //    {
        //        Author = task.Author,
        //        Content = task.Content,
        //        Id = task.Id,
        //        Name = task.Name
        //    };
        //}
    }
}
