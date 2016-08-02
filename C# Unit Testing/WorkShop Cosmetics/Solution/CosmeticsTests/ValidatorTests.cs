namespace CosmeticsTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_InputNullObject_ShouldThrowNullReferenceException()
        {
            var message = "Cannot be null!";
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null, message));
        }

        [Test]
        public void CheckIfNull_InputValidObject_ShouldReturnValidObject()
        {
            var obj = 5;
            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_InputEmptyString_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(""));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_InputValidString_ShouldReturnValidString()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("something"));
        }

        [Test]
        public void CheckIfStringLengthIsValid_InputStringWithMoreThanMaxLength_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid("too long", 5));
        }

        [Test]
        public void CheckIfStringLengthIsValid_InputStringWithLengthWithinRange_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("too long", 20));
        }
    }
}
