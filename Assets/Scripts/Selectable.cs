using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
[RequireComponent(typeof(BoxCollider))]
public class Selectable : MonoBehaviour
{

    // Start is called before the first frame update
    public void OnSelectThis(int code)
    {
        FindObjectOfType<GameController>().Handle((InteractionCode) code);
    }

    public void OnSelectThisMenu(int code)
    {
        FindObjectOfType<GameController>().MenuHandle((MenuInteractionCode) code);
    }


}
/*
public enum InteractionCode
{
    SCENARIO1_CORRECT,
    SCENARIO1_WRONG,
    SCENARIO2_CORRECT,
    SCENARIO2_WRONG,
    SCENARIO3_CORRECT,
    SCENARIO3_WRONG
}
*/