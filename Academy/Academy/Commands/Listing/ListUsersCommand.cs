namespace Academy.Commands.Listing
{
    using Academy.Core;
    using Academy.Core.Contracts;
    class ListUsersCommand
    {
        public static void Print()
        {
            var engine1 = Engine.Instance;
            foreach (var trainer in engine1.Trainers)
            {
                System.Console.WriteLine(trainer);
            }

            foreach (var student in engine1.Students)
            {
                System.Console.WriteLine(student);
            }
        }    

        // TODO: Implement this
    }
}
