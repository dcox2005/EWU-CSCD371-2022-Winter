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
            List<string> states = new List<string>();
            foreach (string person in CsvRows)
            {
                states.Add(person.Split(",")[6]);
            }
            //states.Sort();
            IEnumerable<string> uniqueStates = states.Distinct();
            return uniqueStates;
        }    

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
       
        public SampleData(string path)
        {
            CsvRows = CSVParser(path);
        }

        private IEnumerable<string> CSVParser(string path)
        {
            return File.ReadAllLines(path).Skip(1);
        }
    }
}