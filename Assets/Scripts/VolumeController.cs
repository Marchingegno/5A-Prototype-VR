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
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            mainVolumeAmount = 5;
            gameSoundsVolumeAmount = 5;
            UpdateInterface();
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

    public void OnSceneChange()
    {
        gameSoundsSource = GameObject.FindGameObjectWithTag("GameSoundsSource").GetComponent<AudioSource>();
        dialoguesSource = GameObject.FindGameObjectWithTag("DialoguesSource").GetComponent<AudioSource>();

        dialoguesSource.volume = mainVolumeAmount;
        gameSoundsSource.volume = mainVolumeAmount * gameSoundsVolumeAmount;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainVolume = GameObject.FindWithTag("MainVolume");
            gameSoundsVolume = GameObject.FindWithTag("GameSoundsVolume");
            UpdateInterface();
        }
        
        

    }

    public void SetMainVolume(int amount)
    {
        mainVolumeAmount = amount;
        gameSoundsSource = GameObject.FindGameObjectWithTag("GameSoundsSource").GetComponent<AudioSource>();
        dialoguesSource = GameObject.FindGameObjectWithTag("DialoguesSource").GetComponent<AudioSource>();

        dialoguesSource.volume = (float)mainVolumeAmount / 10;
        gameSoundsSource.volume = (float)(mainVolumeAmount * gameSoundsVolumeAmount) / 100;
        UpdateInterface();
    }

    public void SetGameSoundsVolume(int amount)
    {
        gameSoundsVolumeAmount = amount;
        gameSoundsSource = GameObject.FindGameObjectWithTag("GameSoundsSource").GetComponent<AudioSource>();
        dialoguesSource = GameObject.FindGameObjectWithTag("DialoguesSource").GetComponent<AudioSource>();

        dialoguesSource.volume = (float)mainVolumeAmount / 10;
        gameSoundsSource.volume = (float)(mainVolumeAmount * gameSoundsVolumeAmount) / 100;
        UpdateInterface();
    }

    private void UpdateInterface()
    {
        var mainVolumeSprites = mainVolume.GetComponentsInChildren<SpriteRenderer>();
        var gameSoundsSprites = gameSoundsVolume.GetComponentsInChildren<SpriteRenderer>();
        
        foreach (var mainVolumeSprite in mainVolumeSprites)
        {
            mainVolumeSprite.enabled = false;
        }

        foreach (var gameSoundsSprite in gameSoundsSprites)
        {
            gameSoundsSprite.enabled = false;
        }
        
        mainVolumeSprites[mainVolumeAmount].enabled = true;
        gameSoundsSprites[gameSoundsVolumeAmount].enabled = true;





    }
    
}
