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
		StartCoroutine(PlayAudio(dialoguesAndSounds.GetAudio(code)));
		
		
		avatarText.text = " " + textToDisplay;
	}

	public void Talk(MenuInteractionCode code)
	{
		string textToDisplay = dialoguesAndSounds.GetPhrase(code);
		StartCoroutine(PlayAudio(dialoguesAndSounds.GetAudio(code)));
		
		avatarText.text = " " + textToDisplay;
	}

	private IEnumerator PlayAudio(AudioClip audioClip)
	{
		yield return new WaitForSeconds(1f);
		FindObjectOfType<GameController>().WriteInConsole("Trying to play audio");
		if (audioClip != null)
		{
			FindObjectOfType<GameController>().WriteInConsole("Audio is not null, now playing it.");
			dialoguesSource.PlayOneShot(audioClip);	
		}
	}

	public void Talk(string strToDisplay)
	{
		avatarText.text = " " + strToDisplay;
	}
	
}
