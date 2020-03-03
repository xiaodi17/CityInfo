using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var cityModel = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (cityModel == null)
            {
                return NotFound();
            }

            return Ok(cityModel.PointsOfInterest);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointOfInterestById(int cityId, int id)
        {
            var cityModel = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (cityModel == null)
            {
                return NotFound();
            }

            //find point of interest
            var pointOfInterest = cityModel.PointsOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
    }
}