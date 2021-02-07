# SoccerSim

[Demo video](https://www.youtube.com/watch?v=2QYZBeQzwAQ&feature=youtu.be)

### Project details
Unity version: 2019.4.11f1

#### Assets / packages used
 - [Outline effect](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/outline-effect-78608?_ga=2.164527103.1536626143.1612443274-1724292300.1577381227)
 - [Unity input system](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html)
 
### Controls
- W A S D : Move
- Right mouse : Rotate camera
- Left mouse : Spectate highlighted
- Escape : Exit spectate

### About
A soccer match visualizer.

After reading the assignment I quickly started working on this [initial class diagram](https://drive.google.com/file/d/1__MOcfRyjXJjwldVApxFsPZ1-wdfPiGW/view?usp=sharing), where I was able to construct a system that loads the data async into memory, it also removes frames it doesn't need anymore.
The system has two main classes, [The reader](https://github.com/Stanley-Dam/SoccerSim/blob/main/Assets/Simulator/Reader/Reader.cs) and [The player](https://github.com/Stanley-Dam/SoccerSim/blob/main/Assets/Simulator/Player/Player.cs).
The reader reads the .dat file and turns it into useable [frames](https://github.com/Stanley-Dam/SoccerSim/blob/main/Assets/Simulator/Reader/Frame.cs).
The player class is then responsible for actually executing these frames in order and with a certain speed.
You can find the actual system in the [Simulator folder](https://github.com/Stanley-Dam/SoccerSim/tree/main/Assets/Simulator).

There are still some visual glitches when using this system, I found that this was a problem with the given dataset.
I decided not to fix this in the client side because that could impact the performance for the end user.
I instead used the time to work on a small camera system and smoothing movement of the entities.
This also seemed more important for this specific assignment, I bassicly focussed a bit more on visualizing the data than correcting the errors in it.
