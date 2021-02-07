using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virtual {
    public abstract class VirtualEntity {
        protected Vector2 position;
        protected float speed;

        public VirtualEntity(Vector2 position, float speed) {
            this.position = position;
            this.speed = speed;
        }

        public float Speed { get { return this.speed; } }
    }
}
