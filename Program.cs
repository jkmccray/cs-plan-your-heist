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

        // Get next team member's name
        Console.Write("Name> ");
        name = Console.ReadLine();
      }

      Console.WriteLine($"Team Size: {team.Count}");
      Console.WriteLine("Team Members");

      foreach (Dictionary<string, string> member in team)
      {
        Console.WriteLine("------------------------------------");
        //   Console.WriteLine($"Name: {member["Name"]}");
        //   Console.WriteLine($"Skill: {member["SkillLevel"]}");
        //   Console.WriteLine($"Courage: {member["CourageFactor"]}");
        foreach (KeyValuePair<string, string> kvp in member)
        {
          Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
      }
    }
  }
}
