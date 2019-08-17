using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float ShakeAmount; //카메라 흔들리는 힘
    float ShakeTime; //카메라 흔들리는 시간
    Vector3 initialPosition; //카메라 흔들리는 위치



    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }



    private void Start()

    {

        initialPosition = new Vector3(0f, 0f, -10f); //카메라 위치

    }



    private void Update()

    {

        if (ShakeTime > 0)

        { //랜덤으로 카메라의 움직임 힘만큼 카메라의 위치에서 흔들리게

            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;

            ShakeTime -= Time.deltaTime;

        }

        else

        {

            ShakeTime = 0.0f;

            transform.position = initialPosition;

            //canvas.renderMode = RenderMode.ScreenSpaceCamera;

        }

    }
}
