using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _iRentalService;

        public RentalsController(IRentalService iRentalService)
        {
            _iRentalService = iRentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _iRentalService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbycustomer")]
        public IActionResult GetAllByCustomer(int customerId)
        {
            var result = _iRentalService.GetAllByCustomer(customerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbycar")]
        public IActionResult GetAllByCar(int carId)
        {
            var result = _iRentalService.GetAllByCar(carId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _iRentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _iRentalService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _iRentalService.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _iRentalService.Delete(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
