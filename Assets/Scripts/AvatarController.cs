using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
	[SerializeField] private Text avatarText;

	private void Start()
	{
		avatarText.text = "Benvenuto! Scegli il livello da giocare.";
	}

	public void DisplayText(InteractionCode code)
	{
		string textToDisplay = Dialogues.GetPhrase(code);
		
		avatarText.text = " " + textToDisplay;
	}

	public void DisplayText(MenuInteractionCode code)
	{
		string textToDisplay = Dialogues.GetPhrase(code);
		avatarText.text = " " + textToDisplay;
	}
	
}
