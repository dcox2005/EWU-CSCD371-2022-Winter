using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [DeploymentItem("People.csv")]
    [TestMethod]
    public void GetPath_VerifyCSVExistsInPath_Success()
    {
        Assert.IsTrue(File.Exists("People.csv"));
    }

    [TestMethod]
    public void Constructor_CreateObject_Success()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        path += "People.csv";
        _ = new SampleData(path);
    }

    private SampleData createSampleDataObject()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        path += "People.csv";
        return new SampleData(path);
    }

    [TestMethod]
    public void CsvRows_CountDataMatches50ForData_Success()
    {
        SampleData data = createSampleDataObject();
        int count = Enumerable.Count(data.CsvRows);
        Assert.AreEqual<int>(50, count);
    }

    [TestMethod]
    public void CsvRows_RetreivingDatafromCsv_LinesMatch()
    {
        SampleData data = createSampleDataObject();
        string row1 = data.CsvRows.First();
        string expectedRow1 = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        Assert.AreEqual<string>(expectedRow1, row1);

        string row37 = data.CsvRows.ElementAt(36);  //zero indexing
        string expectedRow37 = "37,Westley,Mesnard,wmesnard10@amazonaws.com,075 Pierstorff Road,Manchester,NH,66946";
        Assert.AreEqual<string>(expectedRow37, row37);

        string row50 = data.CsvRows.Last();
        string expectedLastRow = "50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930";
        Assert.AreEqual<string>(expectedLastRow, row50);
    }

    [TestMethod]
    public void Part2_MethodReturnsUniqueListOfStates_SuccessLessThan50GreaterThan0()
    {
        SampleData data = createSampleDataObject();
        IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
        int count = Enumerable.Count(states);
        Assert.IsTrue(count > 0);
        Assert.IsTrue(count < 50);
        Assert.AreEqual<int>(27, count);
    }

    [TestMethod]
    public void Part2_MethodReturnsSortedListOfStates_SuccessIsSorted()
    {
        SampleData data = createSampleDataObject();
        IEnumerable<string> states = data.GetUniqueSortedListOfStatesGivenCsvRows();
        string prevState = states.First();

        IEnumerable<string> results = states.Where
            (
                state =>
                {
                    if(state.Equals(prevState))
                    {
                        return false;
                    }

                    if (prevState.CompareTo(state) > 0)
                    {
                        return true;
                    }

                    return false;
                }
            ).ToList();

        Assert.AreEqual<int>(0, results.Count());
    }

    [TestMethod]
    public void Part3_MethodReturnsUniqueCommaSeperatedList()
    {
        SampleData data = createSampleDataObject();
        string res = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
        Assert.AreEqual<string>(res, data.GetAggregateSortedListOfStatesUsingCsvRows());
    }

    [TestMethod]
    public void Part4_PropertyImplemented_SuccessPropertyNotNull()
    {
        SampleData data = createSampleDataObject();
        Assert.IsNotNull(data.People);
    }

    [TestMethod]
    public void Part4_PeopleAreEnteredCorrectly_SuccesAllFieldsPass()
    {
        SampleData data = createSampleDataObject();
        IPerson person = data.People.
            Where(person => person.FirstName.Equals("Priscilla")).
            Single();
        Assert.AreEqual<string>("Priscilla", person.FirstName);
        Assert.AreEqual<string>("Jenyns", person.LastName);
        Assert.AreEqual<string>("pjenyns0@state.gov", person.EmailAddress);
        Assert.AreEqual<string>("MT", person.Address.State);
        Assert.AreEqual<string>("Helena", person.Address.City);
        Assert.AreEqual<string>("70577", person.Address.Zip);
        Assert.AreEqual<string>("7884 Corry Way", person.Address.StreetAddress);
    }

    [TestMethod]
    public void Part4_PeopleAreEnteredCorrectlyDifferentPerson_SuccesAllFieldsPass()
    {
        SampleData data = createSampleDataObject();
        IPerson person = data.People.
            Where(person => person.FirstName.Equals("Celestyna")).
            Single();
        Assert.AreEqual<string>("Celestyna", person.FirstName);
        Assert.AreEqual<string>("Robken", person.LastName);
        Assert.AreEqual<string>("crobken12@t.co", person.EmailAddress);
        Assert.AreEqual<string>("TX", person.Address.State);
        Assert.AreEqual<string>("San Antonio", person.Address.City);
        Assert.AreEqual<string>("74488", person.Address.Zip);
        Assert.AreEqual<string>("27 Moland Parkway", person.Address.StreetAddress);
    }

    [TestMethod]
    public void Part4_PeopleAreSortedProperly_SuccessImproperResultsZero()
    {
        SampleData data = createSampleDataObject();
        IEnumerable<IPerson> people = data.People;
        IPerson prevPerson = people.First();

        IEnumerable<IPerson> results = people.Where
            (
                person =>
                {
                    if (person.Equals(prevPerson))
                    {
                        return false;
                    }

                    if (person.Address.State.CompareTo(prevPerson.Address.State) <= 0)
                    {
                        if (person.Address.City.CompareTo(prevPerson.Address.City) <= 0)
                        {
                            if (person.Address.Zip.CompareTo(prevPerson.Address.Zip) < 0)
                            {
                                prevPerson = person;
                                return true;
                            }
                        }
                    }

                    prevPerson = person;
                    return false;
                }

            ).ToList();

        Assert.AreEqual<int>(0, results.Count());
    }

    [TestMethod]
    public void Part5_FiltersEmail_SuccessReturnsProperNames()
    {
        SampleData data = createSampleDataObject();
        Predicate<string> email = email => email.Contains("posterous");
        IEnumerable<(string FirstName, string LastName)> person1 = data.FilterByEmailAddress(email);
        Assert.AreEqual<string>("Editha", person1.First().FirstName);
        Assert.AreEqual<string>("Loseke", person1.First().LastName);
        Assert.AreEqual<string>("Editha", person1.Last().FirstName);
        Assert.AreEqual<string>("Loseke", person1.Last().LastName);

        email = email => email.Contains("cbsnews");
        IEnumerable<(string FirstName, string LastName)> person2 = data.FilterByEmailAddress(email);
        Assert.AreEqual<string>("Jedd", person2.First().FirstName);
        Assert.AreEqual<string>("Boissier", person2.First().LastName);
        Assert.AreEqual<string>("Jedd", person2.Last().FirstName);
        Assert.AreEqual<string>("Boissier", person2.Last().LastName);

        email = email => email.Contains("@c");
        IEnumerable<(string FirstName, string LastName)> people = data.FilterByEmailAddress(email);
        Assert.AreEqual<int>(4, people.Count());
        Assert.AreEqual<string>("Jedd", people.First().FirstName);
        Assert.AreEqual<string>("Boissier", people.First().LastName);
        Assert.AreEqual<string>("Gabrielle", people.ElementAt(1).FirstName);
        Assert.AreEqual<string>("Vitler", people.ElementAt(1).LastName);
        Assert.AreEqual<string>("Scarface", people.ElementAt(2).FirstName);
        Assert.AreEqual<string>("Dennington", people.ElementAt(2).LastName);
        Assert.AreEqual<string>("Claudell", people.Last().FirstName);
        Assert.AreEqual<string>("Leathe", people.Last().LastName);
    }

    [TestMethod]
    public void Part6_MethodeReturnsUniqueList_SuccesListMatches()
    {
        SampleData data = createSampleDataObject();
        string expectedList = data.GetAggregateSortedListOfStatesUsingCsvRows();
        IEnumerable<IPerson> people = data.People;
        string resultingList = data.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.AreEqual<string>(expectedList, resultingList);
    }
}