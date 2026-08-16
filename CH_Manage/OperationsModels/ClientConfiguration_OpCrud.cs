using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CH_Manage.OperationsModels
{
    public class ClientConfiguration_OpCrud
    {
        private readonly ApplicationDbContext _context;

        public ClientConfiguration_OpCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates a new client configuration
        public async Task<ClientConfiguration> CreateClientConfigurationAsync(Guid projectId, ClientConfiguration_dto configDto)
        {
            var config = new ClientConfiguration
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                ClientName = configDto.ClientName,
                ClientEmail = configDto.ClientEmail,
                Token = Guid.NewGuid(),
                Status = "Sent", // Default status
                CreatedAt = DateTime.UtcNow
            };

            _context.ClientConfigurations.Add(config);
            await _context.SaveChangesAsync();
            return config;
        }

        // Retrieves a client configuration by its ID
        public async Task<ClientConfiguration> GetClientConfigurationByIdAsync(Guid id)
        {
            return await _context.ClientConfigurations.FindAsync(id);
        }

        // Retrieves all client configurations
        public async Task<List<ClientConfiguration>> GetAllClientConfigurationsAsync()
        {
            return await _context.ClientConfigurations.ToListAsync();
        }

        // Updates an existing client configuration's information
        public async Task<ClientConfiguration> UpdateClientConfigurationAsync(Guid id, ClientConfiguration_dto configDto)
        {
            var config = await _context.ClientConfigurations.FindAsync(id);
            if (config == null)
            {
                return null;
            }

            config.ClientName = configDto.ClientName;
            config.ClientEmail = configDto.ClientEmail;

            _context.ClientConfigurations.Update(config);
            await _context.SaveChangesAsync();
            return config;
        }

        // Deletes a client configuration by its ID
        public async Task<bool> DeleteClientConfigurationAsync(Guid id)
        {
            var config = await _context.ClientConfigurations.FindAsync(id);
            if (config == null)
            {
                return false;
            }

            _context.ClientConfigurations.Remove(config);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
