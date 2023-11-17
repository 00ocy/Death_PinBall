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

    public GameObject black;


    public AudioClip readySound;
    public AudioClip goSound;

    public int score;
    public Text scoreText;

    public int life;
    public Text lifeText;
    // 게임오버용
    //public GameObject black;
    //public Text endScoreText;
    //public Text highScoreText;
    //public GameObject finalWindow;

 
    void Start()
    {

        scoreText.text = "0";
        lifeText.text = "LIFE : 3";
        score = 0;
        life = 3;
    }
    /*void GameOver()
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
        lifeText.text = "LIFE : "+life.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
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


