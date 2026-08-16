using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CH_Manage.OperationsModels
{
    public class Option_OpCrud
    {
        private readonly ApplicationDbContext _context;

        public Option_OpCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates a new option
        public async Task<Option> CreateOptionAsync(Option_dto optionDto)
        {
            var option = new Option
            {
                Id = Guid.NewGuid(),
                ProjectId = optionDto.ProjectId,
                Name = optionDto.Name,
                Description = optionDto.Description,
                Price = optionDto.Price,
                EstimatedDays = optionDto.EstimatedDays
            };

            _context.Options.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }

        // Retrieves an option by its ID
        public async Task<Option> GetOptionByIdAsync(Guid id)
        {
            return await _context.Options.FindAsync(id);
        }

        // Retrieves all options
        public async Task<List<Option>> GetAllOptionsAsync()
        {
            return await _context.Options.ToListAsync();
        }

        // Updates an existing option's information
        public async Task<Option> UpdateOptionAsync(Guid id, Option_dto optionDto)
        {
            var option = await _context.Options.FindAsync(id);
            if (option == null)
            {
                return null;
            }

            option.ProjectId = optionDto.ProjectId;
            option.Name = optionDto.Name;
            option.Description = optionDto.Description;
            option.Price = optionDto.Price;
            option.EstimatedDays = optionDto.EstimatedDays;

            _context.Options.Update(option);
            await _context.SaveChangesAsync();
            return option;
        }

        // Deletes an option by its ID
        public async Task<bool> DeleteOptionAsync(Guid id)
        {
            var option = await _context.Options.FindAsync(id);
            if (option == null)
            {
                return false;
            }

            _context.Options.Remove(option);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
