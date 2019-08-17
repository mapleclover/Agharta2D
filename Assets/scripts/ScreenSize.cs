using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1280, 768, true);
    }
}
