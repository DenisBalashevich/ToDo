using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebToDo.Models;

namespace WebToDo.Mappers
{
    public static class ToDoEntityMappers
    {
        public static DalToDo ToDalToDoEntity(this EntityToDo task)
        {
            return new DalToDo
            {
                Author = task.Author,
                Content = task.Content,
                Id = task.Id,
                Name = task.Name,
                CreateDate = task.CreateDate
            };
        }
        public static EntityToDo ToWebToDo(this DalToDo task)
        {
            return new EntityToDo
            {
                Author = task.Author,
                Content = task.Content,
                Id = task.Id,
                Name = task.Name,
                CreateDate = task.CreateDate
            };
        }
    }
}