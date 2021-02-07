using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Virtual;

namespace Entity {
    public class TrackedObject : Entity, IEntity {

        [SerializeField] private Transform head;
        [SerializeField] private List<Color> teamColors = new List<Color>();
        [SerializeField] private List<MeshRenderer> colorableMeshes = new List<MeshRenderer>();

        private int teamId;
        private int objectId;
        private int playerNumber;

        /// <summary>
        /// Initializes the tracked object.
        /// </summary>
        /// <param name="entity">Has to be a <see cref="VirtualTrackedObject"/>!</param>
        public void Set(VirtualEntity entity) {
            VirtualTrackedObject vTrackedObj = (VirtualTrackedObject)entity;

            this.speed = vTrackedObj.Speed;
            this.teamId = vTrackedObj.TeamId;
            this.objectId = vTrackedObj.ObjectId;
            this.playerNumber = vTrackedObj.PlayerNumber;

            this.transform.position = vTrackedObj.Position / GameManager.Instance.DataScaleDif;

            UpdateTeamColor();

            VirtualTrackedObject.onExecute += OnExecuteHanlder;
        }

        private void OnExecuteHanlder(int objId, VirtualTrackedObject e, float time) {
            if (objId == this.objectId)
                StartCoroutine(MoveTo(e, time));
        }

        /// <summary>
        /// Moves the tracked object to the given position,
        /// also makes this transaction smooth.
        /// </summary>
        /// <param name="entity">Has to be a <see cref="VirtualTrackedObject"/>!</param>
        /// <param name="time">The time it has to take to do this transition.</param>
        /// <returns></returns>
        public IEnumerator MoveTo(VirtualEntity entity, float time) {
            VirtualTrackedObject vTrackedObj = (VirtualTrackedObject)entity;

            Vector3 oldPosition = this.transform.position;
            Quaternion oldRotation = head.rotation;

            if (vTrackedObj.TeamId != this.teamId && vTrackedObj.TeamId >= 0) {
                this.teamId = vTrackedObj.TeamId;
                UpdateTeamColor();
            }

            float elapsedTime = 0;

            while (elapsedTime < time) {
                this.transform.position = Vector3.Lerp(oldPosition, vTrackedObj.Position / GameManager.Instance.DataScaleDif, (elapsedTime / time));
                head.LookAt(vTrackedObj.Position / GameManager.Instance.DataScaleDif + Vector3.up);
                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }

        private void UpdateTeamColor() {
            foreach (MeshRenderer mesh in colorableMeshes) {
                if (this.teamId < 0)
                    return;
                mesh.material.color = teamColors[this.teamId % teamColors.Count];
            }
        }

        private void OnDisable() {
            VirtualTrackedObject.onExecute -= OnExecuteHanlder;
        }

    }
}
