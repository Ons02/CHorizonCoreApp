using CH_Manage.DTO;
using CH_Manage.OperationsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace CH_Manage.MapGroupFold
{
    public static class ClientConfigurationEndpoints
    {
        public static void MapClientConfigurationApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/client-configurations");

            // Create a new client configuration
            group.MapPost("/{projectId}", async (Guid projectId, ClientConfiguration_dto configDto, ClientConfiguration_OpCrud operations) =>
            {
                var newConfig = await operations.CreateClientConfigurationAsync(projectId, configDto);
                return Results.Created($"/api/client-configurations/{newConfig.Id}", newConfig);
            });

            // Get all client configurations
            group.MapGet("/", async (ClientConfiguration_OpCrud operations) =>
            {
                var configs = await operations.GetAllClientConfigurationsAsync();
                return Results.Ok(configs);
            });

            // Get a client configuration by ID
            group.MapGet("/{id}", async (Guid id, ClientConfiguration_OpCrud operations) =>
            {
                var config = await operations.GetClientConfigurationByIdAsync(id);
                if (config == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(config);
            });

            // Update a client configuration
            group.MapPut("/{id}", async (Guid id, ClientConfiguration_dto configDto, ClientConfiguration_OpCrud operations) =>
            {
                var updatedConfig = await operations.UpdateClientConfigurationAsync(id, configDto);
                if (updatedConfig == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(updatedConfig);
            });

            // Delete a client configuration
            group.MapDelete("/{id}", async (Guid id, ClientConfiguration_OpCrud operations) =>
            {
                var success = await operations.DeleteClientConfigurationAsync(id);
                if (!success)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });
        }
    }
}
