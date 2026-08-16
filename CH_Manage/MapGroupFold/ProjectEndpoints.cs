using CH_Manage.DTO;
using CH_Manage.OperationsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace CH_Manage.MapGroupFold
{
    public static class ProjectEndpoints
    {
        public static void MapProjectApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/projects");

            // Create a new project
            group.MapPost("/", async (Project_dto projectDto, Project_OpCrud operations) =>
            {
                var newProject = await operations.CreateProjectAsync(projectDto);
                return Results.Created($"/api/projects/{newProject.Id}", newProject);
            });

            // Get all projects
            group.MapGet("/", async (Project_OpCrud operations) =>
            {
                var projects = await operations.GetAllProjectsAsync();
                return Results.Ok(projects);
            });

            // Get a project by ID
            group.MapGet("/{id}", async (Guid id, Project_OpCrud operations) =>
            {
                var project = await operations.GetProjectByIdAsync(id);
                if (project == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(project);
            });

            // Update a project
            group.MapPut("/{id}", async (Guid id, Project_dto projectDto, Project_OpCrud operations) =>
            {
                var updatedProject = await operations.UpdateProjectAsync(id, projectDto);
                if (updatedProject == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(updatedProject);
            });

            // Delete a project
            group.MapDelete("/{id}", async (Guid id, Project_OpCrud operations) =>
            {
                var success = await operations.DeleteProjectAsync(id);
                if (!success)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });
        }
    }
}
