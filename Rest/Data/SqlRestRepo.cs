
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

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return context.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}