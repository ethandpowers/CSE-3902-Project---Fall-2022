# CSE-3902-Project - Sprint 4

NOTE: This repo is a clone of the private team project repo.

For the multiplayer controller, we used a controller built with Flutter located [here](https://github.com/ethandpowers/BBCC-Controller.git).  For our server, we used NodeJS with websockets, which can be found [here](https://github.com/ethandpowers/BBCC-Server.git)

This README file contains brief instructions/information regarding controls, features, and special cases for this project

Firstly, here is a quick list of the (main) game controls - these may vary from point to point in the game:

- Arrows, WASD: movement of Link
- Z, N: sword attack
- C: secondary attack
- E: open inventory
- ESC: pause game
- M: mute audio
- Q: quit the game (can only be done when game is paused)
- SPACE: restarts the game (after you die/win)
- WASD can be used within the inventory to select items

- Left Click: teleport to previous room
- Right Click: teleport to next room

Here are some of the "main" Sprint 4 requirements from this project:
- Mouse controls to teleport between rooms (for testing)
- Room with all items (for testing) - located in the room directly to below spawn :)
- Sound effects and background music, with mute functionality
- Resetting the level upon character's death
- HUD
- Inventory
- All possible game states and transitions (and bonus main menu with super helpful game tips)

In addition to the main Sprint 4 requirements from the web page, there are a handful of other cool features that may or may not be hard to miss:
- Link's sword attack (Z, N) will create a projectile if he is at full health (NOT spammable)
- The boomerangs for both Link and the Goriyas will home back to the user, and Link's can stun enemies and pick up items
- Clock items can freeze enemies similarly to Link's boomerang, but lasts until you leave the room
- Link can actually die from his own bombs (how sad)
- Really awesome game transitions for losing, winning, and going to the basement
- Original "new item" effect when picking up the bow
- Enemies drop items upon death
- Pause and mute buttons will even work during camera transitions!
- Super secret doorways that can be found by blowing up the walls
- "Typing out" of text in the old man room
- Try attacking the old man if you dare (careful - may be laggy!)
- Full wallmaster behavior, complete with link getting sent back to the start (careful around the walls!)
- Cool custom mouse cursor
- Robust event system for various puzzles/events in-game!
# CSE-3902-Project---Fall-2022
