using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IToDoRepository
    {
        IEnumerable<DalToDo> GetAll();
        void Add(DalToDo task);
        DalToDo GetById(int id);
        void Update(int id, DalToDo task);
        void Delete(int id);

    }
}
