using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Scooter_rental.Controllers
{
    [Route("rentedScooter-api")]
    [ApiController]
    public class RentedScooterController : ControllerBase
    {

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
