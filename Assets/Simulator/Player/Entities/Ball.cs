using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virtual;

namespace Entity {
    public class Ball : Entity, IEntity {

        /// <summary>
        /// Moves the ball to the given position,
        /// also makes this transition smooth and even adds rotation.
        /// </summary>
        /// <param name="entity">Has to be a <see cref="Virtual.VirtualBall"/>!</param>
        /// <param name="time">The time it has to take to do this transition.</param>
        /// <returns></returns>
        public IEnumerator MoveTo(VirtualEntity entity, float time) {
            VirtualBall vBall = (VirtualBall)entity;

            if (vBall == null)
                yield return null;

            this.speed = vBall.Speed;
            Vector3 oldPosition = this.transform.position;

            float elapsedTime = 0;

            while (elapsedTime < time) {
                this.transform.position = Vector3.Lerp(oldPosition, vBall.Position / GameManager.Instance.DataScaleDif, elapsedTime / time);

                //I decided to add some simple rotations after I added an texture to the ball :P
                //It's based on the speed and direction of the ball.
                Vector3 direction = (vBall.Position - oldPosition).normalized;
                this.transform.Rotate(vBall.Speed * -direction / (time  * 10000f));

                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }

        /// <summary>
        /// Basically initializes the ball.
        /// </summary>
        /// <param name="entity">Has to be a <see cref="Virtual.VirtualBall"/>!</param>
        public void Set(VirtualEntity entity) {
            VirtualBall vBall = (VirtualBall) entity;

            this.speed = vBall.Speed;
            this.transform.position = vBall.Position / GameManager.Instance.DataScaleDif;
        }
    }
}
