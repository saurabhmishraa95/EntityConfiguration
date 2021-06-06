using EntityConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Services
{
    public interface IConfigurationService
    {
        Task<ConfigurationResponse> GetConfigurationAsync();
        Task SaveConfigurationAsync(ConfigurationRequest configurationRequest);
    }
}
