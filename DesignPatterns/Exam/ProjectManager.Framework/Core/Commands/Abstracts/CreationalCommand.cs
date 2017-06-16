using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Abstracts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        protected readonly IModelsFactory modelsFactory;

        public CreationalCommand(IDatabase database, IModelsFactory modelsFactory)
            : base(database)
        {
            Guard.WhenArgument(modelsFactory, "modelsFactory").IsNull().Throw();
            this.modelsFactory = modelsFactory;
        }
    }
}
