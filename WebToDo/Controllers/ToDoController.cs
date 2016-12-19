using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebToDo.Mappers;
using WebToDo.Models;

namespace WebToDo.Controllers
{
    public class ToDoController : ApiController
    {
        private  ToDoRepository repository = new ToDoRepository();
        [HttpGet]
        public IEnumerable<EntityToDo> Get()
        {
            return repository.GetAll().Select(a => a.ToWebToDo());
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var toDo = repository.GetById(id);
            if (ReferenceEquals(null, toDo))
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, EntityToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.Id)
            {
                return BadRequest();
            }

            try
            {
                repository.Update(id, toDo.ToDalToDoEntity());
            }
            catch
            {
                throw new Exception();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult Post(EntityToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            toDo.CreateDate = DateTime.Now;
            repository.Add(toDo.ToDalToDoEntity());

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            try
            {
                repository.Delete(id);
            }
            catch
            {
                throw new Exception();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
