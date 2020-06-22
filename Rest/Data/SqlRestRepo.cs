
using System;
using System.Collections.Generic;
using System.Linq;
using Rest.Models;

namespace Rest.Data
{
    public class SqlRestRepo : IRepository
    {
        private readonly RestContext context;
        public SqlRestRepo(RestContext context)
        {
            this.context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            
            context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            // throw new NotImplementedException();
        }
    }
}