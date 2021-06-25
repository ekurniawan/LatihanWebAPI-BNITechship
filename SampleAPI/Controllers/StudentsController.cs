using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private List<string> lstNama = new List<string>
        {
            "Erick","Adi","Budi","Amir","Dea"
        };

        [HttpGet]
        public List<string> Get()
        {

            return lstNama;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return lstNama[id];
        }

        [HttpPost]
        public void Post(string nama)
        {
            lstNama.Add(nama);
        }

       
    }
}
