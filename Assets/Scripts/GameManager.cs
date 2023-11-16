using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public Text scoreText;
    public int score;

    void Start()
    {
        score = 0;
    }


    void Update()
    {
        scoreText.text = ""+score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Lv.1");
        }


    }

}
