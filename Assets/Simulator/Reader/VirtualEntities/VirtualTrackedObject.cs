using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virtual {
    public class VirtualTrackedObject : VirtualEntity {

        public static Action<int, VirtualTrackedObject, float> onExecute;

        private int teamId;
        private int objectId;
        private int playerNumber;

        public VirtualTrackedObject(Vector2 position, float speed, int teamId, int objectId, int playerNumber) : base(position, speed) {
            this.teamId = teamId;
            this.objectId = objectId;
        }

        public void Execute(float time) {
            onExecute(this.objectId, this, time);
        }

        public int TeamId { get { return this.teamId; } }
        public int ObjectId { get { return this.objectId; } }
        public int PlayerNumber { get { return this.playerNumber; } }
        public Vector3 Position { get { return new Vector3(this.position.x, 0, this.position.y); } }
    }
}
