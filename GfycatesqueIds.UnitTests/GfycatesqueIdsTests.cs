using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GfycatesqueIds.UnitTests
{
    public class GfycatesqueIdsTests
    {
        [Test]
        public void ShouldGenerateAnId()
        {
            var id = GfycatesceIds.Generate();
            Assert.IsNotEmpty(id);
        }

        [Test]
        public void ShouldGenerateAnIdWithExpectedWordCountByDefault()
        {
            var id = GfycatesceIds.Generate();
            var words = SplitCamelCase(id);
            Assert.AreEqual(words.Count(), GfycatesceIds.DefaultPattern.Length);
        }

        [Test]
        public void ShouldGenerateAnIdInTheDefaultFormatByDefault()
        {
            var id = GfycatesceIds.Generate();
            var words = SplitCamelCase(id);

            for (int i = 0; i < GfycatesceIds.DefaultPattern.Length; i++)
            {
                Assert.IsTrue(Words.WordIsInWordList(words[i], GfycatesceIds.DefaultPattern[i]));
            }
        }

        [Test]
        public void ShouldGenerateAnIdWithGfycatFormat()
        {
            var id = GfycatesceIds.Generate(GfycatesceIds.GfycatPattern);
            var words = SplitCamelCase(id);

            for (int i = 0; i < GfycatesceIds.GfycatPattern.Length; i++)
            {
                Assert.IsTrue(Words.WordIsInWordList(words[i], GfycatesceIds.GfycatPattern[i]));
            }
        }

        [Test]
        [TestCase(new[] { WordType.Adjective, WordType.Adjective, WordType.Adjective, WordType.Animal })]
        [TestCase(new[] { WordType.Animal, WordType.Verb, WordType.Adjective })]
        public void ShouldGenerateAnIdWithCustomFormat(WordType[] pattern)
        {
            var id = GfycatesceIds.Generate(pattern);
            var words = SplitCamelCase(id);

            for (int i = 0; i < pattern.Length; i++)
            {
                Assert.IsTrue(Words.WordIsInWordList(words[i], pattern[i]));
            }
        }

        [Test]
        [TestCase(500)]
        public void ShouldGenerateUniqueIds(int numIdsToGenerate)
        {
            var ids = new HashSet<string>();
            for (var i = 0; i < numIdsToGenerate; i++)
            {
                ids.Add(GfycatesceIds.Generate());
            }

            Assert.AreEqual(ids.Count, numIdsToGenerate);
        }

        private string[] SplitCamelCase(string source) => Regex.Split(source, @"(?<!^)(?=[A-Z])");
    }
}