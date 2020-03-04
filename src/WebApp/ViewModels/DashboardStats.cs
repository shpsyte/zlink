using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.ViewModels {
    public class DashboardStats {
        private TagDTO Tag;
        private DateTime start;
        private DateTime end;

        public DashboardStats (TagDTO tagDTO, DateTime start, DateTime end) {
            this.Tag = tagDTO;
            this.start = start;
            this.end = end;
        }

        public int TotalClicks {
            get {
                return Tag.TagData.Where (a => a.Data >= start && a.Data <= end).Count ();
            }
        }

        public int TotalUniqueClicks {
            get {
                return Tag
                    .TagData
                    .Where (a => a.Data >= start && a.Data <= end)
                    .GroupBy (a => a.Ip)
                    .Count ();
            }
        }

        public IEnumerable<object> Clicks {
            get {
                return Tag.TagData.Where (a => a.Data >= start && a.Data <= end)
                    .Select (a => new {
                        id = a.Id,
                            Data = a.Data,
                            Ip = a.Ip,
                            Lat = a.Lat,
                            Lon = a.Lon,
                            Organization = a.Organization,
                            CountryCode = a.CountryCode,
                            Country = a.Country,
                            RegionName = a.RegionName,
                            City = a.City,
                            District = a.District,
                            a.PostalCode

                    })
                    .OrderByDescending (a => a.Data);
            }
        }

        public IEnumerable<object> ClicksByDay {
            get {
                var link = from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.Data
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("dd/MM/yyyy")
                into g
                select new { Key = g.Key, Qtd = g.Count () };

                return link;
            }
        }

        public IEnumerable<object> ClicksByMonth {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.Data
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("MM")
                into g
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByYear {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.Data
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("yyyy")
                into g
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByRegion {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.RegionName
                group tagdata by tagdata.RegionName
                into g
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByCity {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.City
                group tagdata by tagdata.City
                into g
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByCountry {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                orderby tagdata.Country
                group tagdata by tagdata.Country
                into g
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

    }
}