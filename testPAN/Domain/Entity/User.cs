namespace testPAN.Domain.Entity
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }

        public List<UserRequest> requests { get; set; } = new List<UserRequest>();

    }
}
