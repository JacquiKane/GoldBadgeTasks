namespace DevTeams.Repository
{
    public class Developer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public bool HasPluralSight { get; set; }

        public Developer() {

        }

        public Developer(int devID, string devLastName, bool hasPS) {
            ID = devID;
            LastName = devLastName;
            HasPluralSight = hasPS;
        }
    }
}
