namespace Domain
{
    public class UsersMemberships
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        public Membership Membership { get; set; }

        public bool IsActivated { get; set; }

        public Order Order { get; set; }
    }
}