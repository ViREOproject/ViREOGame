using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] tracks;
    public AudioSource audioSource;
    public int currentTrack = 0;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!audioSource.isPlaying&&currentTrack<1)
        {
            playNextTrack();
        }
	}

    public void playNextTrack()
    {
        audioSource.clip = tracks[currentTrack];
        audioSource.PlayDelayed(0.5f);
        currentTrack++;
    }

    public void playSpecificTrack(int track)
    {
        audioSource.clip = tracks[track];
        audioSource.PlayDelayed(0.5f);
    }
}
