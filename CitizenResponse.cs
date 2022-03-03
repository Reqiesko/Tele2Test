namespace TeleTest
{
    public class CitizenResponse
    {
        public List<Citizen> Сitizens { get; set; } = new List<Citizen>();

        public int Pages { get; set; }

        public int CurrentPages { get; set; }
    }
}
