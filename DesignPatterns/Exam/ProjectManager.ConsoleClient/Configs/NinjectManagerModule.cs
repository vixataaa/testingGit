using System.Linq;
using System.Reflection;
using System.IO;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using Ninject.Extensions.Factory;
using ProjectManager.Data;
using ProjectManager.Framework.Data;
using Ninject.Extensions.Interception.Infrastructure.Language;
using ProjectManager.Framework.Core.Commands.Decorators;
using Ninject.Parameters;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine)
                    && type != typeof(Database)
                    && type != typeof(CachingService))
                .BindDefaultInterface();
            });

            var engine = this.Bind<IEngine>().To<Engine>().InSingletonScope();
            var database = this.Bind<IDatabase>().To<Database>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            var cacheDuration = configurationProvider.CacheDurationInSeconds;
            this.Bind<ICachingService>().To<CachingService>().InSingletonScope()
                .WithConstructorArgument("duration", cacheDuration);

            this.Bind<ILogger>().To<FileLogger>().InSingletonScope()
                .WithConstructorArgument(configurationProvider.LogFilePath);

            var reader = this.Bind<IReader>().To<ConsoleReader>();
            var writer = this.Bind<IWriter>().To<ConsoleWriter>();
            var commandProcessor = this.Bind<IProcessor>().To<CommandProcessor>();

            Kernel.InterceptAround<CommandProcessor>(prc => prc.ProcessCommand(""),
                invocationBefore => { },
                invocationAfter =>
                {
                    var writerProvider = Kernel.Get<IWriter>();
                    writerProvider.WriteLine(invocationAfter.ReturnValue);
                });

            commandProcessor.Intercept().With<LogErrorInterceptor>();

            // Commands
            // - Creational
            var createProjectCmd = this.Bind<ICommand>().To<CreateProjectCommand>().Named("createproject");
            var createTaskCmd = this.Bind<ICommand>().To<CreateTaskCommand>().Named("createtask");
            var createUserCmd = this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");
            // - Decorators


            // - Listing
            var listProjectDetailsCmd = this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named("listprojectdetails");
            var listProjectsCmd = this.Bind<ICommand>().To<ListProjectsCommand>().Named("listprojects");

            // Decorators
            var validatableCmd = this.Bind<ValidatableCommand>().ToSelf();

            // Cmd factories
            this.Bind<ICommandsFactory>().ToFactory();

            this.Bind<ICommand>().ToMethod(context =>
            {
                string commandName = context.Parameters.Single().GetValue(context, null).ToString().ToLower();

                var foundCommand = context.Kernel.Get<ICommand>(commandName);

                if (commandName == "listprojects")
                {
                    foundCommand = context.Kernel.Get<CacheableCommand>(new ConstructorArgument("command", foundCommand));
                }

                return context.Kernel.Get<ValidatableCommand>(new ConstructorArgument("command", foundCommand));
            }).NamedLikeFactoryMethod((ICommandsFactory commandFactory) => commandFactory.GetCommandFromString(null));
        }
    }
}
