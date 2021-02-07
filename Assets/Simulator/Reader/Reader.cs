using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Virtual;
using UnityEngine;

public class Reader : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private string dataFilePath = "/Simulator/data/";
    [SerializeField] private string dataFileName = "match_data.dat";
    [SerializeField] private int renderDistance = 1000;

    [Header("Advanced options")]
    [SerializeField] private int dataCountPerFrame = 3;
    [SerializeField] private int frameIndexPositionIndex = 0;
    [SerializeField] private int trackedObjectsPositionIndex = 1;
    [SerializeField] private int ballObjectPositionIndex = 2;

    private int totalFrames = 0;
    private int startIndex = 0;
    private List<Frame> frameList = new List<Frame>();

    public int TotalFrames { get { return this.totalFrames; } }

    /// <summary>
    /// We currently start our program here :)
    /// </summary>
    private void Awake() {
        StartCoroutine(StartRead());
    }

    /// <summary>
    /// Get the frame a certain position within the frame array.
    /// </summary>
    /// <param name="index">The index of the frame</param>
    /// <returns></returns>
    public Frame GetFrame(int index) {
        //Incase the frame isn't loaded yet or when the index is higher than our entire recording ofcourse.
        if (frameList.Count <= index - startIndex)
            return null;

        //Here we make sure that the frames outside our render distance are removed.
        //This is mainly to prefent overflowing our memory in any way.
        if (index - renderDistance/2 > 0) {
            startIndex++;
            frameList.RemoveAt(0);
        }

        return frameList[index - startIndex];
    }

    /// <summary>
    /// We're reading the file async, 
    /// it would make a relatively big impact on our performance if we did all this on the same thread.
    /// This system also makes sure we're not overflowing our memory since we don't load everything, 
    /// but only a part of the recording!
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartRead() {
        //I start of with loading the data into a string and subdividing that string into frames
        string match = File.ReadAllText(Application.dataPath + dataFilePath + dataFileName);
        string[] frames = match.Split(new[] { ":" }, System.StringSplitOptions.None);

        VirtualBall ball = null;
        List<VirtualTrackedObject> trackedObjects = new List<VirtualTrackedObject>();

        totalFrames = frames.Length / dataCountPerFrame;

        for (int i = 0; i < frames.Length; i++) {
            //Make sure we're not using too much memory
            if ((player.CurrentFrameIndex + renderDistance / 2) < (startIndex + frameList.Count))
                yield return new WaitForEndOfFrame();

            //The data exists out of 3 components (can be changed with dataCountPerFrame), 
            //we're only intrested in the ones that contains possitions
            if (i % dataCountPerFrame == frameIndexPositionIndex) {
                continue;
            } else if(i % dataCountPerFrame == trackedObjectsPositionIndex) {
                //This is the entire frame, we need to subdivide this even further into objects
                string[] frameData = frames[i].Split(new[] { ";" }, System.StringSplitOptions.None);

                foreach (string obj in frameData) {
                    //We need to split the objects into parseable data
                    string[] objectData = obj.Split(new[] { "," }, System.StringSplitOptions.None);

                    //We need to make sure that we can actually translate this into an trackedobject
                    //This switch is to prevent any errors :)
                    switch (objectData.Length) {
                        case 6:
                            trackedObjects.Add(TranslateTrackedObject(objectData));
                            break;
                    }
                }
            } else if (i % dataCountPerFrame == ballObjectPositionIndex) {
                //We only need to split the string 1 more time in this case :)
                string[] objectData = frames[i].Split(new[] { "," }, System.StringSplitOptions.None);
                ball = TranslateBall(objectData);

                //Actually initializing the frame.
                Frame frame = new Frame(trackedObjects, ball);
                frameList.Add(frame);

                //Reset our variables for the next frame.
                ball = null;
                trackedObjects = new List<VirtualTrackedObject>();

                //This makes the loading process async!
                //Meaning we can actually run the program without crashing our computer :)
                yield return new WaitForEndOfFrame();
            }
        }

        yield return null;
    }

    /// <summary>
    /// Translates a string array of object data into a virtual tracked object.
    /// </summary>
    /// <param name="objectData">String array of the object's data</param>
    /// <returns>A virtual tracked object, which can be read by a normal (visual) tracked object.</returns>
    private VirtualTrackedObject TranslateTrackedObject(string[] objectData) {
        int teamId = int.Parse(objectData[0]);
        int trackingId = int.Parse(objectData[1]);
        int playerNumber = int.Parse(objectData[2]);

        float xPos = float.Parse(objectData[3]);
        float yPos = float.Parse(objectData[4]);
        float speed = float.Parse(objectData[5]);

        Vector2 position = new Vector2(xPos, yPos);
        
        return new VirtualTrackedObject(position, speed, teamId, trackingId, playerNumber);
    }

    /// <summary>
    /// Translates a string array of object data into a virtual ball object.
    /// </summary>
    /// <param name="objectData">String array of the object's data</param>
    /// <returns>A virtual ball object, which can be read by a normal (visual) ball.</returns>
    private VirtualBall TranslateBall(string[] objectData) {
        float xPos = float.Parse(objectData[0]);
        float zPos = float.Parse(objectData[1]);
        float yPos = float.Parse(objectData[2]);

        float speed = float.Parse(objectData[3]);
        Vector2 position = new Vector2(xPos, zPos);

        return new VirtualBall(position, speed, yPos);
    }

}
