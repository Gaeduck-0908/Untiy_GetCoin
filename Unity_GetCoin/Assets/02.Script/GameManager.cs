using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Lib;

public class GameManager : Singleton<GameManager>
{
    //���ӻ�Ȳ
    public bool IsPause;

    private void Update()
    {
        MainChanger();
        if(IsPause == false)
        {
            return;
        }

        if(IsPause == true)
        {
            TitleChanger();
            return;
        }
    }

    void MainChanger()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Main");
                IsPause = false;
            }
        }
    }

    void TitleChanger()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
