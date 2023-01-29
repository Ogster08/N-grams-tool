using System;
using System.IO;
namespace N_grams_tool
{
	class Program
	{
		public static void Main(string[] Args)
		{
            int n = 2;
			string baseText = File.ReadAllText("text.txt");
			string text = new string(baseText.Where(char.IsLetter).ToArray()).ToLower();
			string[] seperatedText = text.TakeEvery(n).ToArray();

            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            foreach (var pair in seperatedText)
            {
                if (frequencies.ContainsKey(pair)) { frequencies[pair] += 1; }
                else { frequencies[pair] = 1; }
            }

            var sorted = from entry in frequencies orderby entry.Value descending select entry;

            foreach (KeyValuePair<string, int> kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}, {kvp.Value}");
            }
        }
	}

    public static class StringExtensions
    {
        public static IEnumerable<string> TakeEvery(this string s, int count)
        {
            int index = 0;
            while (index < s.Length)
            {
                if (s.Length - index >= count)
                {
                    yield return s.Substring(index, count);
                }
                else
                {
                    yield return s.Substring(index, s.Length - index);
                }
                index += count;
            }
        }
    }
}