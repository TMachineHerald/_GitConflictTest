using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DebugMenu : MonoBehaviour
{
    void Start()
    {

    }

    float Timer = 1;
    bool Begin = false;
    int Count = 0;

    public Action E_OnDebugMode;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Begin = true;
            Count++;
            Timer = 0.6F;
            if (Count > 5)
            {
                CallMenu();
            }
        }
        if (Begin)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Begin = false;
                Count = 0;
            }
        }
    }
    public void CallMenu()
    {
        GetComponent<IngameDebugConsole.DebugLogManager>().enabled = true;
    }
}
