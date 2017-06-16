using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, IProcessor commandProcessor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "commandProcessor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.commandProcessor.ProcessCommand(commandLine);
            }
        }
    }
}
