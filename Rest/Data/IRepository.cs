
using System.Collections.Generic;
using Rest.Models;

namespace Rest.Data
{
    public interface IRepository
    {
        bool SaveChanges();
        
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
    }
}