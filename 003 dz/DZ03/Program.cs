using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamilyMembers GrandFatherOne = new FamilyMembers()
            {
                FullName = "Petrov Jury ",
                Age = 70,
                Gender = Gender.men
            };

            FamilyMembers GrandFatherTwo = new FamilyMembers()
            {
                FullName = "Sorokin Ivan ",
                Age = 75,
                Gender = Gender.men
            };

            FamilyMembers GrandMotherOne = new FamilyMembers()
            {
                FullName = "Petrova Natali",
                Age = 69,
                Gender = Gender.women
            };

            FamilyMembers GrandMotherTwo = new FamilyMembers()
            {
                FullName = "Sorokina Anjelika",
                Age = 71,
                Gender = Gender.women
            };


            FamilyMembers Mother = new FamilyMembers()
            {
                FullName = "Petrova Nadezda",
                Age = 50,
                Gender = Gender.women,
                Mother = GrandMotherTwo,
                Father = GrandFatherTwo,
            };

            FamilyMembers Father = new FamilyMembers()
            {
                FullName = "Petrov Vladimir",
                Age = 45,
                Gender = Gender.men,
                Mother = GrandMotherOne,
                Father = GrandFatherOne
            };

            FamilyMembers Son = new FamilyMembers()
            {
                FullName = "Petrov Daniel",
                Age = 9,
                Gender = Gender.men,
                Mother = Mother,
                Father = Father
            };

            FamilyMembers Son01 = new FamilyMembers()
            {
                FullName = "Borisov Alexander",
                Age = 21,
                Gender = Gender.men,
                Mother = Mother,
                Father = Father
            };

            FamilyMembers Daughter = new FamilyMembers()
            {
                FullName = "Petrova Anastasia",
                Age = 12,
                Gender = Gender.women,
                Mother = Mother,
                Father = Father
            };


            FamilyMembers Daughter01 = new FamilyMembers()
            {
                FullName = "Petrova Anna",
                Age = 31,
                Gender = Gender.women,
                Mother = Mother,
                Father = Father
            };

            FamilyMembers Daughter02 = new FamilyMembers()
            {
                FullName = "Petrova Izabela",
                Age = 3,
                Gender = Gender.women,
                Mother = Mother,
                Father = Father
            };


            Father.Children.Add(Daughter01);
            Father.Children.Add(Daughter);
            Father.Children.Add(Son);
            Father.Children.Add(Daughter02);

            Mother.Children.Add(Son01);
            Mother.Children.Add(Daughter);
            Mother.Children.Add(Son);
            Mother.Children.Add(Daughter02);

            var FathersParents = Son.GetFatherParentsName();
            var MothersParents = Son.GetMotherParentsName();

            Father.PrintTree(FathersParents, Father.FullName, Mother.FullName, Father.Children);
            Mother.PrintTree(MothersParents, Mother.FullName, Father.FullName, Mother.Children);


            /*
                        string prefix = "";

                        var FathersParents = Son.GetFatherParentsName();
                        Console.WriteLine($"Fathers Parents \n{FathersParents[0].FullName} + {FathersParents[1].FullName}");
                        Console.WriteLine(prefix + "│");
                        Console.Write(prefix + "└── ");
                        prefix += "    ";

                        Console.Write("\x1b[31mFather = \x1b[0m\x1b[31m{0}\x1b[0m", Father.FullName);
                        Console.WriteLine($" + Zhena {Mother.FullName}");

                      foreach (var child in Father.Children)
                        {
                            Console.WriteLine(prefix + "│");
                            Console.Write(prefix + "├── ");
                            Console.WriteLine($"{child.FullName},Age({child.Age})");
                        }

                        Console.WriteLine("");

                        prefix = "";

                        var MothersParents = Son.GetMotherParentsName();
                        Console.WriteLine($"Mothers Parents \n{MothersParents[0].FullName} + {MothersParents[1].FullName}");
                        Console.WriteLine(prefix + "│");
                        Console.Write(prefix + "└── ");
                        prefix += "    ";

                        //Console.Write($"Mother = {Mother.FullName}");
                        Console.Write("\x1b[31mMother = \x1b[0m\x1b[31m{0}\x1b[0m", Mother.FullName);
                        Console.WriteLine($" + Muzh {Father.FullName}");

                        foreach (var child in Mother.Children)
                        {
                            Console.WriteLine(prefix + "│");
                            Console.Write(prefix + "├── ");
                            Console.WriteLine($"{child.FullName},Age({child.Age})");
                        }

                        Console.WriteLine("");
             */


        }
    }

}

