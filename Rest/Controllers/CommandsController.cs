
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
        [Authorize]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = repository.GetAllCommands();

            return Ok(mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        [Authorize]
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
        [Authorize]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = mapper.Map<Command>(commandCreateDTO);

            repository.CreateCommand(commandModel);
            repository.SaveChanges();

            var commandReadDTO = mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var commandModel = repository.GetCommandById(id);
            if (commandModel == null)
            {
                return NotFound();
            }

            mapper.Map(commandUpdateDTO, commandModel);
            
            repository.UpdateCommand(commandModel);
            repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        [Authorize]
        public ActionResult PatchCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDocument)
        {
            var commandModel = repository.GetCommandById(id);
            if (commandModel == null)
            {
                return NotFound();
            }

            var commandToPatch = mapper.Map<CommandUpdateDTO>(commandModel);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(commandToPatch, commandModel);

            repository.UpdateCommand(commandModel);
            repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteCommand(int id)
        {
            var commandToDelete = repository.GetCommandById(id);
            if (commandToDelete == null)
            {
                return NotFound();
            }

            repository.DeleteCommand(commandToDelete);
            repository.SaveChanges();

            return NoContent();
        }
    }
}