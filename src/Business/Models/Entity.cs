using System;

namespace Business.Models {
    public abstract class Entity {
        protected Entity () {
            Id = Guid.NewGuid ();

        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

    }
}