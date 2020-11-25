using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{

    // Start is called before the first frame update
    public void OnSelectThis(int code)
    {
        SelectableCode selectableCode = (SelectableCode) code;
        
        
        
        FindObjectOfType<GameController>().Handle(selectableCode);
        
    }


}
/*
public enum SelectableCode
{
    SCENARIO1_CORRECT,
    SCENARIO1_WRONG,
    SCENARIO2_CORRECT,
    SCENARIO2_WRONG,
    SCENARIO3_CORRECT,
    SCENARIO3_WRONG
}
*/