using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    private bool isGameStarted;
    public bool IsGameStarted
    {
        get { return isGameStarted; }
        set { isGameStarted = value; }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void FixedUpdate()
    {
        if (isGameStarted)
        Time.timeScale += 0.001f;
    }
}
