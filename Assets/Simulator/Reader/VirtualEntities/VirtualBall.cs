using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virtual {
    public class VirtualBall : VirtualEntity {
        private float yPos;

        public VirtualBall(Vector2 position, float speed, float yPos): base(position, speed) {
            this.yPos = yPos;
        }

        public Vector3 Position {
            get {
                return new Vector3(this.position.x, yPos, this.position.y);
            }
        }

    }
}
