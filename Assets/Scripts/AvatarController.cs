using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
	[SerializeField] private Text avatarText;
	private DialoguesAndSounds dialoguesAndSounds;
	[SerializeField] private AudioSource dialoguesSource;

	private void Start()
	{
		dialoguesAndSounds = FindObjectOfType<DialoguesAndSounds>();
	}
	

	public void Talk(InteractionCode code)
	{
		string textToDisplay = dialoguesAndSounds.GetPhrase(code);
		AudioClip audioClip = dialoguesAndSounds.GetAudio(code);
		if (audioClip != null)
		{
			dialoguesSource.PlayOneShot(audioClip);	
		}
		
		avatarText.text = " " + textToDisplay;
	}

	public void Talk(MenuInteractionCode code)
	{
		string textToDisplay = dialoguesAndSounds.GetPhrase(code);
		AudioClip audioClip = dialoguesAndSounds.GetAudio(code);
		if (audioClip != null)
		{
			dialoguesSource.PlayOneShot(audioClip);	
		}
		avatarText.text = " " + textToDisplay;
	}

	public void Talk(string strToDisplay)
	{
		avatarText.text = " " + strToDisplay;
	}
	
}
