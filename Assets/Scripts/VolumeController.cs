using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private GameObject schermataVolume;
    private static VolumeController instance;

    /**
     * These two are the audiosources in the game. Since this object is a singleton, every time the scene loads
     * it searches for these and sets the volume.
     */
    private AudioSource gameSoundsSource;
    private AudioSource dialoguesSource;

    /**
     * These two are the amount of volume chosen by the user. Ranges from 0 to 10, will be divided by 10 when assigned
     * to sources.
     */
    private int mainVolumeAmount;
    private int gameSoundsVolumeAmount;

    /**
     * These two are the gameobjects that contains the 10 sprites of the menu.
     */
    private GameObject mainVolume;
    private GameObject gameSoundsVolume;


    public void SetSchermate(GameObject mainVolume_, GameObject gameSoundsVolume_)
    {
        mainVolume = mainVolume_;
        gameSoundsVolume = gameSoundsVolume_;
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            mainVolumeAmount = 5;
            gameSoundsVolumeAmount = 5;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static VolumeController GetInstance()
    {
        return instance;
    }

    private void ChangeVolume()
    {
        dialoguesSource.volume = (float)mainVolumeAmount / 10;
        gameSoundsSource.volume = (float)(mainVolumeAmount * gameSoundsVolumeAmount) / 100;
    }

    public void OnSceneChange()
    {
        gameSoundsSource = GameObject.FindGameObjectWithTag("GameSoundsSource").GetComponent<AudioSource>();
        dialoguesSource = GameObject.FindGameObjectWithTag("DialoguesSource").GetComponent<AudioSource>();
        ChangeVolume();
    }

    public void SetMainVolume(int amount)
    {
        mainVolumeAmount = amount;
        ChangeVolume();
        Feedback();
        UpdateInterface();
    }

    public void SetGameSoundsVolume(int amount)
    {
        gameSoundsVolumeAmount = amount;
        ChangeVolume();
        Feedback();
        UpdateInterface();
    }


    private void Feedback()
    {
        FindObjectOfType<GameController>().PositiveFeedback();
    }

    public void UpdateInterface()
    {
        FindObjectOfType<GameController>().WriteInConsole("Start UpdateInterface");
        
        /*SpriteRenderer[] mainVolumeSprites = mainVolume.GetComponentsInChildren<SpriteRenderer>();
        FindObjectOfType<GameController>().WriteInConsole("Found volume sprites array 1");
        var gameSoundsSprites = gameSoundsVolume.GetComponentsInChildren<SpriteRenderer>();
        FindObjectOfType<GameController>().WriteInConsole("Found volume sprites array 2");
        */
        
        /*
         * Disable only blue sprites (the first 10)
         */
        SpriteRenderer[] mainVolumeSprites = new SpriteRenderer[10];
        SpriteRenderer[] gameSoundsSprites = new SpriteRenderer[10];
        for (var i = 0; i < 10; i++)
        {
            mainVolumeSprites[i] = mainVolume.transform.GetChild(i).GetComponent<SpriteRenderer>();
            mainVolumeSprites[i].enabled = false;
            gameSoundsSprites[i] = gameSoundsVolume.transform.GetChild(i).GetComponent<SpriteRenderer>();
            gameSoundsSprites[i].enabled = false;
        }
        
        FindObjectOfType<GameController>().WriteInConsole(mainVolumeAmount.ToString());
        mainVolumeSprites[mainVolumeAmount - 1].enabled = true;
        FindObjectOfType<GameController>().WriteInConsole(gameSoundsVolumeAmount.ToString());
        gameSoundsSprites[gameSoundsVolumeAmount - 1].enabled = true;
    }
    
}
