using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    [FormerlySerializedAs("overlayText")] public Text debugInGameConsole;
    [SerializeField] private AvatarController avatarController;
    /*
     * There is another array for audioclip because for some reason unity breaks if sounds is larger than 7
     */
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioClip[] soundsCopy;
    [FormerlySerializedAs("source")] [SerializeField] private AudioSource feedbackSource;
    [SerializeField] private Animator animator;
    private DataContainer dataContainer;
    private LevLoad levLoad;
    private MenuController menuController;
    private Scenario3Controller scenario3Controller;


    private void Start()
    {
        dataContainer = DataContainer.GetInstance();
        levLoad = FindObjectOfType<LevLoad>();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        VolumeController.GetInstance().OnSceneChange();
       
        foreach (var audioClip in sounds)
        {
            WriteInConsole(audioClip.name);
        }
        foreach (var audioClip in soundsCopy)
        {
            WriteInConsole(audioClip.name);
        }
        if (currentScene == 0)
        {
            //If main menu
            PlayAudio(AudioName.MENU_IDLE_SOUND);
            menuController = FindObjectOfType<MenuController>();
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
        }

        if (currentScene == 3)
        {
            //Play ambient sound
            PlayAudio(AudioName.CROWD_AMBIENT);
            PlayAudio(AudioName.ROAD_AMBIENT);
        }
        
        
        //If scenario 2
        if (currentScene >= 4 && currentScene <= 6)
        {
            avatarController.Talk(InteractionCode.SCENARIO2_START);
        }

        if (currentScene == 6)
        {
            //Play sounds here
            PlayAudio(AudioName.METRO_AMBIENT);
            PlayAudio(AudioName.CROWD_AMBIENT);
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
        WriteInConsole(menuController.name);
        menuController.MenuHandle(code);
        avatarController.Talk(code);
        switch (code)
        {
            case MenuInteractionCode.LOAD1_1:
                animator.SetTrigger("select");
                //dataContainer.CompleteLevel(0);
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(1);
                break;
            case MenuInteractionCode.LOAD1_2:
                animator.SetTrigger("select");
                //dataContainer.CompleteLevel(0);
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(2);
                break;
            case MenuInteractionCode.LOAD1_3:
                animator.SetTrigger("select");
                //dataContainer.CompleteLevel(0);
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(3);
                break;
            case MenuInteractionCode.LOAD2_1:
                animator.SetTrigger("select");
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                //dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(4);
                break;
            case MenuInteractionCode.LOAD2_2:
                animator.SetTrigger("select");
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                //dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(5);
                break;
            case MenuInteractionCode.LOAD2_3:
                animator.SetTrigger("select");
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                //dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(6);
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
            case InteractionCode.SCENARIO2_LASTCORRECT:
                EndOfActivityFeedback();
                break;
            case InteractionCode.SCENARIO1_LASTCORRECT:
                EndOfActivityFeedback();
                break;
            case InteractionCode.SCENARIO3_WRONG:
                NegativeFeedback();
                break;
            case InteractionCode.SCENARIO3_LANGUAGE_CORRECT:
                PositiveFeedback();
                scenario3Controller.HandleMachineInterface(code);
                break;
            case InteractionCode.SCENARIO3_TICKETTYPE_CORRECT:
                PositiveFeedback();
                scenario3Controller.HandleMachineInterface(code);
                break;
            case InteractionCode.SCENARIO3_TICKETNUMBER_CORRECT:
                PositiveFeedback();
                scenario3Controller.HandleMachineInterface(code);
                break;
            case InteractionCode.SCENARIO3_PAYMENTMODE_CORRECT:
                PositiveFeedback();
                scenario3Controller.HandleMachineInterface(code);
                break;
            case InteractionCode.SCENARIO3_PAYMENTCOMPLETE:
                PositiveFeedback();
                scenario3Controller.HandleMachineInterface(code);
                break;
            case InteractionCode.SCENARIO3_CORRECT:
                EndOfActivityFeedback();
                break;
            
        }
    }

    private void EndOfActivityFeedback()
    {
        PlayAudio(AudioName.END_OF_EXPERIENCE_FEEDBACK);
        animator.SetTrigger("correct");
        levLoad.LoadLevel(0);
    }
    public void PositiveFeedback()
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

    public void PlayAudio(AudioName audioName)
    {
        //feedbackSource.PlayOneShot(sounds[(int)audioName]);
        
        
         switch (audioName)
        {
            case AudioName.POSITIVE_FEEDBACK:
                feedbackSource.PlayOneShot(sounds[0]);
                break;
            case AudioName.NEGATIVE_FEEDBACK:
                feedbackSource.PlayOneShot(sounds[1]);
                break;
            case AudioName.NEW_TASK:
                feedbackSource.PlayOneShot(sounds[2]);
                break;
            case AudioName.METRO_AMBIENT:
                feedbackSource.PlayOneShot(sounds[3]);
                break;
            case AudioName.ROAD_AMBIENT:
                feedbackSource.PlayOneShot(sounds[6]);
                break;
            case AudioName.CROWD_AMBIENT:
                feedbackSource.PlayOneShot(sounds[4], 0.5f);
                break;
            case AudioName.END_OF_EXPERIENCE_FEEDBACK:
                feedbackSource.PlayOneShot(sounds[5]);
                break;
            case AudioName.COIN_INSERT_SOUND:
                feedbackSource.PlayOneShot(soundsCopy[0]);
                break;
            case AudioName.MENU_IDLE_SOUND:
                feedbackSource.PlayOneShot(soundsCopy[1]);
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
    SCENARIO3_PAYMENTMODE_CORRECT          = 35 ,                     
    SCENARIO3_WRONG                    = 36 ,         
    SCENARIO3_PAYMENT                  = 9999  ,   
    SCENARIO3_CORRECT                  = 9998  ,
    SCENARIO3_LASTCORRECT              = 37 ,
    SCENARIO3_PAYMENTCOMPLETE          = 38 ,
    SCENARIO3_PAYMENTCOMPLETE_CHANGE   = 39 ,
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
    LOAD3_2 = 32,
    INIZIAMO = 02,
    HOME = 01,
    IMPOSTAZIONI = 03,
    VOLUME = 04,
}

public enum AudioName
{
    POSITIVE_FEEDBACK,
    NEGATIVE_FEEDBACK,
    NEW_TASK,
    METRO_AMBIENT,
    CROWD_AMBIENT,
    ROAD_AMBIENT,
    END_OF_EXPERIENCE_FEEDBACK,
    COIN_INSERT_SOUND,
    MENU_IDLE_SOUND,
}
