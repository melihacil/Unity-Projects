using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public Text scoreText;

    bool gameEnded = false;
    public float restartDelay = 1f;

    public void CompleteLevel()
    {
        Debug.Log("wowowowoLEVEL WON");
        completeLevelUI.SetActive(true);
        scoreText.enabled = false;
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            Debug.Log("GAME OVER");
            gameEnded = true;
            //restart game
            Invoke("Restart", restartDelay);
            
            //Restart();
        }

    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
