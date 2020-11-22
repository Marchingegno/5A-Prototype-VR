using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Metro : MonoBehaviour
{
    public Text overlayText;
    public void MetroSelected()
    {
        overlayText.text = "Metro selected";
    }
}
