using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour {

    AudioManager am;

    // Use this for initialization
    void Start () {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleChange()
    {
        am.audioSource.Stop();
        SteamVR_LoadLevel.Begin("DevScene");
    }
}
