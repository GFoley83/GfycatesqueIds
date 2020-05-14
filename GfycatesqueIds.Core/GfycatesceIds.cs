using System;
using System.Text;

namespace GfycatesqueIds
{
    public enum WordType
    {
        Adjective,
        Verb,
        Animal
    }

    /// <summary>
    /// Generate human readable Ids, just like Gfycat links
    /// </summary>
    public static class GfycatesceIds
    {
        private static readonly Random _rnd = new Random();
        /// <summary>
        /// Default pattern is:
        /// <code>VerbAdjectiveAnimal</code>
        /// E.g. <code>WordType[] DefaultPattern = { WordType.Verb, WordType.Adjective, WordType.Animal };</code>
        /// </summary>
        public static readonly WordType[] DefaultPattern = { WordType.Verb, WordType.Adjective, WordType.Animal };

        /// <summary>
        /// Use the same pattern as Gfycat:
        /// <code>AdjectiveAdjectiveAnimal</code>
        /// E.g.<code>ExaltedDifficultAntelope</code>
        /// </summary>
        public static readonly WordType[] GfycatPattern = { WordType.Adjective, WordType.Adjective, WordType.Animal };

        /// <summary>
        /// Default behavior returns an ID in the format: <code>VerbAdjectiveAnimal</code>
        /// <para>E.g.
        /// <code>ScratchCarefreeLion</code></para>
        /// <para>Override "pattern" param to customise order and/or number of words to generate.</para>
        /// </summary>
        /// <param name="pattern">Defaults to "DefaultPattern" which is: <code>VerbAdjectiveAnimal</code></param>
        /// <returns></returns>
        public static string Generate(WordType[] pattern = null)
        {
            if (pattern == null || pattern.Length == 0)
            {
                pattern = DefaultPattern;
            }

            var idBuilder = new StringBuilder();

            foreach (var wordType in pattern)
            {
                switch (wordType)
                {
                    case WordType.Adjective:
                        idBuilder.Append(Words.Adjectives[_rnd.Next(Words.Adjectives.Length)]);
                        break;
                    case WordType.Verb:
                        idBuilder.Append(Words.Verbs[_rnd.Next(Words.Verbs.Length)]);
                        break;
                    case WordType.Animal:
                        idBuilder.Append(Words.Animals[_rnd.Next(Words.Animals.Length)]);
                        break;
                }
            }

            return idBuilder.ToString();
        }
    }
}
