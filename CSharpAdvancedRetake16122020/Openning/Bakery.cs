namespace BakeryOpenning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bakery
    {
        private List<Employee> data;

        public Bakery()
        {
            this.data = new List<Employee>();
        }

        public Bakery(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.data
                .FirstOrDefault(e => e.Name == name);

            if (employee != null)
            {
                this.data.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = this.data
                .OrderByDescending(e => e.Age)
                .FirstOrDefault();

            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.data
                .FirstOrDefault(e => e.Name == name);

            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb
                    .AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
