using gexateq_test_BE.Data.DTOs;
using gexateq_test_BE.Database;
using gexateq_test_BE.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace gexateq_test_BE
{
    public static class Endpoints
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app, RouteGroupBuilder apiGroup)
        {
            apiGroup.MapGet("employee/all", async (IEmployeeService employeeService) =>
            {
                var result = await employeeService.GetAllEmployee();
                return Results.Ok(result);
            });

            apiGroup.MapGet("employee/{id}", async (IEmployeeService employeeService, Guid id) =>
            {
                var result = await employeeService.GetEmployee(id);
                return Results.Ok(result);
            });

            apiGroup.MapPost("employee", async (IEmployeeService employeeService, [FromBody] CreateEmployeeDto dto) =>
            {
                try
                {
                    await employeeService.CreateEmployee(dto);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });

            apiGroup.MapPut("employee", async (IEmployeeService employeeService, [FromBody] UpdateEmployeeDto dto) =>
            {
                try
                {
                    await employeeService.UpdateEmployee(dto);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });

            apiGroup.MapDelete("employee/{id}", async (IEmployeeService employeeService, Guid id) =>
            {
                try
                {
                    await employeeService.DeleteEmployee(id);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex);
                }
            });


            apiGroup.MapPost("employee/set-data", async (IEmployeeService employeeService, [FromQuery] int count) =>
            {
                var result = await employeeService.SetData(count);
                return Results.Ok(result);
            });
        }
    }
}
