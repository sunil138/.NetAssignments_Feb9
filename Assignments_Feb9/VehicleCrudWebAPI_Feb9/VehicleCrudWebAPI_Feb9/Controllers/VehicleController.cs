using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCrudWebAPI_Feb9.Models;

namespace VehicleCrudWebAPI_Feb9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _vehicleContext;
        public VehicleController(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>>GetVehicles()
        {
            if(_vehicleContext.VehicleDetails == null) 
            {
                return NotFound();
            }
            return await _vehicleContext.VehicleDetails.ToListAsync(); 
               
        }

        [HttpGet]
        public async Task<ActionResult<VehicleContext>>GetVehicles(int VehicleId)
        {
            if(_vehicleContext.VehicleDetails==null)
            {
                return NotFound();
            }
            var vehicledetail = await _vehicleContext.VehicleDetails.FindAsync(VehicleId);
            if(vehicledetail == null)
            {
                return NotFound();
            }
            return vehicledetail;
        }


    }
}
