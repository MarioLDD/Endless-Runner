using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameOver)
        {
            Time.timeScale = 0f;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void ResetGame()
    {
        SpawnObjet.velocity = 4f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
