using UnityEngine;
using System;

[Serializable]
public struct Obstacle
{
    public Sprite obstacleSprite;
    public ObstacleType type;
    public GameObject prefab;
}
