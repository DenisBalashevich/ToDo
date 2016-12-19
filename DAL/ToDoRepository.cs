using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext uow = new ToDoContext();
        public void Add(DalToDo task)
        {
            try
            {
                uow.Set<DalToDo>().Add(task);
                uow.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }

        }

        public IEnumerable<DalToDo> GetAll()
        {
            IEnumerable<DalToDo> list;
            try
           {
                list = uow.Set<DalToDo>().ToList();
            }
            catch
            {
                throw new ArgumentNullException();
            }
            return list;
        }
        public DalToDo GetById(int id)
        {
            DalToDo task;
            try
            {
                task = uow.Set<DalToDo>().FirstOrDefault(a => a.Id == id);
            }
            catch {
                throw new ArgumentNullException();
            }
            return task;
        }

        public void Delete(int id)
        {
            try
            {
                uow.Set<DalToDo>().Remove(uow.Set<DalToDo>().Single(u=>u.Id == id));
               
            }
            catch {
                throw new Exception();
            }
        }
        public void Update(int id, DalToDo task)
        {
            var toDo = GetById(id);
            if (!ReferenceEquals(task.Author, null))
                toDo.Author = task.Author;
            if (!ReferenceEquals(task.Content, null))
                toDo.Content = task.Content;
            if (!ReferenceEquals(task.Name, null))
                toDo.Name = task.Name;
        }
    }
}
