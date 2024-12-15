using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFramerate : MonoBehaviour
{
    public int framerate = 60;

    void Awake()
    {
        Application.targetFrameRate = -1;
    }

    public void SetFramerateMethod()
    {
        Application.targetFrameRate = framerate;
    }
}
