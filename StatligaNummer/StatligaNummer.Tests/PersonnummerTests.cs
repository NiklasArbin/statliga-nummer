using FluentAssertions;
using NUnit.Framework;

namespace StatligaNummer.Tests
{
    [TestFixture]
    public class PersonnummerTests
    {
        [Test]
        public void Should_parse_valid_personnummer_without_century()
        {
            var pnr = "811218-9876";

            var personNummer = new Personnummer(pnr);
            personNummer.IsValid().Should().BeTrue();
            personNummer.Year.Should().Be(79);
            personNummer.Month.Should().Be(8);
            personNummer.Day.Should().Be(2);
            personNummer.Födelsenummer.Should().Be(31);
            personNummer.Kontrollsiffra.Should().Be(1);
            
        }
    }
}
