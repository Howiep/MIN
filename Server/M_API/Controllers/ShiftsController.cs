using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_API.ViewModels.Shift;
using M_Data.Models.Shift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Shifts")]
    public class ShiftsController : Controller
    {
        // POST: api/Shifts
        [HttpPost]
        public void Post([FromBody]ShiftViewModel shift)
        {
            var shiftEntry = new ShiftViewModel {
                
            };
        }
    }
}
