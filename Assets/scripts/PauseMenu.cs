using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Singleton<PauseMenu>
{
    public GameObject PauseUI;

    public bool freeze = false;

    private bool paused = false;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    private void Update()
    {
        if (!GameOver.Instance.gameover)
        {
            if (Input.GetButtonDown("Pause"))
            {
                paused = !paused;
                freeze = !freeze;
            }

            if (paused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }

            if (!paused)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        paused = false;
        freeze = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Mainmenu()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
