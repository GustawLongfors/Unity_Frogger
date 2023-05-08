# Frogger Game

This is a remake of of the classic game Frogger where you have to navigate the frog safely through a busy street and over a river to reach home/goal. 

## Controls

Menus : **Mouse**
Gameplay :
 - Movement : **Arrow keys**
 - Opening the pause menu : **Mouse**

## Features

###Semi-Randomly generated levels
This game introduces 6 levels, but there's no strict limit of levels. They are driven by a spawning system which spawns the obstacles and platforms in a random way, but always using a configuration Scriptable Objects. Game Designer can create as many configurations as needed by simply changing a few values.

###Timers
When starting each level, the countdown timer shows up locking the player's interaction with the game for 3 seconds. After that player can start jumping around to make it's way to the other side of the road or the river.
During the challenge the player can see a level timer in the upper right corner of the screen, so it knows exactly how much time passed from the start of the given level. This timer does not reset on failures.

###Automatic saves
Player doesn't have to remember that it is needed to save the game if he/she wants to continue from the current level later. If a player hits the Pause Menu button (in the upper left corner) and selects to go back to the Main Menu, the game state will save automatically.
The game is also saving the game settings, so when Player changes the music's or sfxs' volume and exits the Settings Menu, this is being automatically saved. The same goes for changing the name of the Player.

Link to youtube video demonstrating the game: https://youtu.be/1LM8q_L45zU

List of used third party assets 

Polyperfect: Low Poly Ultimate Pack
(https://assetstore.unity.com/packages/3d/props/low-poly-ultimate-pack-54733) 

DOTween (for animations from code)
http://dotween.demigiant.com/

Music
https://assetstore.unity.com/packages/audio/music/complete-music-collection-free-edition-119129

Ambient sounds
https://assetstore.unity.com/packages/audio/ambient/nature/nature-essentials-208227 

Vehicle sounds
https://assetstore.unity.com/packages/audio/sound-fx/transportation/vehicle-essential s-194951 

Jump and hit sounds
https://creatorassets.com/ 
