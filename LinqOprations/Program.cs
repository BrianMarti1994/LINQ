using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOprations
{
    class Program
    {
        static void Main(string[] args)
        {
            Program o = new Program();
           

        }


        public void Contains()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            string fruit = "mango";

            bool hasMango = fruits.Contains(fruit);

            Console.WriteLine(
                "The array {0} contain '{1}'.",
                hasMango ? "does" : "does not",
                fruit);
        }

        public void JoinLists()
        {
            var listA = new List<Person>()
                {
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 2, FirstName = "John", LastName="Cina" },
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 3, FirstName = "Sam", LastName="Uan" }
                };

            var listB = new List<Person>()
                {
                    new Person(){PersonId = 4, FirstName = "Bill", LastName="Gates" },
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 5, FirstName = "Phill", LastName="Jacks" }
                };

            //Get unique records if ListA has duplicate records
            var listC = listA.GroupBy(i => i.PersonId).Select(g => g.First()).ToList();

            //Add ListB records to ListC
            foreach (var person in listB)
            {
                //Check if record already exists in ListC
                if (listC.Where(a => a.PersonId == person.PersonId).Count() == 0)
                {
                    listC.Add(person);
                }
            }


            foreach (var person in listC)
            {
                Console.WriteLine("PersonId = " + person.PersonId + " | FirstName = " + person.FirstName + " | LastName = " + person.LastName + "</br>");
            }
        }

        public void SkipRecords()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Skip(2);

            foreach (var str in newList)
                Console.WriteLine(str);
        }

        public void TakeRecords()
        {
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> topThreeGrades =
                grades.OrderByDescending(grade => grade).Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
        }

        public void WhereCondition()
        {


            var listA = new List<Person>()
                {
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 2, FirstName = "John", LastName="Cina" },
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 3, FirstName = "Sam", LastName="Uan" }
                };


            var result = listA.Where(x => x.PersonId == 1 && x.FirstName == "Nasser" && x.LastName == "Malik");
            foreach (var Person in result)
            {
                Console.WriteLine(Person.PersonId + "-" + Person.FirstName + "-" + Person.LastName);
            }
        }

        public void GetDuplicateRecords()
        {
            var listA = new List<Person>()
                {
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 2, FirstName = "John", LastName="Cina" },
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 3, FirstName = "Sam", LastName="Uan" }
                };

            var anyDuplicate = listA.GroupBy(x => x.FirstName).Any(g => g.Count() > 1);


            var duplicates = listA.GroupBy(s => s.FirstName)
                            .SelectMany(grp => grp.Skip(1));

            foreach (var Person in duplicates)
            {
                Console.WriteLine(Person.FirstName);
            }

        }

        public void RemoveDuplicateRecord ()
        {
            var listA = new List<Person>()
                {
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 2, FirstName = "John", LastName="Cina" },
                    new Person(){PersonId = 1, FirstName = "Nasser", LastName="Malik" },
                    new Person(){PersonId = 3, FirstName = "Sam", LastName="Uan" }
                };
            var distinctItems = listA.GroupBy(x => x.PersonId).Select(y => y.First());

            foreach (var Person in distinctItems)
            {
                Console.WriteLine(Person.FirstName);
            }

        }
    }
}

public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
