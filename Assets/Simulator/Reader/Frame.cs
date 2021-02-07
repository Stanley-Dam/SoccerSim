using System.Collections;
using System.Collections.Generic;
using Virtual;
using Entity;
using UnityEngine;

public class Frame {
    
    private VirtualTrackedObject[] trackedObjects;
    private VirtualBall ball;

    public int TrackedObjectCount { get { return this.trackedObjects.Length; } }

    /// <summary>
    /// The constructor,
    /// A frame contains all the essential data about the entities at a specific moment in time.
    /// </summary>
    /// <param name="trackedObjects">A list of all virtual tracked objects in this frame.</param>
    /// <param name="ball">The virtual ball of this frame.</param>
    public Frame(List<VirtualTrackedObject> trackedObjects, VirtualBall ball) {
        this.trackedObjects = trackedObjects.ToArray();
        this.ball = ball;
    }

    /// <summary>
    /// Use this function if this is the first frame that's being rendered.
    /// This will initialize the objects, instead of moving them :)
    /// Use <see cref="Execute"/> if you've already initialized another frame before this one.
    /// </summary>
    /// <param name="ball">The visual ball</param>
    /// <param name="trackedObjects">An array of the visual tracked objects.</param>
    public void Instatiate(Ball ball, TrackedObject[] trackedObjects) {
        ball.Set(this.ball);

        for (int i = 0; i < trackedObjects.Length; i++)
            trackedObjects[i].Set(this.trackedObjects[i]);
    }

    /// <summary>
    /// Moves all objects to the positions in this frame.
    /// Use <see cref="Instatiate"/> if this is the first frame you're rendering.
    /// </summary>
    /// <param name="ball">The visual ball</param>
    /// <param name="trackedObjects">An array of the visual tracked objects.</param>
    public void Execute(Ball ball, float time) {
        ball.StartCoroutine(ball.MoveTo(this.ball, time));

        for(int i = 0; i < trackedObjects.Length; i++)
            trackedObjects[i].Execute(time);
    }
}
