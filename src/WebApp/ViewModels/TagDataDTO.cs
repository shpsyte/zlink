using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels {
    public class TagDataDTO {

        public TagDataDTO () {
            this.Id = Guid.NewGuid ();
            this.Data = DateTime.UtcNow;
            // TODO: temporario
            this.UserId = Guid.NewGuid ();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid TagId { get; set; }

        [Required]
        public DateTime Data { get; set; }
        public string Continent { get; set; }
        public string ContinentCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }
        public string Currency { get; set; }
        public string Iso { get; set; }
        public string Organization { get; set; }
        public bool IsMobile { get; set; }
        public string WebBrowserClient { get; set; }
        public string SoClient { get; set; }
        public string ISP { get; set; }

        public TagDTO Tag { get; set; }
    }
}