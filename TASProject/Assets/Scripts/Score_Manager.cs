using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {

    public static int score;        // The player's score.
    static bool active;      // If the timer is still counting down
    static AudioManager am;

    static Text text;

    // Use this for initialization
    void Start () {
        // Set up the reference.
        text = GetComponent<Text>();
        // Reset the score.
        score = 0;
        active = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }


    public static void updateScore(int scoreValue)
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        if (active)
        {
            score += scoreValue;
            text.text = "Score: " + (score);
            annouceScore();
        }
    }

    public static void annouceScore()
    {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        switch (score)
        {
            case 20:
                am.playSpecificTrack(2);
                break;
            case 40:
                am.playSpecificTrack(3);
                break;
            case 60:
                am.playSpecificTrack(4);
                break;
            case 80:
                am.playSpecificTrack(5);
                break;
            case 100:
                am.playSpecificTrack(6);
                break;
            case 150:
                am.playSpecificTrack(7);
                break;
            case 200:
                am.playSpecificTrack(8);
                break;
            case 250:
                am.playSpecificTrack(9);
                break;
            case 300:
                am.playSpecificTrack(10);
                break;
            case 350:
                am.playSpecificTrack(11);
                break;
            case 400:
                am.playSpecificTrack(12);
                break;
            default:
                break;
        }
    }
    //this will stop counting the score
    public static void setActiveFalse()
    {
        active = false;
    }
}
