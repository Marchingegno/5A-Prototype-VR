using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
	[SerializeField] private Text avatarText;

	private void Start()
	{
		avatarText.text = "TEST";
	}

	public void DisplayText(SelectableCode code)
	{
		string textToDisplay = Dialogues.GetPhrase(code);
		
		avatarText.text = " " + textToDisplay;
	}
}
