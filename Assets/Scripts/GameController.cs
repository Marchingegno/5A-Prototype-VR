﻿using UnityEngine;
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
    private Scenario3Controller scenario3Controller;
    

    private void Start()
    {
        dataContainer = DataContainer.GetInstance();
        levLoad = FindObjectOfType<LevLoad>();
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        //If main menu
        if (currentScene == 0)
        {
            avatarController.Talk(MenuInteractionCode.START);
        }
        
        //If it is not main manu, play new task.
        if (currentScene != 0)
        {
            PlayAudio(AudioName.NEW_TASK);
        }
        
        //If scenario 1, play road ambient sound
        if (currentScene > 0 && currentScene <= 3)
        {
            avatarController.Talk(InteractionCode.SCENARIO1_START);
            //TODO Implement this
        }
        
        
        //If scenario 2, play metro ambient sound.
        if (currentScene >= 4 && currentScene <= 6)
        {
            avatarController.Talk(InteractionCode.SCENARIO2_START);
            PlayAudio(AudioName.METRO_AMBIENT);
        }
        
        //TODO If scenario 3
        if (currentScene == 7)
        {
            scenario3Controller = FindObjectOfType<Scenario3Controller>();
            avatarController.Talk(InteractionCode.SCENARIO3_START_LV1);
        }
        else if (currentScene == 8)
        {
            scenario3Controller = FindObjectOfType<Scenario3Controller>();
            avatarController.Talk(InteractionCode.SCENARIO3_START_LV2);
        }
        
    }
    
    public void MenuHandle(MenuInteractionCode code)
    {
        WriteInConsole("Handling MenuInteractionCode " + code);
        avatarController.Talk(code);
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
                //dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(4);
                break;
            case MenuInteractionCode.LOAD3_1:
                animator.SetTrigger("select");
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(7);
                break;
        }
        
    }

    public void Handle(InteractionCode code)
    {

        WriteInConsole("Handling " + code);
        
        avatarController.Talk(code);
        
        switch (code)
        {
            case InteractionCode.SCENARIO1_CORRECT:
                EndOfActivityFeedback();
                break;
            case InteractionCode.SCENARIO1_WRONG:
                NegativeFeedback();
                break;
            case InteractionCode.SCENARIO2_CORRECT:
                EndOfActivityFeedback();
                break;
            case InteractionCode.SCENARIO2_WRONG:
                NegativeFeedback();
                break;
            case InteractionCode.SCENARIO1_LASTCORRECT:
                EndOfActivityFeedback();
                break;
            case InteractionCode.SCENARIO3_WRONG:
                NegativeFeedback();
                break;
            case InteractionCode.SCENARIO3_LANGUAGE_CORRECT:
                PositiveFeedback();
                scenario3Controller.Deactivate(code);
                break;
            case InteractionCode.SCENARIO3_TICKETTYPE_CORRECT:
                PositiveFeedback();
                scenario3Controller.Deactivate(code);
                break;
            case InteractionCode.SCENARIO3_TICKETNUMBER_CORRECT:
                PositiveFeedback();
                scenario3Controller.Deactivate(code);
                break;
            case InteractionCode.SCENARIO3_PAYMENT_CORRECT:
                PositiveFeedback();
                scenario3Controller.Deactivate(code);
                levLoad.LoadLevel(0);
                break;
            
        }
        
    }

    private void EndOfActivityFeedback()
    {
        PlayAudio(AudioName.END_OF_EXPERIENCE_FEEDBACK);
        animator.SetTrigger("correct");
        levLoad.LoadLevel(0);
    }
    private void PositiveFeedback()
    {
        PlayAudio(AudioName.POSITIVE_FEEDBACK);
        animator.SetTrigger("select");
    }

    private void NegativeFeedback()
    {
        PlayAudio(AudioName.NEGATIVE_FEEDBACK);
        animator.SetTrigger("wrong");
    }

    public void WriteInConsole(string toWrite)
    {
        if (debugInGameConsole != null)
        {
            debugInGameConsole.text += "\n" + toWrite;
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
            case AudioName.END_OF_EXPERIENCE_FEEDBACK:
                source.PlayOneShot(sounds[5]);
                break;
        }
        
    }
}

public enum InteractionCode
{
    SCENARIO1_CORRECT                  = 11 ,          
    SCENARIO1_WRONG                    = 12 ,         
    SCENARIO2_CORRECT                  = 21 ,             
    SCENARIO2_WRONG                    = 22 ,         
    MAINMENU_START                     = 0  ,         
    SCENARIO1_START                    = 10 ,         
    SCENARIO1_LASTCORRECT              = 13 ,                 
    SCENARIO1_HELP                     = 14 ,         
    SCENARIO2_START                    = 20 ,         
    SCENARIO2_LASTCORRECT              = 23 ,                 
    SCENARIO2_HELP                     = 24 ,
    SCENARIO3_START_LV1                = 30 ,             
    SCENARIO3_START_LV2                = 31 ,             
    SCENARIO3_LANGUAGE_CORRECT         = 32 ,                     
    SCENARIO3_TICKETTYPE_CORRECT       = 33 ,                         
    SCENARIO3_TICKETNUMBER_CORRECT     = 34 ,                         
    SCENARIO3_PAYMENT_CORRECT          = 35 ,                     
    SCENARIO3_WRONG                    = 36 ,         
    SCENARIO3_PAYMENT                  = 9999  ,   
    SCENARIO3_CORRECT                  = 9998  ,
    SCENARIO3_LASTCORRECT              = 37 ,                 
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
    METRO_TRAIN_ARRIVE,
    END_OF_EXPERIENCE_FEEDBACK,

}
