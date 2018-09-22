using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieCredits : MonoBehaviour {

    public List<string> names;
    private Queue<string> credits;
    private double opacity = 0.1;
    private bool increase = true;
    private double change;
    [Range(20, 100)]
    public double textChangeSpeed;
    private Text currentName;

	// Use this for initialization
	void Start () {

        currentName = gameObject.GetComponent<Text>();

        credits = new Queue<string>();
		foreach(string name in names)
        {
            credits.Enqueue(name);
        }

        ChangeName();
	}
	
	// Update is called once per frame
	void Update () {

        if (increase)
        {
            change = textChangeSpeed;
        }
        else
        {
            change = -textChangeSpeed;
        }

        opacity += change * Time.deltaTime;

        if(opacity > 255)
        {
            opacity = 255;
            increase = false;
        }
        if(opacity < 0)
        {
            opacity = 0;
            increase = true;

            ChangeName();

        }

        currentName.color = new Color(255, 255, 255, (float)(opacity/255));

	}

    private void ChangeName()
    {
        if(credits.Count > 0)
        {
            currentName.text = credits.Dequeue();
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
