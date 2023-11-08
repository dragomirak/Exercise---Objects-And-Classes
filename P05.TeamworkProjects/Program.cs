using System.Diagnostics.Metrics;

namespace P05.TeamworkProjects
{
    public class Team
    {
        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }

        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
            Members = new List<string>();
        }

        public override string ToString()
        {
            return $"{TeamName}\n" +
                    $"- {CreatorName}\n" +
                    $"{GetMembersString()}";
        }

        public string GetMembersString()
        {
            Members = Members.OrderBy(name => name).ToList();
            string result = string.Empty;

            for (int i = 0; i < Members.Count - 1; i++)
            {
                result += $"-- {Members[i]}\n";
            }

            result += $"-- {Members[Members.Count - 1]}";
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-");
                string teamCreator = teamInfo[0];
                string teamName = teamInfo[1];

                Team team = new Team(teamName, teamCreator);
                Team sameTeamFound = teams.Find(t => t.TeamName == team.TeamName);

                if (sameTeamFound != null)
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                    continue;
                }

                Team sameCreatorFound = teams.Find(t => t.CreatorName == team.CreatorName);

                if (sameCreatorFound != null)
                {
                    Console.WriteLine($"{team.CreatorName} cannot create another team!");
                    continue;
                }

                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] membersInfo = command.Split("->");
                string memberName = membersInfo[0];
                string teamName = membersInfo[1];

                bool hasAnyTeamWithSameName = teams.Any(t => t.TeamName == teamName);

                if (hasAnyTeamWithSameName == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(team => team.CreatorName == memberName) ||
                    teams.Any(team => team.Members.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                Team t = teams.Find(t => t.TeamName == teamName);
                if (t != null)
                {
                    t.Members.Add(memberName);
                }
            }

            List<Team> leftTeams = teams.Where(t => t.Members.Count > 0).ToList();
            List<Team> orderedTeams = leftTeams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            orderedTeams.ForEach(team => Console.WriteLine(team));

            Console.WriteLine("Teams to disband:");
            List<Team> disbandTeams = teams.Where(t => t.Members.Count == 0).ToList();
            List<Team> orderedDisbandTeams = disbandTeams.OrderBy(t => t.TeamName).ToList();

            orderedDisbandTeams.ForEach(team => Console.WriteLine($"{team.TeamName}"));
        }
    }
}