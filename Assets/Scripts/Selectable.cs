using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    public Text overlayText;
    // Start is called before the first frame update
    public void OnSelectThis(int level)
    {
        overlayText.text = "selezionato " + level + "!";
        FindObjectOfType<LevLoad>().LoadLevel(level);
    }
}
