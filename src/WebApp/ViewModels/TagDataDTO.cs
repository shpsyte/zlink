using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels {
    public class TagDataDTO {

        public TagDataDTO () {
            this.Id = Guid.NewGuid ();
            this.Data = DateTime.UtcNow;

        }

        public TagDataDTO (Guid id, string ipFromServer, string userAgent, IPDTO ip_data) : this () {
            this.TagId = id;
            this.Ip = ip_data?.ip;
            this.IpFromServer = ipFromServer;
            this.City = ip_data?.city;
            this.Continent = ip_data?.continent_name;
            this.ContinentCode = ip_data?.continent_code;
            this.Country = ip_data?.country_name;
            this.CountryFlag = ip_data?.country_flag;
            this.Data = DateTime.UtcNow;
            this.District = ip_data?.district;
            this.IsMobile = false;
            this.CountryCode = ip_data?.country_code2;
            this.ISP = ip_data?.isp;
            this.Lat = ip_data?.latitude;
            this.Lon = ip_data?.longitude;
            this.Organization = ip_data?.organization;
            this.PostalCode = ip_data?.zipcode;
            this.RegionName = ip_data?.state_prov;
            this.Region = ip_data?.time_zone?.name;
            this.SoClient = ip_data?.geoname_id;
            this.Currency = ip_data?.currency?.code;
            this.TimeZone = ip_data?.time_zone?.current_time;
            this.WebBrowserClient = userAgent;
        }

        [Key]
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string IpFromServer { get; set; }

        public Guid TagId { get; set; }

        [Required]
        public DateTime Data { get; set; }
        public string Continent { get; set; }
        public string ContinentCode { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string CountryFlag { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }
        public string Currency { get; set; }

        public string Organization { get; set; }
        public bool IsMobile { get; set; }
        public string WebBrowserClient { get; set; }
        public string SoClient { get; set; }
        public string ISP { get; set; }

        public TagDTO Tag { get; set; }
    }
}