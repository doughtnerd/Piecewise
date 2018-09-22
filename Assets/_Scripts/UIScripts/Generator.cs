using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

    public GameObject block;
    private GameObject[,] blockArray;
    public int length;
    public int xoffset;
    public int yoffset;

    public GameObject cover;
    private double opacity = 0;
    private bool increase = true;
    public double changeRate;

	// Use this for initialization
	void Start () {

        CreateMap();
	}

    // Update is called once per frame
    void Update() {
        double change = changeRate * Time.deltaTime;
        if (!increase)
        {
            change *= -1;
        }

        opacity += change;

        if (opacity > 255)
        {
            opacity = 255;
            increase = false;
            DestroyMap();
            CreateMap();
        }
        if(opacity < 0)
        {
            opacity = 0;
            increase = true;
        }

        cover.GetComponent<Image>().color = new Color(0, 0, 0, (float)(opacity / 255));

	}

    private void DestroyMap()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < 5; j++)
            {

                Destroy(blockArray[i, j]);
                blockArray[i, j] = null;

            }
        }

    }
    private void CreateMap()
    {
        blockArray = new GameObject[length, 5];
        SetTiles();
        int timesRepeat = Random.Range(3, 6);
        for (int i = 0; i < timesRepeat; i++)
        {
            RemoveTiles(Random.Range(5, length - 3));
        }

        IncreaseHeight();
        DecreaseValleys();

        AddAboveLongValleys();
    }

    private void SetTiles()
    {
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < 2; j++)
            {

                blockArray[i,j] = Instantiate(block, new Vector3(i - xoffset, j - yoffset, 0), Quaternion.identity);

            }
        }
    }

    private void RemoveTiles(int num)
    {

        for(int j = 0; j < 5; j++)
        {
            Destroy(blockArray[num, j]);
            blockArray[num, j] = null;
        }

    }

    private void IncreaseHeight()
    {
        for(int i = 2; i < length; i++)
        {

            if (blockArray[i,1] == null)
            {
                if (blockArray[i-1,1] != null)
                {
                    blockArray[i - 1, 2] = Instantiate(block, new Vector3(i - 1 - xoffset, 2 - yoffset, 0), Quaternion.identity);
                    if (blockArray[i - 2, 1] != null)
                    {
                        blockArray[i - 2, 2] = Instantiate(block, new Vector3(i - 2 - xoffset, 2 - yoffset, 0), Quaternion.identity);
                        blockArray[i - 1, 3] = Instantiate(block, new Vector3(i - 1 - xoffset, 3 - yoffset, 0), Quaternion.identity);
                    }
                }


            }

        }
    }

    private void DecreaseValleys()
    {

        for(int i = 3; i < length; i++)
        {

            if(blockArray[i, 2] == null && blockArray[i-1, 2] == null && blockArray[i-2, 2] == null)
            {
                Destroy(blockArray[i - 2, 1]);
                blockArray[i - 2, 1] = null;
            }


        }

    }

    private void AddAboveLongValleys()
    {
        int numValleySquares = 0;
        for(int i = 0; i < length; i++)
        {
            if(blockArray[i, 1] == null)
            {
                numValleySquares++;
            }
            else
            {
                numValleySquares = 0;
            }

            if(numValleySquares >= 2)
            {
                blockArray[i, 3] = Instantiate(block, new Vector3(i - xoffset, 3 - yoffset, 0), Quaternion.identity);
            }

        }

    }

    private void RemoveVariableMountainTops()
    {
        for(int i = 0; i < length; i++)
        {
            if(Random.Range(0, 1.0f) <= .2f)
            {
                Destroy(blockArray[i, 2]);
                blockArray[i, 2] = null;
            }
        }
    }

}
