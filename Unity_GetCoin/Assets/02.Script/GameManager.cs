using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class GameManager : Singleton<GameManager>
{
    public bool IsPause;

    private void Start()
    {
        IsPause = false;
    }

    private void Update()
    {
        if(IsPause == false)
        {
            Time.timeScale = 0;
            return;
        }

        if(IsPause == true)
        {
            Time.timeScale = 1;
            return;
        }
    }
}
