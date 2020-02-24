using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlUI : MonoBehaviour {

    public GameObject startPanel;
    public GameObject losePanel;
    public GameObject onPlayPanel;
    public GameObject howToPlayPanel;
    public GameObject buyCarPanel;

    public Sprite spriteOnSound;
    public Sprite spriteOffSound;

    public Image TurnImage;
    public Image imageSound;
    public Text currentScoreTextLoss;
    public Text bestScoreTextLoss;
    public Text coinsTextLoss;

    public Text currentScoreTextOnPlay;
    public Text bestScoreTextMenu;
    public Text coinsTextMenu;
    public Text textCoinsOnPlay;

    public Text carPrice;
    public Text buyResult;
    public Button playButton;

    private int totalCoins = 0;
    public static ControlUI controlUI;

	void Awake () {
        controlUI = this;
	}

    // Use this for initialization
    void Start()
    {
        bestScoreTextMenu.text = Data.GetBestScore().ToString();
        coinsTextMenu.text = Data.GetTotalCoins().ToString();

        if (AudioManager.IsOnSound)
        {
            imageSound.sprite = spriteOnSound;
        }
        else
        {
            imageSound.sprite = spriteOffSound;
        }

    }

	// Update is called once per frame
    void Update()
    {
        TurnImage.transform.localScale = new Vector3((Player.player.moveDirection == Player.MoveDirection.Right) ? 1 : -1, 1, 1);
        currentScoreTextOnPlay.text = Player.currentScore.ToString();
	}

    public void LoseGame()
    {
        onPlayPanel.SetActive(false);
        losePanel.SetActive(true);
        Data.SetBestScore(Player.currentScore);
        currentScoreTextLoss.text = Player.currentScore.ToString();
        bestScoreTextLoss.text = Data.GetBestScore().ToString();
        coinsTextLoss.text = totalCoins.ToString();
        Data.AddTotalCoins(totalCoins);
    }

    public void AddCoin()
    {
        totalCoins++;
        textCoinsOnPlay.text = totalCoins.ToString();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToURL(string url)
    {
        Application.OpenURL(url);
    }

    public void AudioClick()
    {
        AudioManager.ChangeAudioStatue();

        if (AudioManager.IsOnSound)
        {
            imageSound.sprite = spriteOnSound;
        }
        else
        {
            imageSound.sprite = spriteOffSound;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void StartPlay()
    {
        Time.timeScale = 1;
        Player.isStart = true;
        Player.player.isMove = true;
    }

    public void GoToNextCar()
    {
        CarInfo carInfo = SelectCar.instance.NextCar();

        buyCarPanel.SetActive(!carInfo.isOpened);
        carPrice.text = carInfo.price.ToString();

        playButton.enabled = carInfo.isOpened;

        buyResult.gameObject.SetActive(false);
    }

    public void GoToPrevCar()
    {
        CarInfo carInfo = SelectCar.instance.PrevCar();

        buyCarPanel.SetActive(!carInfo.isOpened);
        carPrice.text = carInfo.price.ToString();

        playButton.enabled = carInfo.isOpened;
        buyResult.gameObject.SetActive(false);
    }

    public void BuyCar()
    {
        bool isBuyed = SelectCar.instance.BuyCar();

        if (isBuyed)
        {
            playButton.enabled = true;
            coinsTextMenu.text = Data.GetTotalCoins().ToString();
            buyCarPanel.SetActive(false);
            buyResult.gameObject.SetActive(true);
        }
        else
        {
            buyResult.gameObject.SetActive(true);
            buyResult.text = "Sorry! You can't buy this car.";
            buyCarPanel.SetActive(true);
        }
    }
}
