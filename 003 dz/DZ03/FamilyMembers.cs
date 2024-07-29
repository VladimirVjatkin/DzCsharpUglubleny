using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ03
{
    public class FamilyMembers
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }

        public FamilyMembers Mother { get; set; }
        public FamilyMembers Father { get; set; }

        public List<FamilyMembers> Children { get; set; } = new List<FamilyMembers>();


        public FamilyMembers[] GetMotherParentsName()
        {

            return new FamilyMembers[] { Mother.Mother, Mother.Father };
        }

        public FamilyMembers[] GetFatherParentsName()
        {

            return new FamilyMembers[] { Father.Mother, Father.Father };
        }

        
        public void PrintTree(FamilyMembers[] Parents, string Person, string Person2, List<FamilyMembers> Children)
        {
            string prefix = "";

            //var FathersParents = GetFatherParentsName();
            Console.WriteLine($" Parents \n{Parents[0].FullName} + {Parents[1].FullName}");
            Console.WriteLine(prefix + "│");
            Console.Write(prefix + "└── ");
            prefix += "    ";

            Console.Write("\x1b[31m = \x1b[0m\x1b[31m{0}\x1b[0m", Person);
            Console.WriteLine($" + {Person2}");

            foreach (var child in Children)
            {
                Console.WriteLine(prefix + "│");
                Console.Write(prefix + "├── ");
                Console.WriteLine($"{child.FullName},Age({child.Age})");
            }

            Console.WriteLine("");
            
        }

    }



    public enum Gender { men, women }

}
