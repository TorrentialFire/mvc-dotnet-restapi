
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rest.Data;
using Rest.DTOs;
using Rest.Models;

namespace Rest.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CommandsController(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        
        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = repository.GetAllCommands();

            return Ok(mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var command = repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommandReadDTO>(command));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = mapper.Map<Command>(commandCreateDTO);

            repository.CreateCommand(commandModel);
            repository.SaveChanges();

            var commandReadDTO = mapper.Map<CommandReadDTO>(commandModel);
            
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO);
        }
    }
}