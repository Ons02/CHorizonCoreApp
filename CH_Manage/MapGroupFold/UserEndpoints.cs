using CH_Manage.DTO;
using CH_Manage.OperationsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CH_Manage.MapGroupFold
{
    public static class UserEndpoints
    {
        public static void MapUserApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users");

            // Create a new user
            group.MapPost("/", async (User_dto userDto, User_OpCrud operations) =>
            {
                var newUser = await operations.CreateUserAsync(userDto);
                return Results.Created($"/api/users/{newUser.Id}", newUser);
            });

            // Get all users
            group.MapGet("/", async (User_OpCrud operations) =>
            {
                var users = await operations.GetAllUsersAsync();
                return Results.Ok(users);
            });

            // Get a user by ID
            group.MapGet("/{id}", async (Guid id, User_OpCrud operations) =>
            {
                var user = await operations.GetUserByIdAsync(id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            // Update a user
            group.MapPut("/{id}", async (Guid id, User_dto userDto, User_OpCrud operations) =>
            {
                var updatedUser = await operations.UpdateUserAsync(id, userDto);
                if (updatedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(updatedUser);
            });

            // Delete a user
            group.MapDelete("/{id}", async (Guid id, User_OpCrud operations) =>
            {
                var success = await operations.DeleteUserAsync(id);
                if (!success)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            });
        }
    }
}
