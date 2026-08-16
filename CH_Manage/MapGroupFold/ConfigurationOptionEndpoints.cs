using CH_Manage.OperationsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace CH_Manage.MapGroupFold
{
    public static class ConfigurationOptionEndpoints
    {
        public static void MapConfigurationOptionApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/configuration-options");

            // Add an option to a configuration
            group.MapPost("/{configurationId}/{optionId}", async (Guid configurationId, Guid optionId, ConfigurationOption_OpCrud operations) =>
            {
                var newConfigOption = await operations.AddOptionToConfigurationAsync(configurationId, optionId);
                return Results.Created($"/api/configuration-options/{newConfigOption.Id}", newConfigOption);
            });

            // Get all options for a configuration
            group.MapGet("/{configurationId}", async (Guid configurationId, ConfigurationOption_OpCrud operations) =>
            {
                var options = await operations.GetOptionsForConfigurationAsync(configurationId);
                return Results.Ok(options);
            });

            // Remove an option from a configuration
            group.MapDelete("/{configurationId}/{optionId}", async (Guid configurationId, Guid optionId, ConfigurationOption_OpCrud operations) =>
            {
                var success = await operations.RemoveOptionFromConfigurationAsync(configurationId, optionId);
                if (!success)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });
        }
    }
}
