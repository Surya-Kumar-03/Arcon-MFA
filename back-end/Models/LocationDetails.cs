using System.ComponentModel.DataAnnotations;
namespace testAPI.Models
{
    public class LocationDetails
    {
        public LocationDetails() { }
        public int? Id { get; set; }
        public string code1 { get; set; }
        public string code2 { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }
}