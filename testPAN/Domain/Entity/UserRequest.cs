namespace testPAN.Domain.Entity
{
    public class UserRequest
    {
        public int id { get; set; }
        public int pan { get; set; }

        public int user_id { get; set; }

        public User user;

    }
}
