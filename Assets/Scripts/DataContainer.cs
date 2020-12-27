using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/**
 * This class will be used as a data container between scenes. It is a singleton, and persists with its data on scene changes.
 */
public class DataContainer : MonoBehaviour
{
    private static DataContainer instance;
    
    /**
     * This bool is set to true the first time the game is launched.
     * If true, we must show the introductory screen when it loads the first scene.
     * Otherwise, we show level selection directly.
     */
    private bool firstStart;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            firstStart = true;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool IsFirstStart()
    {
        return firstStart;
    }

    public void SetFirstStart(bool firstStart_)
    {
        firstStart = firstStart_;
    }

    public static DataContainer GetInstance()
    {
        return instance;
    }
    
    


}
