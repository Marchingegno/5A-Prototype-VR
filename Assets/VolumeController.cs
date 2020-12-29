using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private GameObject schermataVolume;
    private static VolumeController instance;

    private AudioSource gameSoundsSource;
    private AudioSource dialoguesSource;

    private float mainVolume;
    private float gameSoundsVolume;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            mainVolume = 0.5f;
            gameSoundsVolume = 0.5f;
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

        dialoguesSource.volume = mainVolume;
        gameSoundsSource.volume = mainVolume * gameSoundsVolume;



    }
    
}
