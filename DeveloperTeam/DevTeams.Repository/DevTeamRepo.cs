using System.Collections.Generic;

namespace DevTeams.Repository
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _listOfDevTeams;

        public DevTeamRepo() {
            _listOfDevTeams = new List<DevTeam>();
        }

        public List<DevTeam> GetAllDevTeams() {
            return _listOfDevTeams;
        }

        public List<DevTeam> AllTeamsAsList()
        {
            return _listOfDevTeams;
        }

        public DevTeam GetTeamByID(int devTeamID) {
            foreach (DevTeam devTeam in _listOfDevTeams)
                if (devTeam.TeamID == devTeamID)
                    return devTeam;
              
                return null;
        }

        public void AddTeam(DevTeam team) {
            _listOfDevTeams.Add(team);
        }


        // From other class
        public void CreateNewDeveloperForTeamID(int teamID, Developer dev)
        {

            foreach (DevTeam team in _listOfDevTeams)
            {
                if (team.TeamID == teamID)
                    team.AddMember(dev);
            }
        }

    }
}
