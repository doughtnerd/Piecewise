using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacleObjects;

    private ObstacleSize previousObstacleSize;
    private Vector3 previousObstaclePos;

    private readonly int sizeOfBlock = 1;
    private readonly float yPos = -3.268487f;
    private readonly float initialXPos = 4.31055f;

    // Use this for initialization
    void Start () {
        // TESTING
        List<ObstacleType> myList = new List<ObstacleType>();
        myList.Add(ObstacleType.TestObstacle1);
        myList.Add(ObstacleType.TestObstacle1);
        myList.Add(ObstacleType.TestObstacle1);
        SpawnObstacles(myList);
    }

    public void SpawnObstacles (List<ObstacleType> obstacles)
    {
        foreach (ObstacleType obstacle in obstacles)
        {
            SpawnEachObstacle(obstacleObjects[(int)obstacle]);
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
