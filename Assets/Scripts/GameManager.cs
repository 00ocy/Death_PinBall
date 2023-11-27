using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Progress;

public enum GameState
{
    Ready,
    Play,
    End
}
public class GameManager : MonoBehaviour
{ 
    public GameState gs;

    private bool isPaused = false;

    public TextMeshPro space;
    public GameObject Ball;
    // ���ӿ�����
    private bool gameIsOver = false;
    public GameObject black;
    public GameObject finalWindow;
    public TextMeshPro endScoreText;
    public TextMeshPro highScoreText;
    public Canvas GameOverCanvas;
    public Image buttonImageHome;
    public Image buttonImageRe;
    public bool Stop = false;
    // Stop ���� DeathZone, ObjectSpawner
    
    //public AudioClip readySound;
    //public AudioClip goSound;

    public int score;
    public Text scoreText;

    public int life = 3;
    public Text lifeText;

 
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            scoreText.text = "0";
            lifeText.text = "LIFE : 3";
            Stop = true;
            score = 0;
            life = 3;
        }
    }
    void GameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            gs = GameState.End;

            iTween.FadeTo(black, iTween.Hash("alpha", 180, "delay", 0.1f, "time", 0.5f));
            iTween.MoveTo(finalWindow, iTween.Hash("y", 0, "delay", 0.5f, "time", 1f));

            GameOverCanvas.gameObject.SetActive(true);
            LeanTween.alpha(buttonImageHome.rectTransform, 1f, 1.5f).setEase(LeanTweenType.easeOutQuad).setDelay(1f);
            LeanTween.alpha(buttonImageRe.rectTransform, 1f, 1.5f).setEase(LeanTweenType.easeOutQuad).setDelay(1f);

            if (score > PlayerPrefs.GetInt("hs")) PlayerPrefs.SetInt("hs", score);

            endScoreText.text = score.ToString();
            highScoreText.text = PlayerPrefs.GetInt("hs").ToString();
        }
    }
   
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex !=0)
        {

            scoreText.text = ""+score.ToString();
            lifeText.text = "LIFE : "+life.ToString();
        
            //���ӿ��� �ٽ��ϱ� ��ư���� ���� ���߿�
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
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

            if (life==0)
            {
                GameOver();
            }
                scoreText.text = score.ToString();
        }
    }
    public void Click_Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Click_RePlay()
    {
        SceneManager.LoadScene(2);
    }

    public void Option()
    {
        // Canvas ã��
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameObject canvasObject = GameObject.Find("Canvas");
            // Canvas �������� "Option"�̶�� �̸��� UI�� ã�Ƽ� Ȱ��ȭ
            Transform optionTransform = canvasObject.transform.Find("Option");

            if(optionTransform.gameObject.activeSelf)
            {
                optionTransform.gameObject.SetActive(false);
            }
            else
            {
                optionTransform.gameObject.SetActive(true);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject canvasObject = GameObject.Find("PauseCanvas");
            // Canvas �������� "Option"�̶�� �̸��� UI�� ã�Ƽ� Ȱ��ȭ
            Transform optionTransform = canvasObject.transform.Find("Option");

            if (optionTransform.gameObject.activeSelf)
            {
                optionTransform.gameObject.SetActive(false);
            }
            else
            {
                optionTransform.gameObject.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;

        // Time.timeScale�� ����Ͽ� ���� �Ͻ� ����/�簳
        Time.timeScale = isPaused ? 0f : 1f;

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject canvasObject = GameObject.Find("Canvas");

            Transform optionTransform = canvasObject.transform.Find("PauseCanvas");

            if (optionTransform.gameObject.activeSelf)
            {
                optionTransform.gameObject.SetActive(false);
            }
            else
            {
                optionTransform.gameObject.SetActive(true);
            }
        }
    }

    public void EXIT()
    {
        Application.Quit();
    }

}


