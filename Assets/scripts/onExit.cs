using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onExit : MonoBehaviour
{
    public void goExit()
    {
        {
            Application.Quit();
            Debug.Log("Exit click");
        }
    }
}
