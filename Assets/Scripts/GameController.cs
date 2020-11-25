using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text overlayText;
    public void Handle(SelectableCode code)
    {
        LevLoad levLoad =FindObjectOfType<LevLoad>(); 
        if (overlayText != null)
        {
            overlayText.text = "selezionato " + code + "!";    
        }
        
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
    SCENARIO1_CORRECT,
    SCENARIO1_WRONG,
    SCENARIO2_CORRECT,
    SCENARIO2_WRONG,
    SCENARIO3_CORRECT,
    SCENARIO3_WRONG,
    MAIN_LOAD1_L1,
    MAIN_LOAD2_L1
}
