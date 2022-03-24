using System;

namespace _26_klasaPerson_klasaChild_Dziedziczenie
{
    internal class Person
    {
        private string _FirstName;
        private string _LastName;
        private int _Age;

        public string FirstName
        {
            get { return _FirstName; }
            protected set
            {
                if (value == null)
                    throw new ArgumentException("Wrong name!");
                value = value.Trim();
                string wyjscie = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ')
                        continue;

                    if (i == 0)
                        wyjscie += char.ToUpper(value[i]);
                    else
                        wyjscie += char.ToLower(value[i]);
                }

                for (int i = 0; i < wyjscie.Length; i++)
                {
                    if (!char.IsLetter(wyjscie[i]))
                        throw new ArgumentException("Wrong name!");
                }

                _FirstName = wyjscie;
            }
        }

        public string FamilyName
        {
            get { return _LastName; }
            protected set
            {
                if (value == null)
                    throw new ArgumentException("Wrong name!");
                value = value.Trim();
                string wyjscie = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ')
                        continue;

                    if (i == 0)
                        wyjscie += char.ToUpper(value[i]);
                    else
                        wyjscie += char.ToLower(value[i]);
                }

                for (int i = 0; i < wyjscie.Length; i++)
                {
                    if (!char.IsLetter(wyjscie[i]))
                        throw new ArgumentException("Wrong name!");
                }

                _LastName = wyjscie;
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be positive!");
                else
                    _Age = value;
            }
        }

        public Person(string firstName, string familyName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {FamilyName} ({Age})";
        }

        public void modifyFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void modifyFamilyName(string familyName)
        {
            FamilyName = familyName;
        }

        public void modifyAge(int wiek)
        {
            Age = wiek;
        }
    }
}