using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Obstacle[] obstacleObjects;

    // TESTING: DELETE THIS
    public Obstacle[] testingArray;

    private ObstacleSize previousObstacleSize;
    private Vector3 previousObstaclePos;

    private readonly int sizeOfBlock = 1;
    private readonly float yPos = -3.268487f;
    private readonly float initialXPos = 4.31055f;

    // Use this for initialization
    void Start () {

        // TESTING
        List<Obstacle> testList = new List<Obstacle>(testingArray);
        SpawnObstacles(testList);
    }

    public void SpawnObstacles (List<Obstacle> obstacles)
    {
        foreach (Obstacle obstacle in obstacles)
        {
            SpawnEachObstacle(obstacle.prefab);
        }
    }

    private void SpawnEachObstacle(GameObject obstacle)
    {
        int previousWidth = 0;
        if (previousObstacleSize != null)
        {
            previousWidth = previousObstacleSize.width;
        }

        float xPos = previousWidth * sizeOfBlock;
        if (previousObstacleSize == null)
        {
            xPos = initialXPos;
        }

        if (previousObstaclePos != null)
        {
            xPos += previousObstaclePos.x;
        }

        Vector3 pos = new Vector3(xPos, yPos, 0.0f);

        Instantiate(obstacle, pos, Quaternion.identity);
        previousObstacleSize = obstacle.GetComponent<ObstacleSize>();
        previousObstaclePos = pos;
    }
}
