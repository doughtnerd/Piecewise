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
    private float firstSpawnPosition;


    // Use this for initialization
    void Start () {
        nextSpawnPosition = initialXPos;

        firstSpawnPosition = flatObstacle.GetComponent<ObstacleSize>().width / 2;

        // TESTING
        List<Obstacle> testList = new List<Obstacle>(testingArray);
        SpawnObstacles(testList, true);
    }

    public void SpawnObstacles (List<Obstacle> obstacles, bool firstTime=false)
    {
        if (firstTime)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                SpawnEachObstacle(obstacles[i].prefab);
            }
            SpawnEachObstacle(flatObstacle);
        }

        if (!firstTime)
        {
            Vector3 firstPos = new Vector3(firstSpawnPosition + obstacles[0].prefab.GetComponent<ObstacleSize>().width / 2 - initialXPos, yPos);
            GameObject obj = Instantiate(obstacles[0].prefab, firstPos, Quaternion.identity);
            nextSpawnPosition = obj.transform.position.x + obstacles[0].prefab.GetComponent<ObstacleSize>().width / 2;

            for (int i = 1; i < obstacles.Count; i++)
            {
                SpawnEachObstacle(obstacles[i].prefab);
            }
            SpawnEachObstacle(flatObstacle);
        }
    }


    private void SpawnEachObstacle(GameObject obstacle)
    {
        if (nextSpawnPosition != initialXPos)
        {
            nextSpawnPosition += obstacle.GetComponent<ObstacleSize>().width / 2.0f;
        }

        GameObject obj = Instantiate(obstacle, new Vector3(nextSpawnPosition, yPos), Quaternion.identity);

        float pos = obj.transform.position.x;
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
