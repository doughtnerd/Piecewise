using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Obstacle[] obstacleObjects;

    // TESTING: DELETE THIS
    public Obstacle[] testingArray;

    public GameObject flatObstacle;

    private ObstacleSize previousObstacleSize;
    private Vector3 previousObstaclePos;


    private readonly int sizeOfBlock = 1;
    private readonly float yPos = -3.268487f;
    private readonly float initialXPos = 4.31055f;

    private float nextSpawnPosition;


    // Use this for initialization
    void Start () {
        nextSpawnPosition = initialXPos;

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
        SpawnEachObstacle(flatObstacle);
    }


    private void SpawnEachObstacle(GameObject obstacle)
    {
        //if (nextSpawnPosition != initialXPos)
        //{
        //    nextSpawnPosition += obstacle.GetComponent<ObstacleSize>().width / 2.0f;
        //}

        Instantiate(obstacle, new Vector3(nextSpawnPosition, yPos), Quaternion.identity);

        float pos = obstacle.transform.position.x;
        pos += obstacle.GetComponent<ObstacleSize>().width / 2.0f;
        nextSpawnPosition = pos;
    }

    //private void SpawnEachObstacle(GameObject obstacle)
    //{
    //    int previousWidth = 0;
    //    if (previousObstacleSize != null)
    //    {
    //        previousWidth = previousObstacleSize.width;
    //    }

    //    float xPos = 0.0f;
    //    if (previousObstacleSize == null)
    //    {
    //        xPos = initialXPos;
    //    }

    //    if (previousObstaclePos != null)
    //    {
    //        xPos += previousObstaclePos.x;
    //        if (previousObstacleSize != null)
    //        {
    //            xPos += previousObstacleSize.width / 2 + obstacle.GetComponent<ObstacleSize>().width / 2;
    //        }
    //    }

    //    Vector3 pos = new Vector3(xPos, yPos, 0.0f);

    //    Instantiate(obstacle, pos, Quaternion.identity);
    //    previousObstacleSize = obstacle.GetComponent<ObstacleSize>();
    //    previousObstaclePos = pos;
    //}
}
