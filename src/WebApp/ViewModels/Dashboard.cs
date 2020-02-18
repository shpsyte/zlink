using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.ViewModels {

    public class Dashboard {

        public Dashboard () {
            ReportDate = DateTime.UtcNow;

        }

        public Dashboard (TagDTO tag) : this () {
            this.Id = tag.Id;
            this.Tag = tag;
        }

        public Dashboard (TagDTO tag, IEnumerable<TagDTO> tags) : this (tag) {
            this.Tags = tags;
        }

        public Guid Id { get; set; } public DateTime ReportDate { get; set; } public int Qtd {
            get {
                return Tag.TagData.Count ();
            }
        }
        public TagDTO Tag { get; set; } public IEnumerable<TagDTO> Tags { get; set; } public IEnumerable<DashboardDate> DashboardDate {
            get {
                return from tagdata in this.Tag.TagData
                group tagdata by tagdata.Data.ToString ("dd/mm/YYYY")
                into g
                orderby g.Key
                select new DashboardDate { Key = g.Key, Qtd = g.Count () };
            }
        }
        public IEnumerable<DashboardRegion> DashboardRegion {
            get {
                return from tagdata in this.Tag.TagData
                group tagdata by tagdata.RegionName
                into g
                orderby g.Key
                select new DashboardRegion { Key = g.Key, Qtd = g.Count () };
            }
        }
        public IEnumerable<DashboardCity> DashboardCity {
            get {
                return from tagdata in this.Tag.TagData
                group tagdata by tagdata.City
                into g
                orderby g.Key
                select new DashboardCity { Key = g.Key, Qtd = g.Count () };

            }
        }
    }

    public class DashboardDate {
        public string Key { get; set; }
        public int Qtd { get; set; }
    }

    public class DashboardRegion {
        public string Key { get; set; }
        public int Qtd { get; set; }
    }

    public class DashboardCity {
        public string Key { get; set; }
        public int Qtd { get; set; }
    }

}