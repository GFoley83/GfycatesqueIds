using System;

namespace GfycatesqueIds.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GfycatesceIds.Generate(GfycatesceIds.GfycatPattern));

            var id = GfycatesceIds.Generate(new[]
            {
                WordType.Adjective, WordType.Verb, WordType.Verb, WordType.Animal
            });

            Console.WriteLine(id);


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(GfycatesceIds.Generate());
            }

            Console.ReadLine();
        }
    }
}
