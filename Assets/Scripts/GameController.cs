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
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO1_WRONG:
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                break;
            case SelectableCode.SCENARIO2_CORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO2_WRONG:
                PlayAudio(AudioName.NEGATIVE_FEEDBACK);
                debugInGameConsole.text = "Scelta sbagliata! " + code;
                break;
            case SelectableCode.MAIN_LOAD1_L1:
                debugInGameConsole.text = "Loading level 1 " + code;
                levLoad.LoadLevel(1);
                break;
            case SelectableCode.MAIN_LOAD2_L1:
                debugInGameConsole.text = "Loading level 2 " + code;
                levLoad.LoadLevel(2);
                break;
            case SelectableCode.SCENARIO1_LASTCORRECT:
                PlayAudio(AudioName.POSITIVE_FEEDBACK);
                levLoad.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    private void PlayAudio(AudioName audioName)
    {
        switch (audioName)
        {
            case AudioName.POSITIVE_FEEDBACK:
                source.PlayOneShot(sounds[0]);
                break;
            case AudioName.NEGATIVE_FEEDBACK:
                source.PlayOneShot(sounds[1]);
                break;
        }
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
    MAIN_LOAD1_L1,
    MAIN_LOAD2_L1,
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

public enum AudioName
{
    POSITIVE_FEEDBACK,
    NEGATIVE_FEEDBACK,
    NEW_TASK,
    METRO_AMBIENT,
    METRO_TRAIN_ARRIVE

}
