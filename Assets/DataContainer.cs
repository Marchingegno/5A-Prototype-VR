using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class DataContainer : MonoBehaviour
{
    private static DataContainer instance = null;
    /*
     * Variable indexed by [scenario*level]
     * Represents if the level in that scenario has been completed.
     * 0 = 1.1
     * 1 = 1.2
     * 2 = 1.3
     * 3 = 2.1
     * 4 = 2.2
     * 5 = 2.3
     * 6 = 3.1
     * 7 = 3.2
     */
    
    public bool[] levelCompleted;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(transform.gameObject);
        
        levelCompleted = new bool[7]; //bool is initialized as false

    }

    public void CompleteLevel(int level)
    {
        if (level >= levelCompleted.Length) return;
        levelCompleted[level] = true;
    }

    public static DataContainer GetInstance()
    {
        return instance;
    }
    
    


}
