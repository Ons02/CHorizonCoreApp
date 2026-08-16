using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH_Manage.OperationsModels
{
    public class ConfigurationOption_OpCrud
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationOption_OpCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        // Links an option to a client configuration
        public async Task<ConfigurationOption> AddOptionToConfigurationAsync(ConfigurationOption_dto dto)
        {
            var configOption = new ConfigurationOption
            {
                Id = Guid.NewGuid(),
                ConfigurationId = dto.ConfigurationId,
                OptionId = dto.OptionId
            };

            _context.ConfigurationOptions.Add(configOption);
            await _context.SaveChangesAsync();
            return configOption;
        }

        // Retrieves all options for a given configuration
        public async Task<List<Option>> GetOptionsForConfigurationAsync(Guid configurationId)
        {
            return await _context.ConfigurationOptions
                .Where(co => co.ConfigurationId == configurationId)
                .Select(co => co.Option)
                .ToListAsync();
        }

        // Removes an option from a client configuration
        public async Task<bool> RemoveOptionFromConfigurationAsync(Guid configurationId, Guid optionId)
        {
            var configOption = await _context.ConfigurationOptions
                .FirstOrDefaultAsync(co => co.ConfigurationId == configurationId && co.OptionId == optionId);

            if (configOption == null)
            {
                return false;
            }

            _context.ConfigurationOptions.Remove(configOption);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
