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

    public TextMeshPro space;
    public GameObject Ball;
    // 게임오버용
    public GameObject black;
    public GameObject finalWindow;
    public TextMeshPro endScoreText;
    public TextMeshPro highScoreText;

    public bool Stop = false;
    // Stop 영향 DeathZone, ObjectSpawner
    
    //public AudioClip readySound;
    //public AudioClip goSound;

    public int score;
    public Text scoreText;

    public int life;
    public Text lifeText;

 
    void Start()
    {

        scoreText.text = "0";
        lifeText.text = "LIFE : 3";
        Stop = true;
        score = 0;
        life = 3;
        
    }
    void GameOver()
    {
        gs = GameState.End;
        // 캐릭터 생성 멈추기 추가
        // 플립퍼 동작 멈추기 추가

        iTween.FadeTo(black, iTween.Hash("alpha", 180, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(finalWindow, iTween.Hash("y", 0, "delay", 0.5f, "time", 1f));

        if (score > PlayerPrefs.GetInt("hs")) PlayerPrefs.SetInt("hs", score);

        endScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("hs").ToString();
    }

    void Update()
    {
        scoreText.text = ""+score.ToString();
        lifeText.text = "LIFE : "+life.ToString();
        
        //게임오버 다시하기 버튼으로 빼기 나중에
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stop = false;
            space.gameObject.SetActive(false);
            Ball.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (Stop&&life!=0)
        {
            space.gameObject.SetActive(true);
        }
        //if (gs == GameState.Play)
        //{

        if (life==0)
            {
              
                GameOver();
            }

            scoreText.text = score.ToString();
        //}
    }


}


