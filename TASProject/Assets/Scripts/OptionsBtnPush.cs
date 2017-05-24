using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBtnPush: MonoBehaviour {

    //SettingsController object. This is where the currentSetting and settings variables exist.
    //We should use this for any other settings management in the options scene
    SettingsController sc;
	// Use this for initialization
	void Start () {
        sc = new SettingsController();    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btnNext()
    {
        //scale setting
        if (sc.currentSetting.Equals(sc.settings[0]))
        {
            //Move the enemies out of view
            GameObject.FindGameObjectWithTag("Witch").transform.position += new Vector3(30,0,0);
            GameObject.FindGameObjectWithTag("Ghost").transform.position += new Vector3(30, 0, 0);
            //This doesn't work to disable the scaling script. We need to find some other way to disable the scaling script
            GetComponent<ScaleEnemies>().enabled = false;

            //Update currentSetting last
            sc.currentSetting = sc.settings[1];
        }
        else if(sc.currentSetting.Equals(sc.settings[1]))
        {

        }
    }

    public void btnPrevious()
    {
        //scale setting
        if (sc.currentSetting.Equals(sc.settings[0]))
        {
            Debug.Log("Previous: Can't go back further");
        }
        //Paint Colour setting
        else if (sc.currentSetting.Equals(sc.settings[1]))
        {
            //Move the enemies into of view
            GameObject.FindGameObjectWithTag("Witch").transform.position -= new Vector3(30, 0, 0);
            GameObject.FindGameObjectWithTag("Ghost").transform.position -= new Vector3(30, 0, 0);
            //This doesn't work to enable the script. We need to find some other way to enable the scaling
            GetComponent<ScaleEnemies>().enabled = true;
            Debug.Log("Previous: paint colour");
            sc.currentSetting = sc.settings[0];
        }
    }
}
