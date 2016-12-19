using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebClient.Controllers
{
    public class ClientController : ApiController
    {
        private const string APP_PATH = "http://localhost:63447/";

        [HttpGet]
        public IHttpActionResult Get()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(APP_PATH + "api/ToDo/").Result;

                return Ok(response.Content.ReadAsStringAsync().Result);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(APP_PATH + $"api/ToDo/{id}").Result;

                return Ok(response.Content.ReadAsStringAsync().Result);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]object toDo)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(toDo.ToString(), Encoding.UTF8, "application/json");
                var response = client.PostAsync(APP_PATH + "api/Values/", content).Result;

                return Ok(response.StatusCode);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(APP_PATH + $"api/ToDo/{id}").Result;

                return Ok(response.Content.ReadAsStringAsync().Result);
            }
        }
        public IHttpActionResult Put(int id, [FromBody] object toDo)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.PutAsJsonAsync(APP_PATH + $"/api/book/{id}", toDo).Result;
                return Ok(response.StatusCode);
            }
        }
    }
}
