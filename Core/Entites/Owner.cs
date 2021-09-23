namespace Core.Entites
{
    public class Owner : EntityBase
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string Avatar { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Resume { get; set; }
        public Address Address { get; set; }
    }
}
