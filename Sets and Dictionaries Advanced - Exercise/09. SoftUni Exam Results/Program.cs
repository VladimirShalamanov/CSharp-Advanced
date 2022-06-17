using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contest = new Dictionary<string, Dictionary<string, int>>();
            var counterLanguage = new Dictionary<string, int>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "exam finished")
            {
                string[] arr = cmd.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string name = arr[0];

                if (arr.Length == 2 && arr[1] == "banned")
                {
                    if (contest.ContainsKey(name))
                        contest.Remove(name);
                }
                else if (arr.Length == 3)
                {
                    string language = arr[1];
                    int poitns = int.Parse(arr[2]);

                    if (!contest.ContainsKey(name))
                    {
                        contest[name] = new Dictionary<string, int>();
                        contest[name].Add(language, poitns);

                        if (!counterLanguage.ContainsKey(language))
                            counterLanguage.Add(language, 1);
                        else if (counterLanguage.ContainsKey(language))
                            counterLanguage[language]++;
                    }
                    else if (!contest[name].ContainsKey(language))
                    {
                        contest[name] = new Dictionary<string, int>();
                        contest[name].Add(language, poitns);

                        if (!counterLanguage.ContainsKey(language))
                            counterLanguage.Add(language, 1);
                        else if (counterLanguage.ContainsKey(language))
                            counterLanguage[language]++;
                    }
                    else if (contest[name].ContainsKey(language))
                    {
                        counterLanguage[language]++;
                        if (contest[name][language] < poitns)
                            contest[name][language] = poitns;
                    }
                }
            }

            Console.WriteLine("Results:");
            var total = new Dictionary<string, int>();
            foreach (var rtd in contest)
            {
                total[rtd.Key] = 0;
                foreach (var item in rtd.Value)
                {
                    total[rtd.Key] = item.Value;
                }
            }
            foreach (var racer in total.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{racer.Key} | {racer.Value}");

            }
            Console.WriteLine("Submissions:");
            foreach (var launguage in counterLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{launguage.Key} - {launguage.Value}");
            }
        }
    }
}
