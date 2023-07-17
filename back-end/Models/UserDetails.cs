namespace testAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string os { get; set; }
        public string browser { get; set; }
        public string version { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }
}