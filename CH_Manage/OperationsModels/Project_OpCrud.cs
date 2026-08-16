using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CH_Manage.OperationsModels
{
    public class Project_OpCrud
    {
        private readonly ApplicationDbContext _context;

        public Project_OpCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates a new project
        public async Task<Project> CreateProjectAsync(Project_dto projectDto)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Title = projectDto.Title,
                Description = projectDto.Description,
                BasePrice = projectDto.BasePrice,
                CreatedAt = DateTime.UtcNow
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        // Retrieves a project by its ID
        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        // Retrieves all projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        // Updates an existing project's information
        public async Task<Project> UpdateProjectAsync(Guid id, Project_dto projectDto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null;
            }

            project.Title = projectDto.Title;
            project.Description = projectDto.Description;
            project.BasePrice = projectDto.BasePrice;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        // Deletes a project by its ID
        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
