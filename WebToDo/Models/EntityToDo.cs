using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebToDo.Models
{
    public class EntityToDo
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}