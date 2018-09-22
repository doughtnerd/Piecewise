using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacement : MonoBehaviour {

    public Transform startNode;
    public Transform endNode;

    public Vector3 GetStartNodePosition()
    {
        return gameObject.transform.TransformPoint(startNode.position);
    }

    public Vector3 GetEndNodePosition()
    {
        return gameObject.transform.TransformPoint(endNode.position);
    }

    public Vector3 GetMiddlePosition()
    {
        return (GetStartNodePosition() - GetEndNodePosition()) / 2;
    }
}
