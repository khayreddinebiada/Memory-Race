using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    private static string sTotalCoins = "Total Coins";
    private static string sBestScore = "Best Score";
    private static string sHowToPlay = "How To Play";
    private static string sSound = "On Sound";
    private static string sCarIsOpen = "Car Is Opened";

	// Use this for initialization
	void Awake () {
        if (!PlayerPrefs.HasKey(sSound))
            PlayerPrefs.SetInt(sSound, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool CarIsOpened(int ind)
    {
        return (PlayerPrefs.GetInt(sCarIsOpen + ind) == 1 && PlayerPrefs.HasKey(sCarIsOpen + ind)) ? true : false;
    }

    public static void SetCarOpened(int ind, bool isOpened)
    {
        PlayerPrefs.SetInt(sCarIsOpen + ind, (isOpened) ? 1 : -1);
    }

    public static bool IsShowedHowToPlay()
    {
        bool isHas = PlayerPrefs.HasKey(sHowToPlay);

        PlayerPrefs.SetInt(sHowToPlay, 1);
        return isHas;
    }
    
    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(sBestScore);
    }

    public static void SetBestScore(int score)
    {
        if (GetBestScore() < score)
        {
            PlayerPrefs.SetInt(sBestScore, score);
        }
    }
    
    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(sTotalCoins);
    }

    public static void SetTotalCoins(int coins)
    {
        PlayerPrefs.SetInt(sTotalCoins, coins);
    }
    
    public static void AddTotalCoins(int coins)
    {
        PlayerPrefs.SetInt(sTotalCoins, GetTotalCoins() + coins);
    }
    
    public static bool SoundIsOn()
    {
        return (PlayerPrefs.GetInt(sSound) == 1 || !PlayerPrefs.HasKey(sSound)) ? true : false;
    }

    public static void ChangeSound(bool isOn)
    {
        PlayerPrefs.SetInt(sSound, (isOn) ? 1 : 0);
    }
}
