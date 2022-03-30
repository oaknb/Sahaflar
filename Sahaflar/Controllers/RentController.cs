using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sahaflar.Entities;
using Sahaflar.Models;
using Sahaflar.Repositories.Abstract;
using System.Collections.Generic;

namespace Sahaflar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;

        }

        [HttpPost]
        [Route("AddRent")]
        public IActionResult AddRent(Rent rent)
        {
            bool result = rentRepository.AddRent(rent);
            if (result)
            {
                return Ok(new ResultModel { State = "Succeed", Message = "Rent created successfully" });
            }

            return BadRequest(new ResultModel { State = "Warning", Message = "Rent could not create." });
        }

        [HttpGet]
        [Route("GetRents")]
        public IActionResult GetRents()
        {
            List<Rent> rents = rentRepository.GetRents();
            if (rents != null)
            {
                return Ok(rents);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Any rents cannot be found" });

        }

        [HttpGet]
        [Route("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            Rent rent = rentRepository.GetRentById(id);
            if (rent != null)
            {
                return Ok(rent);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Rent cannot be found" });

        }

        [HttpGet]
        [Route("GetRentById")]
        public IActionResult GetRentById(int id)
        {
            Rent rent = rentRepository.GetRentById(id);
            if (rent != null)
            {
                return Ok(rent);
            }

            return BadRequest(new ResultModel { State = "Error", Message = "Rent cannot be found" });

        }

        [HttpGet]
        [Route("GetRentDetail")]
        public IActionResult GetRentDetail(string date)
        {
            int result = rentRepository.GetRentCountByDay(date);

            if(result>0)
            {
                return Ok(result);
            }

            return BadRequest(new ResultModel { State = "Warning", Message = "No rented books found for this day." });
        }
    }
}
