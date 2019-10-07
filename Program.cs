using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            List<Dictionary<string, string>> team = new List<Dictionary<string, string>>();

            Console.Write("Bank Difficulty> ");
            int bankDifficulty = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Get first team member's name
            Console.Write("Name> ");
            string name = Console.ReadLine();

            while (name != "")
            {
                Console.Write("Skill level> ");
                string skillLevel = Console.ReadLine();

                Console.Write("Courage factor> ");
                string courageFactor = Console.ReadLine();

                Dictionary<string, string> member = new Dictionary<string, string>() {
                {"Name", name},
                {"SkillLevel", skillLevel},
                {"CourageFactor", courageFactor}
            };
                team.Add(member);

                Console.WriteLine();

                // Get next team member's name
                Console.Write("Name> ");
                name = Console.ReadLine();
            }

            Console.WriteLine($"Team Size: {team.Count}");

            Console.WriteLine();
            Console.WriteLine("Enter number of trial runs>");
            int trialRunCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Determine total skill level of the team and compare it to the bank's difficulty level
            int teamSkill = 0;

            foreach (Dictionary<string, string> member in team)
            {
                string skillLevel = member["SkillLevel"];
                teamSkill = teamSkill + int.Parse(skillLevel);
            }

            Dictionary<string, int> report = new Dictionary<string, int>(){
              {"Successes", 0},
              {"Failures", 0}
            };

            for (int i = 0; i < trialRunCount; i++)
            {
                // Create a random number between -10 and 10 for the heist's luck value. Add this number to the bank's difficulty level.
                Random generator = new Random();
                int luckValue = generator.Next(-10, 11);
                int trialRunBankDifficulty = bankDifficulty + luckValue;

                Console.WriteLine($"Team Skill Level: {teamSkill}");
                Console.WriteLine($"Bank Difficulty Level: {trialRunBankDifficulty}");

                if (trialRunBankDifficulty > teamSkill)
                {
                    // Console.WriteLine("Your heist will fail");
                    report["Failures"] += 1;
                }
                else
                {
                    // Console.WriteLine("Your heist will succeed");
                    report["Successes"] += 1;
                }

                Console.WriteLine("---------------------------");
            }

            Console.WriteLine("Heist Results:");
            foreach (KeyValuePair<string, int> kvp in report)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine("---------------------------");

            // To display team member info:
            // Console.WriteLine("Team Members");
            // foreach (Dictionary<string, string> member in team)
            // {
            //   Console.WriteLine("------------------------------------");
            //   foreach (KeyValuePair<string, string> kvp in member)
            //   {
            //     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            //   }
            // }
        }
    }
}
