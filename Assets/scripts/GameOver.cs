using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : Singleton<GameOver>
{
    public GameObject GameoverUI;
    public bool gameover = false;
    

    private void Start()
    {
        GameoverUI.SetActive(false);
    }

    private void LateUpdate()
    {
        if (PlayerCrash.Instance.hp <= 0)
        {
            GameoverUI.SetActive(true);
            gameover = true;
            Time.timeScale = 0;
            PauseMenu.Instance.freeze = true;
        }
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
