using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Erogatore : MonoBehaviour
{
    public Text overlayText;
    // Start is called before the first frame update
    public void onSelectErogatore()
    {
        overlayText.text = "selezionato erogatore!";
    }
}
