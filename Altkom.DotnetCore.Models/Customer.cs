using System;

namespace Altkom.DotnetCore.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Female,
        Man
    }
}
