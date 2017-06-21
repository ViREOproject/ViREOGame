using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public AudioClip[] tracks;
    public AudioSource audioSource;
    public int currentTrack = 0;
    //use this to stop the last audio track from being called forever
    public bool hasPlayed = false;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if(SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            if (!audioSource.isPlaying && currentTrack < 2)
            {
                playNextTrack();
            }
        }
        else if(SceneManager.GetActiveScene().name.Equals("DevScene"))
        {
            if (!audioSource.isPlaying && currentTrack < 2)
            {
                playNextTrack();
            }
            else if (!audioSource.isPlaying && currentTrack == 2 && !hasPlayed)
            {
                CountdownTimer.count = true;
            }
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
        audioSource.PlayDelayed(0.2f);
        currentTrack = track;
    }

    public void playSpecificTrackOnce(int track)
    {
        audioSource.PlayOneShot(tracks[track]);
        currentTrack = track;
    }
}
