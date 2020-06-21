
using System.Collections.Generic;
using Rest.Models;

namespace Rest.Data
{
    public class MockRestRepo : IRepository
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle & Pan"},
                new Command{Id = 1, HowTo="Cut bread", Line="Get a knife", Platform="Cutting board"},
                new Command{Id = 2, HowTo="Make tea", Line="Place tea bag in cup", Platform="Kettle & Cup"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}