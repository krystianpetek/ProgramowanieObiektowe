using System;

namespace _26_klasaPerson_klasaChild_Dziedziczenie
{
    internal class Child : Person
    {
        public Child(string firstName, string familyName, int age, Person mother = null, Person father = null) : base(firstName, familyName, age)
        {
            this.Age = age;
            this.mother = mother;
            this.father = father;
        }

        public new int Age
        {
            get { return base.Age; }
            private set
            {
                if (value > 15 || value < 0)
                    throw new ArgumentException("Child’s age must be less than 15!");
                base.Age = value;
            }
        }

        public new void modifyAge(int wiek)
        {
            Age = wiek;
        }

        public Person mother { get; }
        public Person father { get; }

        public override string ToString()
        {
            string wyjscie = base.ToString();
            if (mother != null)
                wyjscie += $"\nmother: {mother.FirstName} {mother.FamilyName} ({mother.Age})";
            else
                wyjscie += $"\nmother: No data";

            if (father != null)
                wyjscie += $"\nfather: {father.FirstName} {father.FamilyName} ({father.Age})";
            else
                wyjscie += $"\nfather: No data";

            return wyjscie;
        }
    }
}