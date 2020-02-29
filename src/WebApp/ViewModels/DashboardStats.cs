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
                    .OrderBy (a => a.Data);
            }
        }

        public IEnumerable<object> ClicksByDay {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("dd/MM/yyyy")
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByMonth {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("MM")
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByYear {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.Data.ToLocalTime ().ToString ("yyyy")
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByRegion {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.RegionName
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByCity {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.City
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }

        public IEnumerable<object> ClicksByCountry {
            get {
                return from tagdata in this.Tag.TagData
                where tagdata.Data >= start && tagdata.Data <= end
                group tagdata by tagdata.Country
                into g
                orderby g.Key
                select new { Key = g.Key, Qtd = g.Count () };
            }
        }
        // public class DashboardDate {
        //     public string Key { get; set; }
        //     public int Qtd { get; set; }
        // }

        // public class DashboardRegion {
        //     public string Key { get; set; }
        //     public int Qtd { get; set; }
        // }

        // public class DashboardCity {
        //     public string Key { get; set; }
        //     public int Qtd { get; set; }
        // }

    }
}