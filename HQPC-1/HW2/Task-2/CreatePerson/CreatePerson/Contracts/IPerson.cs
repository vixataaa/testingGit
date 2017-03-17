using System;
using CreatePerson.Enumerations;

namespace CreatePerson.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        Gender Gender { get; }
    }
}
