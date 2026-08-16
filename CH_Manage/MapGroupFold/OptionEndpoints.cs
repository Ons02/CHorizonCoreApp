using CH_Manage.DTO;
using CH_Manage.OperationsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace CH_Manage.MapGroupFold
{
    public static class OptionEndpoints
    {
        public static void MapOptionApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/options");

            // Create a new option
            group.MapPost("/", async (Option_dto optionDto, Option_OpCrud operations) =>
            {
                var newOption = await operations.CreateOptionAsync(optionDto);
                return Results.Created($"/api/options/{newOption.Id}", newOption);
            });

            // Get all options
            group.MapGet("/", async (Option_OpCrud operations) =>
            {
                var options = await operations.GetAllOptionsAsync();
                return Results.Ok(options);
            });

            // Get an option by ID
            group.MapGet("/{id}", async (Guid id, Option_OpCrud operations) =>
            {
                var option = await operations.GetOptionByIdAsync(id);
                if (option == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(option);
            });

            // Update an option
            group.MapPut("/{id}", async (Guid id, Option_dto optionDto, Option_OpCrud operations) =>
            {
                var updatedOption = await operations.UpdateOptionAsync(id, optionDto);
                if (updatedOption == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(updatedOption);
            });

            // Delete an option
            group.MapDelete("/{id}", async (Guid id, Option_OpCrud operations) =>
            {
                var success = await operations.DeleteOptionAsync(id);
                if (!success)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });
        }
    }
}
