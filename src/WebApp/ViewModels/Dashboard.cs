using System;

namespace WebApp.ViewModels {

    public class Dashboard {

        public Dashboard () {
            ReportDate = DateTime.UtcNow;

        }

        public Dashboard (Guid id) : this () {
            this.Id = id;
        }

        public Dashboard (TagDTO tag, DateTime start, DateTime end) : this (tag.Id) {
            this.Tag = tag;
            this.Start = start;
            this.End = end;
        }

        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ReportDate { get; set; }

        public TagDTO Tag { get; set; }

        public DashboardStats Stats {
            get {
                return new DashboardStats (Tag, Start, End);

            }
        }

    }

}