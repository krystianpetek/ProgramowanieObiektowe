using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsInZoo
{
    internal class Zoo : IEnumerable
    {
        List<Animal> animals = new List<Animal>();

        public IEnumerator GetEnumerator()
        {
            foreach(Animal theAnimal in animals)
            {
                yield return theAnimal.Name;
            }
        }
        
        public void AddBird(string name)
        {
            animals.Add(new Animal() { Name = name, Type = Animal.TypeEnum.Bird });
        }

        public void AddMammal(string name)
        {
            animals.Add(new Animal() { Name = name, Type = Animal.TypeEnum.Mammal });
        }

        public IEnumerable Mammals()
        {
            return AnimalsForType(Animal.TypeEnum.Mammal);
        }

        public IEnumerable Birds()
        {
            return AnimalsForType(Animal.TypeEnum.Bird);
        }

        private IEnumerable AnimalsForType(Animal.TypeEnum type)
        {
            foreach (Animal theAnimal in animals)
            {
                if (theAnimal.Type == type)
                    yield return theAnimal.Name;
            }
        }
    }
}
