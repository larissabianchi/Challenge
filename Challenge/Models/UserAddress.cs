namespace Challenge.Models
{
    public class UserAddress
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public List<UserAddressGeo> Geo { get; set; }
    }
}
