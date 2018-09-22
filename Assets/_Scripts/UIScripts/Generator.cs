using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject block;
    private GameObject[,] blockArray;
    public int length;
    public int xoffset;
    public int yoffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateMap()
    {

    }

    private void SetTiles()
    {
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < 5; j++)
            {

                Instantiate(block, new Vector3(i - xoffset, j - yoffset, 0), Quaternion.identity);

            }
        }
    }
}
