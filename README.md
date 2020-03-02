# OculusPong

**Platform:** Android (Oculus GO)

**Engine:** Unity3D

## Description
This game is a VR game inspired from the disk battle in the ***Tron: Legacy*** movie.

The goal is to throw a disk/frisbee to hit targets in the game scene in a limited time (or not). The player must grab the disk when it comes back or he loses 1 life point.

## Elements

### TARGETS
Targets spawn at a random position in the scene and disapears after a given time.   
It can increase or decrease the score or even give bonus (increase disk size, disk duplication, give life points).

**Static Targets**  
This type of target remains at a certain location but it rotates.

**Moving Targets**  
This type of target moves randomly in the scene and rotate.

### SCORING
- Grabbing the frisbee **increase** the score
- Missing the frisbee when it comes back **decrease** the score
- Hitting a "good" target **increase** the score
- Hitting a "bad" target **decrease** the score

### MENU
Once the game is started, the player can:
- Enter a **username**
- Choose to play for a **3**/**5**/**10** minutes or **unlimited** session. After this time lapse, the game is over
- Show the **high scores**
- **Start** a game

### UI
In game, the player can see on the top of his vision, the remained life points and the current score.   
