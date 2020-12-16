﻿namespace BakeryOpenning
{
    using System;
    using System.Text;

    public class Employee
    {
        public Employee(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Employee: {this.Name}, {this.Age} ({this.Country})");

            return sb.ToString().TrimEnd();
        }
    }
}
