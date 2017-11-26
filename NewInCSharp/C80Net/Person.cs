using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C80Net
{
    // 8.0 nullable reference types
    public class Person
    {
        public Person(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string? MiddleName { get; }
    }
    public static class Helpers
    {
        public static int GetLegthOfMiddleName(Person p)
        {
            var name = p.MiddleName;
            if (name is null) return 0;
            return name.Length;
            //return name?.Length ?? 0;
        }
    }
}
