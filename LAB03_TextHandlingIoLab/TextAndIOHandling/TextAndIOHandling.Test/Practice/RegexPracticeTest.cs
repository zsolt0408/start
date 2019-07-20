using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAndIOHandling.Practice;
using Xunit;

namespace TextAndIOHandling.Test.Practice
{
    public class RegexPracticeTest
    {
        [Theory]
        [InlineData("Hello World", true)]
        [InlineData("World", false)]
        [InlineData("Between Hello Words", true)]
        [InlineData("PartOfHelloWord", true)]
        public void IsHelloInSentence_should_return_true_if_hello_is_in_sentence(string sentence, bool expected)
        {
            var regexMatcher = new RegexPractice();

            var match = regexMatcher.IsHelloInSentence(sentence);

            Assert.Equal(expected, match);
        }

        [Theory]
        [InlineData("Hello World", true)]
        [InlineData("# World", false)]
        [InlineData("Guten Tag", true)]
        [InlineData("#Hello", false)]
        [InlineData("Between#Hello", false)]
        public void IsNotContainHashmark_should_return_false_if_sentece_contains_hashmark(string sentence, bool expected)
        {
            var regexMatcher = new RegexPractice();

            var match = regexMatcher.IsNotContainHashmark(sentence);

            Assert.Equal(expected, match);
        }

        [Theory]
        [InlineData("Hello World", true)]
        [InlineData("# World", true)]
        [InlineData("Guten Tag", false)]
        [InlineData("Hetlo Word", false)]
        [InlineData("Between#Hello", true)]
        public void IsContainsHelloOrWorld_should_return_true_if_sentece_contains_hello_or_world(string sentence, bool expected)
        {
            var regexMatcher = new RegexPractice();

            var match = regexMatcher.IsContainsHelloOrWorld(sentence);

            Assert.Equal(expected, match);
        }

        [Theory]
        [InlineData("HelloWorld", true)]
        [InlineData("#World", false)]
        [InlineData("GutenTag123", true)]
        [InlineData("thequickbrownfoxjumpsoverthelazydog", true)]
        [InlineData("THEQUICKBROWNFOXJUMPSOVERTHELAZYDOG", true)]
        [InlineData("0123456789", true)]
        [InlineData("Between.Hello", false)]
        [InlineData("Between-Hello", false)]
        public void IsAlphaNumeric_should_return_false_if_sentece_contains_not_alphanumeric_character(string sentence, bool expected)
        {
            var regexMatcher = new RegexPractice();

            var match = regexMatcher.IsAlphaNumeric(sentence);

            Assert.Equal(expected, match);
        }
    }
}
