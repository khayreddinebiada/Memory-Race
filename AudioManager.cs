using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static bool IsOnSound = true;

    public static AudioSource[] audio;

    public AudioSource music;
    public AudioSource lose;
    public AudioSource coin;

    public static AudioManager audioManager;

	void Awake ()
    {
        audioManager = this;

	}

    // Use this for initialization
    void Start()
    {
        audio = GetComponentsInChildren<AudioSource>();
        ChangeAudioStatue(Data.SoundIsOn());
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void IsLose()
    {
        music.Pause();
        lose.Play();
    }

    public void IsAddCoins()
    {
        coin.Play();
    }

    public static void ChangeAudioStatue()
    {
        IsOnSound = !IsOnSound;

        foreach (AudioSource aud in audio)
        {
            if (IsOnSound)
            {
                Data.ChangeSound(true);
                aud.volume = 1;
            }
            else
            {
                Data.ChangeSound(false);
                aud.volume = 0;
            }

        }
    }

    public static void ChangeAudioStatue(bool isOn)
    {
        IsOnSound = isOn;

        foreach (AudioSource aud in audio)
        {
            Data.ChangeSound(isOn);
            aud.volume = (isOn) ? 1 : 0;
        }
    }
}
