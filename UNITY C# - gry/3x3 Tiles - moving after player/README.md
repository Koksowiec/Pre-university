## 3x3 Tiles that move after player

# This is my solution to the problem I stumbled upon while creating my top down game
What I wanted to do is to create 9 tiles, with player on the middle. Whenever the player goes to the left or right, on the tile next to the middle, then this tile becomes the middle one and again there are 8 tiles around player. This is how I figured this out.

1) I have created an empty Game Object witch the scale of 25, 25, 1 and with the script: LevelController.
2) I have created 9 tiles, each with the script: LevelTile and 2D collider with trigger set to "on". The positions of tiles are starting from the left right corner: 
  -1,1,0 ; 0,1,0 ; 1,1,0
  -1,0,0 ; 0,0,0 ; 1,0,0
  -1,-1,0; 0,-1,0; 1,-1,0
3) I have created simple player controller that moves in all directions, that has script: Player, RigidBody2D, 2D collider with trigger set to "on".
  
