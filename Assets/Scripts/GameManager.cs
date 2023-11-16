using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState
{
    Ready,
    Play,
    End
}
public class GameManager : MonoBehaviour
{ 
    public GameState gs;

    public AudioClip readySound;
    public AudioClip goSound;

    public int score;

    public Text scoreText;

    // 게임오버용
    //public GameObject black;
    //public Text endScoreText;
    //public Text highScoreText;
    //public GameObject finalWindow;

    AudioSource m_audioSource;

    void PlaySound(AudioClip ac)
    {
        m_audioSource.clip = ac;
        m_audioSource.Play();
    }

    public void Go()
    {
        gs = GameState.Play;
        PlaySound(goSound);
    }

    void Start()
    {

        m_audioSource = GetComponent<AudioSource>();
        PlaySound(readySound);
        scoreText.text = "0";
        score = 0;
    }
    //게임오버용
 /*   void GameOver()
    {
        gs = GameState.End;
        iTween.FadeTo(black, iTween.Hash("alpha", 180, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(finalWindow, iTween.Hash("y", 1, "delay", 0.5f, "time", 0.5f));

        if (score > PlayerPrefs.GetInt("hs")) PlayerPrefs.SetInt("hs", score);

        endScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("hs").ToString();
    }*/

    void Update()
    {
        scoreText.text = ""+score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Lv.1");
        }

        if (gs == GameState.Play)
        {
            //종료조건 life ==0
            if (false)
            {
              
                //GameOver();
            }

            scoreText.text = score.ToString();
        }
    }


    }


