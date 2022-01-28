using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Student_AssignGrade_Success()
    {
        Student student = new("Princess Buttercup");
        student.Grade = Grade.A;
        Assert.AreEqual <Grade>(Grade.A, student.Grade);
    }

    [TestMethod]
    public void Student_AssignInteger42_Success()
    {
        Student student = new("Princess Buttercup");
        student.Grade = (Grade)2;
        Assert.AreEqual<Grade>(Grade.A, student.Grade);
    }
}
