using System;
using Xunit;
using TextAndIOHandling;

namespace TextAndIOHandling.Test
{
    public class EmailValidatorTest
    {
        [Fact]
        public void Validate_should_return_false_when_input_is_empty_string()
        {
            var testEmail = "";
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.False(valid);
        }

        [Fact]
        public void Validate_should_return_true_when_email_addres_is_correct()
        {
            var testEmail = "goodemail@test.org";
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.True(valid);
        }

        [Theory]
        [InlineData("abc-@mail.com", false)]
        [InlineData("abc-d@mail.com", true)]
        [InlineData("abc..def@mail.com", false)]
        [InlineData("abc.def@mail.com", true)]
        [InlineData(".abc@mail.com", false)]
        [InlineData("abc@mail.com", true)]
        public void An_underscore_period_or_dash_must_be_followed_by_one_or_more_letter_or_number(string testEmail, bool expected)
        {
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.Equal(expected, valid);
        }

        [Theory]
        [InlineData("abc@mail", false)]
        [InlineData("abc@mail.c", false)]
        [InlineData("abc@mail.com", true)]
        public void The_last_portion_of_the_domain_must_be_at_least_two_characters(string testEmail, bool expected)
        {
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.Equal(expected, valid);
        }

        [Theory]
        [InlineData("abc@mai#l.com", false)]
        [InlineData("abc.def@mail-archive.com", true)]
        [InlineData("abc.def@mail..com", false)]
        public void Domain_allowed_characters_letters_numbers_dashes(string testEmail, bool expected)
        {
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.Equal(expected, valid);
        }

        [Theory]
        [InlineData("abc#def@mail.com", false)]
        [InlineData("abc_def@mail.com", true)]
        [InlineData("abc-d@mail.com", true)]
        public void Prefix_allowed_characters_letters_numbers_underscores_periods_and_dashes(string testEmail, bool expected)
        {
            var validator = new EmailValidator();

            var valid = validator.Validate(testEmail);

            Assert.Equal(expected, valid);
        }


    }
}
