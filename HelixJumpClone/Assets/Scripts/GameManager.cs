using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelWin;

    [SerializeField] GameObject gameOverPannal;
    [SerializeField] GameObject levelWinPannal;

    public static int currentLevelIndex;
    public static int noOfPassingRings;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public Slider proggressBar;
    internal static bool mute = false;

    private void Awake()
    {
        currentLevelIndex =PlayerPrefs.GetInt("currentLevelIndex",1);

    }

    private void Start()
    {
        Time.timeScale = 1f;
        noOfPassingRings =0;
        gameOver = false;
        levelWin = false;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale =0;
            gameOverPannal.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text =(currentLevelIndex + 1).ToString();

        //update slider
        int proggress =noOfPassingRings * 100 / FindObjectOfType<HellixManager>().countOfRings;
        proggressBar.value = proggress;

        if (levelWin)
        {
            levelWinPannal.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
        
    }
}
