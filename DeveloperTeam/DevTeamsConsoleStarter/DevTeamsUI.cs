using DevTeams.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace DevTeamsConsoleStarter
{
    class DevTeamsUI
    {
        internal DevTeamRepo _allDevTeams;

        public void Run()
        {
            _allDevTeams = new DevTeamRepo();
            Console.WriteLine("Teams Management 101");
            Seedney();

            bool keepGoing = true;
            while (keepGoing)
            {
                // set up a user menu
                Console.WriteLine("1 - Create a new team\n" +
                              "2 - Create a new Developer (and add to team)\n" +
                              "3 - Delete a team by ID\n" +
                              "4 - Delete a team member by team id and member id\n" +
                              "5 - See all teams by name and id\n" + 
                              "6 - See all team members in team, of id\n" +
                              "7 - Quit\n");
                        

            string userResponse = Console.ReadLine();
            
                switch (userResponse)
                {
                    case "1":
                        CreateNewTeam();
                        break;
                    case "2":
                        CreateNewDeveloperForTeamID();
                        break;
                    case "3":
                        deleteTeamById();
                        break;
                    case "4":
                        deleteDev();
                        break;
                    case "5":
                        displayAllTeamsByIdAndName();
                        break;
                    case "6":
                        displayAllMembersOnTeamWithID();
                        break;
                    case "7":
                        keepGoing = false;
                        break;
                    default:
                        break;
                }

            }
        }

        public void deleteTeamById() {
            Console.WriteLine("What Team id:");
            string teamIdAsString = Console.ReadLine();
            int teamID = int.Parse(teamIdAsString);
            DevTeam targetTeam = findTeamInRepoById(teamID);
            _allDevTeams.AllTeamsAsList().Remove(targetTeam);

        }


        public DevTeam findTeamInRepoById(int teamID) {
            bool found = false;
            List<DevTeam> allTeams = _allDevTeams.AllTeamsAsList();
            bool foundTeam = false;
            int index = 0;
            DevTeam targetTeam = null;
            while ((!(foundTeam)) && (index < allTeams.Count))
            {
                DevTeam currentTeam = allTeams[index];
                Console.WriteLine(currentTeam.TeamName);
                if (currentTeam.TeamID == teamID)
                {
                    foundTeam = true;
                    targetTeam = currentTeam;
                }
                index++;
            }
            return targetTeam;
        }


        public void deleteDev()
        {
            Console.WriteLine("Enter team id:");
            string teamAsString = Console.ReadLine();
            int teamAsInt = int.Parse(teamAsString);
            Console.WriteLine("Enter Dev id:");
            string devAsString = Console.ReadLine();
            int devAsInt = int.Parse(devAsString);
            deleteDevByTeamIdAndDevId(teamAsInt, devAsInt);

        }
        public void deleteDevByTeamIdAndDevId(int teamID, int devID) {
            DevTeam devTeam = findTeamInRepoById(teamID);
            if (!(devTeam == null)) {
                bool success = deleteDevById(devTeam, devID);
            }
        }


        public bool deleteDevById(DevTeam devTeam, int devID) {
            bool success = false;
            List<Developer> devsOnTeam = devTeam.allDevelopersOnTeam();
            int index = 0;

            while (success == false && index < devsOnTeam.Count)
            {
                if (devsOnTeam[index].ID == devID)
                {
                    devsOnTeam.Remove(devsOnTeam[index]);
                    success = true;
                }
                index += 1;
            }
            return success;
        }
        public void displayAllMembersOnTeamWithID() {
            Console.WriteLine("What Team id: ");
            string teamIdAsString = Console.ReadLine();
            int teamID = int.Parse(teamIdAsString);

            DevTeam targetTeam = findTeamInRepoById(teamID);

            if (!(targetTeam == null)) {
                DisplayTeamMembers(targetTeam);
            }
        }
      public void CreateNewDeveloperForTeamID() {
            displayAllTeamsByIdAndName();
            Console.WriteLine("Enter team to add developer to:");
            string teamIdAsString = Console.ReadLine();
            int teamID = int.Parse(teamIdAsString);
            Developer dev = CreateNewDeveloper();

            _allDevTeams.CreateNewDeveloperForTeamID(teamID, dev);
        }

       
        public void CreateNewTeam() {
         
            Console.WriteLine("Team name:");
            string teamName = Console.ReadLine();
            Console.WriteLine("Team ID:");
            string teamIDAsString = Console.ReadLine();
            int teamID = int.Parse(teamIDAsString);
            DevTeam devTeam = new DevTeam(teamID, teamName);

            _allDevTeams.AddTeam(devTeam);
        }

        public Developer CreateNewDeveloper()
        {
            Console.WriteLine("Developer name:");
            string teamName = Console.ReadLine();
            Console.WriteLine("Developer ID:");
            string devIDAsString = Console.ReadLine();
            int teamID = int.Parse(devIDAsString);
            Developer dev = new Developer(teamID, teamName, true);
            return dev;
        }

        public void displayAllTeamsByIdAndName()
        {
            List<DevTeam> teams = _allDevTeams.AllTeamsAsList();
            foreach (DevTeam team in teams)
            {
                Console.WriteLine($"Team Name : {team.TeamName} with ID : {team.TeamID}\n");
            }
        }

        public void DisplayTeamMembers(DevTeam team) {
            List <Developer> allDevs = team.allDevelopersOnTeam();
            foreach (Developer dev in allDevs) {
                Console.WriteLine($"First: {dev.LastName} has ID: {dev.ID}");

            }
        }

        public void Seedney() {
            int teamIndex = 101;
            Console.WriteLine(_allDevTeams);
            List<DevTeam> allTeams = _allDevTeams.AllTeamsAsList();
            while (teamIndex < 105)
            {
                DevTeam team = new DevTeam(teamIndex, $"Team Number{teamIndex}");
                int devIndex = 300;
                bool hasPS;
                while (devIndex < 310)
                {
                    hasPS = ((devIndex % 2) == 0) ? true : false;
                    Developer dev = new Developer(devIndex, $"Janie {devIndex}", hasPS);
                    team.AddMember(dev);
                    devIndex++;
                }
                allTeams.Add(team);
                teamIndex++;
            }
        }
    }
}

