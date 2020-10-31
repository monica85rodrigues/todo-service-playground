﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;
using TodoList.UseCases;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IUseCaseAsync<Nothing, GetTodosResponse> useCase)
        {
            var response = await useCase.ExecuteAsync(new Nothing());
            return Ok(response.Todos);
        }
    }
}