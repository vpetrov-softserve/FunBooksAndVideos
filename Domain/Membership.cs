namespace Domain
{
    public class Membership : ProductDetails
    {
        public bool IsActivated { get; set; }

        public MembershipType MembershipType {get; set;}
    }

    public enum MembershipType
    {
        BookClub = 1,
        VideoClub = 2,
        Premium = 3
    }
}