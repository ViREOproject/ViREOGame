using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class handles the transition from one scene to another

public class loadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // these lines are for testing purposes
            // save paintball colour
            GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().setPaintballColour(Settings.PaintballColour.Pink);
            // save ghost size
            GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().setGhostScale(GameObject.FindGameObjectWithTag("Ghost").transform.localScale);
            // save witch size
            GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().setWitchScale(GameObject.FindGameObjectWithTag("Witch").transform.localScale);

            SteamVR_LoadLevel.Begin("DevScene");
        }

	}
}
