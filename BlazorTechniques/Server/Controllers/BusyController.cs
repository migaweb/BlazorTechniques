using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTechniques.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusyController : ControllerBase
  {
    [HttpGet("{delay}")]
    public async Task<int> Get(int delay)
    {
      await Task.Delay(delay);

      return delay;
    }
  }
}
