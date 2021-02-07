using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Reader reader;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private TrackedObject trackedObjectPrefab;
    [SerializeField] private int fps = 25;
    [SerializeField] private float minSpeedValue = 0.1f;
    [SerializeField] private float maxSpeedValue = 100f;

    private int currentFrameIndex = 0;

    private float speed = 1f;
    private bool isPlaying = false;

    private Ball ball;
    private List<TrackedObject> trackedObjects = new List<TrackedObject>();

    public int Fps { get { return this.fps; } }
    public int CurrentFrameIndex { get { return this.currentFrameIndex; } }
    public float MinSpeedValue { get { return this.minSpeedValue; } }
    public float Speed {
        get {
            return this.speed;
        }
        set {
            speed = Mathf.Clamp(value, minSpeedValue, maxSpeedValue);
        }
    }

    /// <summary>
    /// This class starts later than the reader,
    /// this is very important since the player needs the first frame to set up the scene.
    /// </summary>
    private void Start() {
        Init();
    }

    /// <summary>
    /// Here we actually set up our visual environment.
    /// </summary>
    public void Init() {
        Frame initialFrame = reader.GetFrame(currentFrameIndex);
        this.ball = Instantiate(ballPrefab);

        for (int i = 0; i < initialFrame.TrackedObjectCount; i++)
            this.trackedObjects.Add(Instantiate(trackedObjectPrefab));

        initialFrame.Instatiate(ball, trackedObjects.ToArray());

        isPlaying = true;
        StartCoroutine(Play());
    }

    /// <summary>
    /// This is an easy way to update with the same frequency as the recording :)
    /// </summary>
    /// <returns></returns>
    public IEnumerator Play() {
        while(isPlaying) {
            float time = this.speed / this.fps;

            Frame frame = reader.GetFrame(currentFrameIndex);

            if (frame != null) {
                frame.Execute(ball, time);
                currentFrameIndex++;
            }

            yield return new WaitForSeconds(time);
        }

        yield return null;
    }

}
