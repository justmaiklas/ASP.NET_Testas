using Xunit;
using FluentAssertions;

namespace GalPavyks.Tests.MainTests
{
    public class MainTest
    {
        [Theory]
        [InlineData(1,1)]
        public void PersonExits(int number, int expected)
        {
            number.Should().Be(expected);
        }
    }
}


