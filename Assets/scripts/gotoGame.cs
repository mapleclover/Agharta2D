using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoGame : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
