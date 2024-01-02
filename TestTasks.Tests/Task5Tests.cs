using System.Linq;
using FluentAssertions;
using TestTasks.Abstract;
using Xunit;

namespace TestTasks.Tests
{
    public class Task5Tests
    {
        [Fact]
        public void GivenSetOfHumansWithChildren__ExpectTraversalOfAllOfThem()
        {
            var ti = new TestImplementation();

            var human = new HumanWithChildren
            {
                Name = "1",
                Children = new[]
                {
                    new HumanWithChildren
                    {
                        Name = "2",
                        Children = new[]
                        {
                            new HumanWithChildren()
                            {
                                Name = "3"
                            }
                        }
                    },
                    new HumanWithChildren
                    {
                        Name = "4",
                        Children = new[]
                        {
                            new HumanWithChildren
                            {
                                Name = "5"
                            }
                        }
                    },
                    new HumanWithChildren
                    {
                        Name = "6",
                        Children = new[]
                        {
                            new HumanWithChildren
                            {
                                Name = "7"
                            }
                        }
                    }
                }
            };
            
            var result = ti.EnumAllHuman(human);

            result.Count().Should().Be(7);
        }
    }
}