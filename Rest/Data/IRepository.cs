
using System.Collections.Generic;
using Rest.Models;

namespace Rest.Data
{
    public interface IRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}