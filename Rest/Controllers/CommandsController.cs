
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rest.Data;
using Rest.Models;

namespace Rest.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IRepository repository;
        public CommandsController(IRepository repository)
        {
            this.repository = repository;
        }
        
        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = repository.GetAllCommands();

            return Ok(commands);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = repository.GetCommandById(id);

            return Ok(command);
        }
    }
}