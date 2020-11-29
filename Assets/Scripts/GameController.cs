using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text overlayText;
    [SerializeField] private AvatarController avatarController;
    public void Handle(SelectableCode code)
    {
        //TODO Serialize this
        LevLoad levLoad =FindObjectOfType<LevLoad>();
        
        if (overlayText != null)
        {
            overlayText.text = "Selezionato " + code + "!";    
        }
        
        avatarController.DisplayText(code);
        
        switch (code)
        {
            case SelectableCode.SCENARIO1_CORRECT:
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO1_WRONG:
                overlayText.text = "Scelta sbagliata! " + code;
                break;
            case SelectableCode.SCENARIO2_CORRECT:
                levLoad.LoadLevel(0);
                break;
            case SelectableCode.SCENARIO2_WRONG:
                overlayText.text = "Scelta sbagliata! " + code;
                break;
            case SelectableCode.MAIN_LOAD1_L1:
                overlayText.text = "Loading level 1 " + code;
                levLoad.LoadLevel(1);
                break;
            case SelectableCode.MAIN_LOAD2_L1:
                overlayText.text = "Loading level 2 " + code;
                levLoad.LoadLevel(2);
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
