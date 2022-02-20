using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        // 1.
        public IEnumerable<string> CsvRows { get; }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = CsvRows.
                Select(person => person.Split(',')[6]).
                Distinct().
                OrderBy(state => state).
                ToList();

            return states;
            //ask preference on where the . belongs on the above. end of row or beginning.
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
            states.ToArray();
            return string.Join(",", states);
        }

        // 4.
        public IEnumerable<IPerson> People { get; private set; }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            List<IPerson> persons = People.ToList();
            IEnumerable<(string FirstName, string LastName)> results = People.ToList().
                FindAll(person => filter(person.EmailAddress)).
                Select(person => (person.FirstName, person.LastName));

            return results;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
       
        public SampleData(string path)
        {
            CsvRows = CSVParser(path);
            People = setPeople();
        }

        private IEnumerable<string> CSVParser(string path)
        {
            return File.ReadAllLines(path).Skip(1);
        }

        private IEnumerable<IPerson> setPeople()
        {
            IEnumerable<IPerson> people = CsvRows.
                OrderBy(place => place.Split(",")[6]).  //state
                ThenBy(place => place.Split(",")[5]).   //city
                ThenBy(place => place.Split(",")[7]).   //zip
                Select(person => new Person
                    (
                        person.Split(",")[1],           //first name
                        person.Split(",")[2],           //last name
                        new Address
                        (
                            person.Split(",")[4],       //street
                            person.Split(",")[5],       //city
                            person.Split(",")[6],       //state
                            person.Split(",")[7]),      //zip
                        person.Split(",")[3])           //email
                    );

            return people;
        }
    }
}