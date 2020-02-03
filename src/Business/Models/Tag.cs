using System;
using System.Collections.Generic;

namespace Business.Models {
    public class Tag : Entity {
        public Tag () {
            this.TagData = new HashSet<TagData> ();
        }

        public string Name { get; set; }
        public string TargetLink { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public byte[] Thumb { get; set; }
        public string HideInfo { get; set; }
        public string ShortText { get; set; }
        public bool OpenNewTab { get; set; }
        public string Campaingn { get; set; }
        public string Parameters { get; set; }
        public bool IsPriority { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateAt { get; set; }

        public IEnumerable<TagData> TagData { get; set; }

    }
}