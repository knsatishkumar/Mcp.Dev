using System;
using LoginValidationLibrary;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LoginValidationTests.Steps
{
    [Binding]
    public class PasswordValidationSteps
    {
        private PasswordValidator _validator;
        private bool _validationResult;
        
        [Given(@"a password validator")]
        public void GivenAPasswordValidator()
        {
            _validator = new PasswordValidator();
        }

        [When(@"I validate the password ""(.*)""")]
        public void WhenIValidateThePassword(string password)
        {
            _validationResult = _validator.ValidatePassword(password);
        }

        [Then(@"the result should be valid")]
        public void ThenTheResultShouldBeValid()
        {
            Assert.IsTrue(_validationResult);
        }

        [Then(@"the result should be invalid")]
        public void ThenTheResultShouldBeInvalid()
        {
            Assert.IsFalse(_validationResult);
        }
    }
}