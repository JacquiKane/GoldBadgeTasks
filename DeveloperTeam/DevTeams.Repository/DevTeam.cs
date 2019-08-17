using System;
using System.Collections.Generic;

namespace DevTeams.Repository
{
    public class DevTeam
    {
        private readonly List<Developer> _developerList;
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public DevTeam() {
            _developerList = new List<Developer>();
        }
        public DevTeam(int teamID, string teamName) {
            TeamName = teamName;
            TeamID = teamID;
            _developerList = new List<Developer>();
        }
        public bool AddMember(Developer newDev) {
            int count = _developerList.Count;
            _developerList.Add(newDev);
            if (count < _developerList.Count)
                return true;
            else
                return false;

        }





        public Developer addMember() {
            Console.WriteLine("Hope you have the detail ready for adding a new team member!");
            Developer newDev = new Developer();

            Console.WriteLine("Please enter the developer id: ");
            string devIDAsStr = Console.ReadLine();
            int devID = int.Parse(devIDAsStr);

            Console.WriteLine("Please enter the developer last name: ");
            string devLastName = Console.ReadLine();

            Console.WriteLine("Does the developer have a PluralSight account, [Y]es or [N]o?: ");
            string hasPSAsStr = Console.ReadLine().ToLower();
            bool hasPS = (hasPSAsStr == "y") ? true : false;

            newDev.ID = devID;
            newDev.LastName = devLastName;
            newDev.HasPluralSight = hasPS;

            _developerList.Add(newDev);
            return newDev;


        }
        public bool RemoveMember(int ID) {
            int origCount = _developerList.Count;
            foreach (Developer dev in _developerList) {
                if (dev.ID == ID)
                    _developerList.Remove(dev);
            }

            if (_developerList.Count < origCount)
                return true;
            else
                return false;

        }

        public List<Developer> allDevelopersOnTeam() {
            return _developerList;
        }

    }
}
