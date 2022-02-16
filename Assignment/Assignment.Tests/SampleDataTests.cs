using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        int count = System.Linq.Enumerable.Count(data.CsvRows);
        Assert.AreEqual(50, count);
    }

    [TestMethod]
    public void CsvRows_RetreivingDatafromCsv_LinesMatch()
    {
        SampleData data = createSampleDataObject();
        string row1 = data.CsvRows.First();
        string expectedRow1 = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        Assert.AreEqual(expectedRow1, row1);
        
        string row37 = data.CsvRows.ElementAt(36);  //zero indexing
        string expectedRow37 = "37,Westley,Mesnard,wmesnard10@amazonaws.com,075 Pierstorff Road,Manchester,NH,66946";
        Assert.AreEqual(expectedRow37, row37);

        string row50 = data.CsvRows.Last();
        string expectedLastRow = "50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930";
        Assert.AreEqual(expectedLastRow, row50);
    }
}