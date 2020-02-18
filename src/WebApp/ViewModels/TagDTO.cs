using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Business.Services;

namespace WebApp.ViewModels {
    public class TagDTO {

        public TagDTO () {
            this.Id = Guid.NewGuid ();
            this.CreateAt = DateTime.UtcNow;
            this.IsPriority = false;
            this.Active = true;
            this.Deleted = false;

        }

        public TagDTO (IEnumerable<TagDTO> tag) : this () {
            this.Tags = tag;
        }

        public TagDTO (string username, IProfileServices profile, IEnumerable<TagDTO> tag) : this (tag) {
            Theme = profile.Theme (username).Result;
            UserName = username;
            Avatar = profile.Avatar (username).Result;
            MainLinkImg = profile.MainLinkImg (username).Result;
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

        /// unmaped properties

        public int? TotalTags {
            get {
                return this.Tags?.Count ();
            }
        }
        public int key { get; set; }

        public IEnumerable<TagDataDTO> TagData { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }

        public string Theme { get; }
        public string UserName { get; }
        public byte[] Avatar { get; }
        public string MainLinkImg { get; }

    }
}