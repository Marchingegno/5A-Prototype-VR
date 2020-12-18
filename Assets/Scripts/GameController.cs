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


    private void Start()
    {
        dataContainer = DataContainer.GetInstance();
        
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            PlayAudio(AudioName.NEW_TASK);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            PlayAudio(AudioName.METRO_AMBIENT);
        }
    }

    public void Handle(SelectableCode code)
    {
        //TODO Serialize this
        LevLoad levLoad =FindObjectOfType<LevLoad>();
        
        if (debugInGameConsole != null)
        {
            debugInGameConsole.text = "Selezionato " + code + "!";    
        }
        
        avatarController.DisplayText(code);
        
        switch (code)
        {
            case SelectableCode.SCENARIO1_CORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO1_WRONG:
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                animator.SetTrigger("wrong");
                break;
            case SelectableCode.SCENARIO2_CORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO2_WRONG:
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                animator.SetTrigger("wrong");
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                break;
            case SelectableCode.LOAD1_1:
                animator.SetTrigger("select");
                dataContainer.CompleteLevel(0);
                levLoad.LoadLevel(1);
                break;
            case SelectableCode.LOAD2_1:
                animator.SetTrigger("select");
                dataContainer.CompleteLevel(3);
                levLoad.LoadLevel(4);
                break;
            case SelectableCode.SCENARIO1_LASTCORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                animator.SetTrigger("correct");
                levLoad.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    private void PlayAudio(AudioName audioName)
    {
        source.PlayOneShot(sounds[(int)audioName]);
        
        /*
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
            case AudioName.METRO_TRAIN_ARRIVE
        }
        */
    }
}

public enum SelectableCode
{
    SCENARIO1_CORRECT,     //0
    SCENARIO1_WRONG,
    SCENARIO2_CORRECT,
    SCENARIO2_WRONG,
    SCENARIO3_CORRECT,
    SCENARIO3_WRONG,       //5
    LOAD1_1,
    LOAD2_1,
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
    SCENARIO3_LASTCORRECT,
    LOAD1_2,
    LOAD1_3,
    LOAD2_2,                //20
    LOAD2_3,
    LOAD3_1,
    LOAD3_2
    


}

public enum AudioName
{
    POSITIVE_FEEDBACK,
    NEGATIVE_FEEDBACK,
    NEW_TASK,
    METRO_AMBIENT,
    METRO_TRAIN_ARRIVE

}
