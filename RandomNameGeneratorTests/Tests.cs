using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RandomNameGenerator;

namespace RandomNameGeneratorTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ShouldGenerateLastName()
        {
            var lastName = NameGenerator.GenerateLastName();
            Assert.AreEqual(string.IsNullOrEmpty(lastName), false);
        }

        [Test]
        public void ShouldGenerateFirstName()
        {
            var firstName = NameGenerator.GenerateFirstName(Gender.Male);
            Assert.AreEqual(string.IsNullOrEmpty(firstName), false);

            firstName = NameGenerator.GenerateFirstName(Gender.Female);
            Assert.AreEqual(string.IsNullOrEmpty(firstName), false);
        }

        [Test]
        public void ShouldGenerateFullName()
        {
            var fullName = NameGenerator.Generate(Gender.Male);
            Assert.AreEqual(string.IsNullOrEmpty(fullName), false);

            fullName = NameGenerator.Generate(Gender.Female);
            Assert.AreEqual(string.IsNullOrEmpty(fullName), false);
        }
    }
}
