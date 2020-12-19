using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [FormerlySerializedAs("overlayText")] public Text debugInGameConsole;
    [SerializeField] private AvatarController avatarController;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource source;
    [SerializeField] private Animator animator;
    private DataContainer dataContainer;
    private LevLoad levLoad;
    

    private void Start()
    {
        dataContainer = DataContainer.GetInstance();
        levLoad = FindObjectOfType<LevLoad>();
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        //If main menu
        if (currentScene == 0)
        {
            avatarController.DisplayText(MenuInteractionCode.START);
        }
        
        //If it is not main manu, play new task.
        if (currentScene != 0)
        {
            PlayAudio(AudioName.NEW_TASK);
        }
        
        //If scenario 1, play road ambient sound
        if (currentScene > 0 && currentScene <= 3)
        {
            avatarController.DisplayText(InteractionCode.SCENARIO1_START);
            //TODO Implement this
        }
        
        
        //If scenario 2, play metro ambient sound.
        if (currentScene >= 4 && currentScene <= 6)
        {
            avatarController.DisplayText(InteractionCode.SCENARIO2_START);
            PlayAudio(AudioName.METRO_AMBIENT);
        }
        
        //TODO If scenario 3
        if (currentScene == 7)
        {
            avatarController.DisplayText(InteractionCode.SCENARIO3_START_LV1);
        }
        else if (currentScene == 8)
        {
            avatarController.DisplayText(InteractionCode.SCENARIO3_START_LV2);
        }
        
    }
    
    public void MenuHandle(MenuInteractionCode code)
    {
        WriteInConsole("Handling MenuInteractionCode " + code);
        avatarController.DisplayText(code);
        switch (code)
        {
            case MenuInteractionCode.LOAD1_1:
                animator.SetTrigger("select");
                //dataContainer.CompleteLevel(0);
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(1);
                break;
            case MenuInteractionCode.LOAD2_1:
                animator.SetTrigger("select");
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(4);
                break;
        }
        
    }

    public void Handle(InteractionCode code)
    {

        WriteInConsole("Handling " + code);
        
        avatarController.DisplayText(code);
        
        switch (code)
        {
            case InteractionCode.SCENARIO1_CORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(0);
                break;
            case InteractionCode.SCENARIO1_WRONG:
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                animator.SetTrigger("wrong");
                break;
            case InteractionCode.SCENARIO2_CORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(0);
                break;
            case InteractionCode.SCENARIO2_WRONG:
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                animator.SetTrigger("wrong");
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                break;
            case InteractionCode.SCENARIO1_LASTCORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(0);
                break;
        }
    }

    public void WriteInConsole(string toWrite)
    {
        if (debugInGameConsole != null)
        {
            debugInGameConsole.text += "\n" + toWrite + "\n";
        }
        
    }

    private void PlayAudio(AudioName audioName)
    {
        //debugInGameConsole.text += "Playing " + (int)(audioName);
        //source.PlayOneShot(sounds[(int)audioName]);
        
        
         switch (audioName)
        {
            case AudioName.POSITIVE_FEEDBACK:
                source.PlayOneShot(sounds[0]);
                break;
            case AudioName.NEGATIVE_FEEDBACK:
                source.PlayOneShot(sounds[1]);
                break;
            case AudioName.NEW_TASK:
                source.PlayOneShot(sounds[2]);
                break;
            case AudioName.METRO_AMBIENT:
                source.PlayOneShot(sounds[3]);
                break;
            case AudioName.METRO_TRAIN_ARRIVE:
                break;
        }
        
    }
}

public enum InteractionCode
{
    SCENARIO1_CORRECT,     //0
    SCENARIO1_WRONG,
    SCENARIO2_CORRECT,
    SCENARIO2_WRONG,
    SCENARIO3_CORRECT,
    SCENARIO3_WRONG,       //5
    MAINMENU_START,
    SCENARIO1_START,
    SCENARIO1_LASTCORRECT, //10
    SCENARIO1_HELP,
    SCENARIO2_START,
    SCENARIO2_LASTCORRECT,
    SCENARIO2_HELP,
    SCENARIO3_START_LV1,    //15
    SCENARIO3_START_LV2,
    SCENARIO3_PAYMENT,
    SCENARIO3_LASTCORRECT
}


public enum MenuInteractionCode
{
    START   = 00,
    LOAD1_1 = 11,
    LOAD1_2 = 12,
    LOAD1_3 = 13,
    LOAD2_1 = 21,
    LOAD2_2 = 22,
    LOAD2_3 = 23,
    LOAD3_1 = 31,
    LOAD3_2 = 32
}

public enum AudioName
{
    POSITIVE_FEEDBACK,
    NEGATIVE_FEEDBACK,
    NEW_TASK,
    METRO_AMBIENT,
    METRO_TRAIN_ARRIVE

}
