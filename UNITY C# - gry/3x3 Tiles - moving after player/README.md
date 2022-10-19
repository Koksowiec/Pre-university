# 3x3 Tiles that move after player

### This is my solution to the problem I stumbled upon while creating my top down game
What I wanted to do is to create 9 tiles, with player on the middle. Whenever the player goes to the left or right, on the tile next to the middle, then this tile becomes the middle one and again there are 8 tiles around player. This is how I figured this out.

## Preparation
1) I have created an empty Game Object witch the scale of 25, 25, 1 and with the script: LevelController.
2) I have created 9 tiles, each with the script: LevelTile and 2D collider with trigger set to "on". The positions of tiles are starting from the left right corner: 
  -1,1,0 ; 0,1,0 ; 1,1,0
  -1,0,0 ; 0,0,0 ; 1,0,0
  -1,-1,0; 0,-1,0; 1,-1,0
3) I have created simple player controller that moves in all directions, that has script: Player, RigidBody2D, 2D collider with trigger set to "on" and the Tag of "Player"

## Scripts
### LevelTile:
Each tile has this script, it has a boolean playerOnTile that is by default set to false, it changes to true whenever player enters or leaves tiles trigger.

### LevelController:
In the Start() method I take all the children of the Game Object and remove the first element as it is itself and not a children.

In the Update():
SetTheMiddleTile() -> gets the middle tile transform, if the middle tile is null in the beggining it is set it and then newMiddle is set to the current tile, whenever player enter another tile, there is a moment when middleTile is set to an old tile and newMiddleTile is set to the current (new) tile.
  
![1](https://user-images.githubusercontent.com/44843822/196749345-429c70ed-a103-469c-b516-edba3b5502bc.png)
