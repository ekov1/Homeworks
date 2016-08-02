namespace CosmeticsTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cosmetics.Common;
    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_InputValidCommand_ShouldReturnNewCommand()
        {
            var input = "Georgi Kostov";
            var command = Command.Parse(input);

            Assert.IsInstanceOf<Command>(command);
        }

        [Test]
        public void Parse_InputValidCommand_ShouldSetTheName()
        {
            var input = "Georgi 1";
            var command = Command.Parse(input);

            Assert.AreEqual("Georgi", command.Name);
        }

        [Test]
        public void Parse_InputValidCommand_ShouldSetTheParameters()
        {
            var input = "Georgi 1 2 3 4";
            var command = Command.Parse(input);

            Assert.AreEqual(new List<string> { "1", "2", "3", "4" }, command.Parameters);
        }

        [Test]
        public void Parse_InputInValidNullInputCommand_ShouldThrowArgumentNullException()
        {
            var input = " 1 2";

            Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
        }

        [Test]
        public void Parse_InputInValidCommandWithNullParameterList_ShouldThrowArgumentNullException()
        {
            var input = "Gosho ";

            Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
        }
    }
}
