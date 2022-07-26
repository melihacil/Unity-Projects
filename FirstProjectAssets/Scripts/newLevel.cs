using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
