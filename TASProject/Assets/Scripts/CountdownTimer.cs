using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    public float time;
    int timeDisplay;
    public Text text;
    public bool count;

	// Use this for initialization
	void Start () {
        count = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (count)
        {
            time -= Time.deltaTime;
            timeDisplay = (int)time;
            text.text = "Time: " + timeDisplay.ToString();

            if (time < 0)
            {
                count = false;
                gameOver();
            }
        }
	}

    void gameOver()
    {
        //put game ending stuff here
    }
}
