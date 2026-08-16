using CH_Manage.DTO;
using CH_Manage.OperationsLogin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace CH_Manage.MapGroupFold
{
    public static class LoginEndpoints
    {
        public static void MapLoginApi(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auth");

            // User login
            group.MapPost("/login", async (LoginRequest_dto loginRequest, User_Login loginOperation) =>
            {
                var user = await loginOperation.AuthenticateAsync(loginRequest);
                if (user == null)
                {
                    return Results.Unauthorized();
                }
                // In a real application, you would generate and return a JWT here.
                return Results.Ok(new { Message = "Login successful" });
            });

            // Forgot password
            group.MapPost("/forgot-password", async (ForgotPassword_dto forgotPasswordDto, ForgotPassword forgotPasswordOperation) =>
            {
                var user = await forgotPasswordOperation.FindUserByEmailAsync(forgotPasswordDto);
                if (user == null)
                {
                    // Even if the user is not found, we return an OK result to prevent email enumeration.
                    return Results.Ok(new { Message = "If a user with that email exists, a password reset link has been sent." });
                }
                // In a real application, you would generate a reset token and send an email.
                return Results.Ok(new { Message = "If a user with that email exists, a password reset link has been sent." });
            });
        }
    }
}
