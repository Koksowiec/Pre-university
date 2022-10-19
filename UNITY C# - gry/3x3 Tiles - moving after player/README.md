# 3x3 Tiles that move after player

![2](https://user-images.githubusercontent.com/44843822/196753270-1497d567-4167-42d1-8288-1b89e9c45813.png)

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

SetPositionsFromMiddleTile() -> here I manually set the positions of tiles. I know that in the world space, with my parent object being scaled to 25,25,1 the positions of each are in the beggining like so:
  -25,25,0 ; 0,25,0 ; 25,25,0
  -25,0,0  ; 0,0,0  ; 25,0,0
  -25,-25,0; 0,-25,0; 25,-25,0
Knowing this I dtermined that each tile is at some distance away from the middle tile, so what I decided to do is, get the current middle tile and set each tiles position to be the same as in the beggining. So for example whenever the left-middle tile is currently the middle one, the tiles positions should look like this:
  -50,25,0 ; -25,25,0 ; 0,25,0
  -50,0,0  ; -25,0,0  ; 0,0,0
  -50,-25,0; -25,-25,0; 0,-25,0
  
MoveTilesToNewPositions() -> this method is responsible for moving the tiles to coresponding positions. Now I have the array of the positions for each tile, coming back for the previous example, whenever left-middle tile is currently middle then positionsFromMiddleTile[0] should be -50,25,0 and so on. So first thing that I need to do is to get all the tiles current positions. Now I have to get the tiles that are in the wrong positions, so their position isn't in the list of positionsFromMiddleTile, there will always be 3 tiles. To not get a bug, now I have to order the tiles by their indexes (I know that in the very beggining all the tiles have index 0, I decided to let it be). Then I get the tiles that do not need to be moved, so the rest 6 tiles. After having this tiles I get the positions that the 3 tiles to move, should be moved into. The rest 6 tiles help me with that. And in the end I move the 3 tiles to their correct positions.

SetIndexesOfTiles() -> here I assign the tiles their index, always from the middle one. So in the beggining tiles will be 0,1,2,3,4,5,6,7,8 but when player moves to left-middle tile then the indexes will be 1,2,0,4,5,3,7,8,6

PrepareForSettingNewMiddleTile() -> this is the last method that happens in update. Here I check if the newMiddleTile is the same as old middleTile if so, I set the middleTile to newMiddleTile and reset newMiddleTile to null.
