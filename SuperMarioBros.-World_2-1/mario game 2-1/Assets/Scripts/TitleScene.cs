using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour {
    public AudioClip titleMusic;
    public Button startButton;
    public Button quitButton;
	// Use this for initialization
	void Start () {
        resetGame();
        if (!startButton)
            Debug.LogError("Programmer Log: startButton not found");
        else
            startButton.onClick.AddListener(delegate { GameManager.instance.loadScene("Level1"); });
        if (!quitButton)
            Debug.LogError("Programmer Log: quitButton not found");
        else
            quitButton.onClick.AddListener(GameManager.instance.quit);
        playMusic(titleMusic);

	}
	
	private void playMusic(AudioClip music)
    {
        SoundManager.instance.playMusic(music);
    }

    /*
     * Mục đích: Khôi phục các giá trị trò chơi toàn cầu để có thể chơi lại mà không cần thoát, đồng thời liên kết các nút trên Màn hình Tiêu đề với GameManager
     */
    private void resetGame()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 2;
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
    }
}
