using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCitites()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            //find city
            var cityModel = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            
            if(cityModel == null)
            {
                return NotFound();
            }

            return Ok(cityModel);
        }
    }
}