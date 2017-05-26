using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBtnPush: MonoBehaviour {

    //SettingsController object. This is where the currentSetting and settings variables exist.
    //We should use this for any other settings management in the options scene
    public static SettingsController sc;
    public GameObject paintSplatter;
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

            //Instantiate a paint splatter
            ScaleEnemies.paintSplatter = Instantiate(paintSplatter, new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));

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

            Debug.Log("Previous: paint colour");
            sc.currentSetting = sc.settings[0];
        }
    }
}
