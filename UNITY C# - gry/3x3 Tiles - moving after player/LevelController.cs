using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // 0 - Top Left
    // 1 - Top
    // 2 - Top Right
    // 3 - Left
    // 4 - Middle
    // 5 - Right
    // 6 - Bottom Left
    // 7 - Bottom
    // 8 - Bottom Right
    Transform[] allChildren;
    Transform middleTile;
    Transform newMiddleTile;
    Vector2[] positionsFromMiddleTile = new Vector2[9];

    private void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        // It was getting parent so I skip the first one
        allChildren = allChildren.Skip(1).ToArray();
    }

    private void Update()
    {
        SetMiddleTile();

        SetPositionsFromMiddleTile();

        MoveTilesToNewPositions();

        // I set it in the end, because there is a moment, where player is on the newMiddle tile
        // the tilesToMove aren't moved yet and it was causing an issue
        SetIndexesOfTiles();

        PrepareForSettingNewMiddleTile();

    }

    void SetMiddleTile()
    {
        // Here I set new middle tile
        foreach (Transform side in allChildren)
        {
            if (side.GetComponent<LevelTile>().playerOnTile)
            {
                if (middleTile == null)
                {
                    middleTile = side;
                }
                newMiddleTile = side;
            }
        }
    }

    void SetPositionsFromMiddleTile()
    {
        // Here I set positions for each tile from the middle, middle tile by default is [4]
        positionsFromMiddleTile[0] = new Vector2(newMiddleTile.position.x - 25, newMiddleTile.position.y + 25);
        positionsFromMiddleTile[1] = new Vector2(newMiddleTile.position.x, newMiddleTile.position.y + 25);
        positionsFromMiddleTile[2] = new Vector2(newMiddleTile.position.x + 25, newMiddleTile.position.y + 25);
        positionsFromMiddleTile[3] = new Vector2(newMiddleTile.position.x - 25, newMiddleTile.position.y);
        positionsFromMiddleTile[4] = new Vector2(newMiddleTile.position.x, newMiddleTile.position.y);
        positionsFromMiddleTile[5] = new Vector2(newMiddleTile.position.x + 25, newMiddleTile.position.y);
        positionsFromMiddleTile[6] = new Vector2(newMiddleTile.position.x - 25, newMiddleTile.position.y - 25);
        positionsFromMiddleTile[7] = new Vector2(newMiddleTile.position.x, newMiddleTile.position.y - 25);
        positionsFromMiddleTile[8] = new Vector2(newMiddleTile.position.x + 25, newMiddleTile.position.y - 25);
    }

    void MoveTilesToNewPositions()
    {
        List<Transform> tiles = new List<Transform>();
        List<Vector2> tilesPositions = new List<Vector2>();
        foreach (Transform tile in allChildren)
        {
            tiles.Add(tile);
            tilesPositions.Add(tile.position);
        }

        // Here I got tiles that need to be moved
        var tilesToMove = tiles.Where(p => positionsFromMiddleTile.Contains(p.position) == false).ToList();

        // I have to order them by the index assigned at the end as there was an issue
        // where tiles in order 3,1,2 where moved on the bottom in order 1,2,3
        // this solves it
        tilesToMove = tilesToMove.OrderBy(p => p.GetComponent<LevelTile>().index).ToList();

        // Here I get tiles that do not need to be moved
        var tilesToStay = tilesPositions.Where(p => positionsFromMiddleTile.Contains(p));

        // Here I get positions to which the tiles that need to be moved, shold be moved
        var positionsToMoveTiles = positionsFromMiddleTile.Where(p => !tilesToStay.Contains(p)).ToList();

        for (int i = 0; i < tilesToMove.Count(); i++)
        {
            tilesToMove[i].position = positionsToMoveTiles[i];
        }
    }

    void SetIndexesOfTiles()
    {
        foreach (Transform tile in allChildren)
        {
            tile.GetComponent<LevelTile>().index = System.Array.FindIndex(positionsFromMiddleTile, p => p == (Vector2)tile.position);
        }
    }

    void PrepareForSettingNewMiddleTile()
    {
        // Now middleTile is old middle tile and newMiddleTile is new middle tile
        if (newMiddleTile != middleTile)
        {
            middleTile = newMiddleTile;
            newMiddleTile = null;
        }
    }
}
