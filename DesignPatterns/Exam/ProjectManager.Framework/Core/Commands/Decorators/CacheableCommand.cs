using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICachingService cachingService;
        private readonly ICommand command;

        public CacheableCommand(ICommand command, ICachingService cachingService)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(cachingService, "cachingService").IsNull().Throw();

            this.command = command;
            this.cachingService = cachingService;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            string className = this.command.GetType().Name.ToLower();
            string methodName = "execute";

            string executionResult = string.Empty;

            if (this.cachingService.IsExpired)
            {
                this.cachingService.ResetCache();
                executionResult = this.command.Execute(parameters);
                this.cachingService.AddCacheValue(className, methodName, executionResult);
            }

            try
            {
                executionResult = this.cachingService.GetCacheValue(className, methodName).ToString();
            }
            catch(KeyNotFoundException ex)
            {
                executionResult = this.command.Execute(parameters);
                this.cachingService.AddCacheValue(className, methodName, executionResult);
            }

            return executionResult;
        }
    }
}
