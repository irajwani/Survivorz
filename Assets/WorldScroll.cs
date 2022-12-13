using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We want to, whole the player is moving, identify the tiles (based on their coordinates) that are currently visible to the player
// Based on this, we will generate new tiles if the world is about to "finish" to simulate the feel of an infinite world

public class WorldScroll : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    
    Vector2Int currentTilePosition;
    [SerializeField] Vector2Int playerTilePosition;
    [SerializeField] float tileSize = 20f; 

    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    private void Awake() {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition) {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }

}
