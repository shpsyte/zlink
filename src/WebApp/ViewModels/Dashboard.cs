using System;
using System.Collections.Generic;

namespace WebApp.ViewModels {

    public class Dashboard {

        public Dashboard () {
            ReportDate = DateTime.UtcNow;

        }

        public Dashboard (IEnumerable<TagDTO> tags) : this () {
            this.Tags = tags;
        }

        public Dashboard (TagDTO tag, DateTime start, DateTime end) : this () {
            this.Tag = tag;
            this.Start = start;
            this.End = end;
            this.Id = tag.Id;
        }

        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ReportDate { get; set; }

        public TagDTO Tag { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }

        public DashboardStats Stats {
            get {
                return new DashboardStats (Tag, Start, End);

            }
        }

    }

}