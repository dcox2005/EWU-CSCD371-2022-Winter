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
        }    

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
            states.ToArray();
            return string.Join(",", states);
        }

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