using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels {
    public class TagDTO {

        public TagDTO () {
            this.Id = Guid.NewGuid ();
            this.CreateAt = DateTime.UtcNow;
            this.IsPriority = false;
            this.Active = true;
            this.Deleted = false;

        }

        [Key]
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string TargetLink { get; set; }
        public Nullable<DateTime> Start { get; set; }
        public Nullable<DateTime> End { get; set; }
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

        public int TotalTags { get; set; }
        public int key { get; set; }

        public IEnumerable<TagDataDTO> TagData { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }

        public string Theme { get; set; }
        public string UserName { get; set; }
        public byte[] Avatar { get; set; }
        public string MainLinkImg { get; set; }

    }
}