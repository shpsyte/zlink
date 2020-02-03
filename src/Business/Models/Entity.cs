using System;

namespace Business.Models {
    public abstract class Entity {
        protected Entity () {
            this.Id = 0;
            UserId = Guid.NewGuid ();
        }

        public int Id { get; set; }
        public Guid UserId { get; set; }

    }
}