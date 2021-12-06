using NUnit.Framework;
using SimpleAPI.Shared;

namespace SimpleAPI.Tests
{
    public class Tests
    {
        private StudentDto expectedStudent;

        [SetUp]
        public void Setup()
        {
            expectedStudent = new StudentDto()
            {
                FirstName = "Nicolae",
                LastName = "Sirbu"
            };
        }

        [Test]
        public void Test1()
        {
            StudentDto testStudent = new()
            {
                FirstName = "Liza",
                LastName = "Talmaza"
            };

            Assert.IsTrue(testStudent.FirstName != expectedStudent.FirstName);
        }
    }
}