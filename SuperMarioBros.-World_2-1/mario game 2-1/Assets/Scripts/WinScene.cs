using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    private float t;
    // Thời gian đã trôi qua
    public AudioClip winMusic;

    // Âm nhạc chiến thắng
    // Use this for initialization
    void Start () {
        t = 0.0f;// Khởi tạo thời gian
        playMusic(winMusic);  // Phát nhạc chiến thắng
    }
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;// Tăng thời gian

        if (t >= 5.5)// Nếu đã đủ thời gian
            loadScene("TitleScreen");// Tải cảnh màn hình tiêu đề
    }

    private void playMusic(AudioClip music)
    {
        SoundManager.instance.playMusic(music, false);
        // Sử dụng SoundManager để phát nhạc
    }

    private void loadScene(string scene)
    {
        GameManager.instance.loadScene(scene);
        // Sử dụng GameManager để tải cảnh
    }
}
