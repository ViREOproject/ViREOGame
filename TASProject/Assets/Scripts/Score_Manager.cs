using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {

    public static int score;        // The player's score.


    Text text;

    // Use this for initialization
    void Start () {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }
}
