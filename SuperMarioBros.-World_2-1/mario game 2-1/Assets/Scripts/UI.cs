using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text scoreDisplay;
    public Text timeDisplay;
    public Text worldDisplay;
    public Text coinDisplay;
    public Text livesDisplay;
    public Toggle soundToggle;// nút chuyển âm thanh
    public Toggle musicToggle;// nút chuyển nhạc
    public CanvasGroup pauseMenu; // menu tạm dừng
    // Use this for initialization
    void Start ()
    {
        scoreDisplay.text = "Score\n" + GameManager.instance.score.ToString("0000");// điểm số
        timeDisplay.text = "Time\n" + GameManager.instance.clock.ToString("000");// thời gian
        worldDisplay.text = "World\n2-1";
        coinDisplay.text = "Coins\n" + GameManager.instance.coins.ToString("00");
        livesDisplay.text = "Lives\n" + GameManager.instance.lives;

        // Theo sự kiến mà thay đổi âm thanh .
        soundToggle.onValueChanged.AddListener(delegate { soundValueChanged(soundToggle); });
        musicToggle.onValueChanged.AddListener(delegate { musicValueChanged(musicToggle); });
	}
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = "Score\n" + GameManager.instance.score.ToString("0000");
        timeDisplay.text = "Time\n" + GameManager.instance.clock.ToString("000");
        worldDisplay.text = "World\n2-1";
        coinDisplay.text = "Coins\n" + GameManager.instance.coins.ToString("00");
        livesDisplay.text = "Lives\n" + GameManager.instance.lives;
        if(GameManager.instance.pause == true)
        {
            pauseMenu.alpha = 1;
            pauseMenu.interactable = true;
            pauseMenu.blocksRaycasts = true;
        }
        else
        {
            pauseMenu.alpha = 0;
            pauseMenu.interactable = false;
            pauseMenu.blocksRaycasts = false;
        }
    }

    void soundValueChanged(Toggle change)
    {
        SoundManager.instance.sfxSource.mute = change.isOn;
    }

    void musicValueChanged(Toggle change)
    {
        SoundManager.instance.musicSource.mute = change.isOn;
    }
}
