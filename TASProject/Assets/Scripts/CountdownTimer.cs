using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    public float time;
    int timeDisplay;
    public Text text;
    public static bool count;
    bool amHasUpdate;
    AudioManager am;

	// Use this for initialization
	void Start () {
        count = false;
        amHasUpdate = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (count)
        {
            if (!amHasUpdate)
            {
                am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
                amHasUpdate = true;
            }

            time -= Time.deltaTime;
            timeDisplay = (int)time;
            text.text = "Time: " + timeDisplay.ToString();



            //plays audio clips that correspond to remaining time left
            if(Convert.ToInt32(time) == 60)
            {
                am.playSpecificTrack(13);
            }
            else if(Convert.ToInt32(time) == 30)
            {
                am.playSpecificTrack(14);
            }
            else if(Convert.ToInt32(time) == 10)
            {
                am.playSpecificTrack(15);
            }
            else if(time < 0)
            {
                //Debug.Log("time is up");
                am.playSpecificTrackOnce(16);
                gameOver();
            }
        }
	}

    void gameOver()
    {
        //stop keeping score and spawning new enemies
        count = false;
        Score_Manager.setActiveFalse();
        EnemyManager.destroyAllEnemies();
        Destroy(GameObject.FindGameObjectWithTag("Respawn"));
    }
}
