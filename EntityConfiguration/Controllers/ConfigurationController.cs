using EntityConfiguration.Models;
using EntityConfiguration.Models.Database;
using EntityConfiguration.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        // GET: api/<ConfigurationController>
        [HttpGet]
        public async Task<ActionResult> GetConfigurationAsync()
        {
            var response = await _configurationService.GetConfigurationAsync();
            return Ok(response);

        }

        // POST api/<ConfigurationController>
        [HttpPut]
        public async Task<ActionResult> SaveConfigurationAsync([FromBody] ConfigurationRequest configurationRequest)
        {
            await _configurationService.SaveConfigurationAsync(configurationRequest);
            return Ok();
        }

    }
}
