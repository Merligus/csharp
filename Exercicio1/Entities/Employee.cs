using System;

namespace Exercicio1.Entities
{
    class Employee<T> : IComparable where T : IComparable
    {
        public int id { get; set; }
        public string name { get; set; }
        public T salary { get; set; }
        public Category category { get; set; }

        public Employee()
        {

        }

        public Employee(string name, T salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Employee<T>))
                throw new ArgumentException("Not an employee");

            Employee<T> objE = obj as Employee<T>;

            int comp = this.salary.CompareTo(objE.salary);
            if (comp != 0)
                return comp;
            else
                return this.name.CompareTo(objE.name);
        }

        public override string ToString()
        {
            return $"{name} salary {salary} tier {category.tier}";
        }

    }
}
