﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class DialoguesAndSounds : MonoBehaviour
{
	private Dictionary<InteractionCode, string> dialogues = new Dictionary<InteractionCode, string>();
    private Dictionary<MenuInteractionCode, string> menuDialogues = new Dictionary<MenuInteractionCode, string>();
    private Dictionary<InteractionCode, AudioClip> audios = new Dictionary<InteractionCode, AudioClip>();
    private Dictionary<MenuInteractionCode, AudioClip> menuAudios = new Dictionary<MenuInteractionCode, AudioClip>();
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioClip[] menuAudioClips;


    private void Start()
    {
        BuildStringDictionary();
        BuildAudioDictionary();
 
    }

    public string GetPhrase(InteractionCode code)
    {
	    dialogues.TryGetValue(code, out var phrase);
        FindObjectOfType<GameController>().WriteInConsole("Phrase to write is " + phrase);
        return phrase;
    }

    public string GetPhrase(MenuInteractionCode code)
    {
        menuDialogues.TryGetValue(code, out var phrase);
        return phrase;
    }

    public AudioClip GetAudio(MenuInteractionCode code)
    {
        menuAudios.TryGetValue(code, out var audio);
        return audio;
    }
    
    public AudioClip GetAudio(InteractionCode code)
    {
        audios.TryGetValue(code, out var audio);
        return audio;
    }
    
    
    
    private void BuildStringDictionary()
    {
        menuDialogues.Add(MenuInteractionCode.LOAD1_1, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD1_2, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD1_3, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_1, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_2, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_3, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD3_1, "Compriamo il biglietto!");
        menuDialogues.Add(MenuInteractionCode.LOAD3_2, "Compriamo il biglietto!");
        menuDialogues.Add(MenuInteractionCode.START, "Ciao! Sei pronto per questa avventura?\nSeleziona il livello che vuoi giocare.");
        dialogues.Add(InteractionCode.SCENARIO1_START, "Seleziona il logo M della metro rossa!");
        dialogues.Add(InteractionCode.SCENARIO1_CORRECT, "Bravo! Hai fatto la scelta corretta.\n" +
                                                          "Passiamo al prossimo livello.");
        dialogues.Add(InteractionCode.SCENARIO1_LASTCORRECT, "Bravo! Hai fatto la scelta corretta.\n" +
                                                              "Ora entriamo dentro la metro.");
        dialogues.Add(InteractionCode.SCENARIO1_WRONG, "Non è quella l'insegna della metro rossa.");
        dialogues.Add(InteractionCode.SCENARIO1_HELP, "Guarda intorno a te e cerca di individuare un logo rosso messo in alto.\n" +
                                                      "La stazione della metro rossa ha il corrimano rosso.");
        dialogues.Add(InteractionCode.SCENARIO2_START, "Siamo dentro la metro! Guardati intorno e seleziona la macchinetta per fare il biglietto.");
        dialogues.Add(InteractionCode.SCENARIO2_CORRECT, "Bravo! Hai selezionato la macchinetta.\n" +
                                                          "Passiamo al prossimo livello.");
        dialogues.Add(InteractionCode.SCENARIO2_LASTCORRECT, "Bravo! Ora compriamo il biglietto.");
        dialogues.Add(InteractionCode.SCENARIO2_WRONG, "Quello è un cartellone pubblicitario. Non è la macchinetta dei biglietti.");
        dialogues.Add(InteractionCode.SCENARIO2_HELP, "La macchinetta è facile da individuare: è rossa ed è molto alta.");
        dialogues.Add(InteractionCode.SCENARIO3_START_LV1, "Ora puoi acquistare il biglietto. Osserva attentamente le opzioni e scegli l'opzione indicata dal cerchio verde nell'immagine.");
        dialogues.Add(InteractionCode.SCENARIO3_START_LV2, "Prova ad acquistare il biglietto senza alcun aiuto.");
        dialogues.Add(InteractionCode.SCENARIO3_PAYMENT, "Ottimo! Ora devi pagare il biglietto. Costa 2 euro.");
        dialogues.Add(InteractionCode.SCENARIO3_CORRECT, "Bravissimo! Passiamo al prossimo livello.");
        dialogues.Add(InteractionCode.SCENARIO3_LASTCORRECT, "Bravissimo! Se hai completato anche gli altri scenari, sei pronto per l'avventura in realtà aumentata.");
        FindObjectOfType<GameController>().WriteInConsole("Built dictionary with length " + menuDialogues.Count + " and " + dialogues.Count);
    }

    private void BuildAudioDictionary()
    {
        menuAudios.Add(MenuInteractionCode.LOAD1_1, menuAudioClips[1]);
        menuAudios.Add(MenuInteractionCode.LOAD1_2, menuAudioClips[1]);
        menuAudios.Add(MenuInteractionCode.LOAD1_3, menuAudioClips[1]);
        menuAudios.Add(MenuInteractionCode.LOAD2_1, menuAudioClips[2]);
        menuAudios.Add(MenuInteractionCode.LOAD2_2, menuAudioClips[2]);
        menuAudios.Add(MenuInteractionCode.LOAD2_3, menuAudioClips[2]);
        menuAudios.Add(MenuInteractionCode.START, menuAudios[0]);
        //TODO Add these
        //menuAudios.Add(MenuInteractionCode.LOAD2_2,);
        //menuAudios.Add(MenuInteractionCode.LOAD2_3,);
        
        audios.Add(InteractionCode.SCENARIO1_START, audioClips[4]);
        audios.Add(InteractionCode.SCENARIO1_CORRECT, audioClips[3]);
        audios.Add(InteractionCode.SCENARIO1_LASTCORRECT, audioClips[1]);
        audios.Add(InteractionCode.SCENARIO1_WRONG, audioClips[2]);
        audios.Add(InteractionCode.SCENARIO1_HELP, audioClips[0]);
        
        audios.Add(InteractionCode.SCENARIO2_START, audioClips[8]);
        audios.Add(InteractionCode.SCENARIO2_CORRECT, audioClips[5]);
        audios.Add(InteractionCode.SCENARIO2_LASTCORRECT, audioClips[7]);
        audios.Add(InteractionCode.SCENARIO2_WRONG, audioClips[9]);
        audios.Add(InteractionCode.SCENARIO2_HELP, audioClips[6]);
        
        audios.Add(InteractionCode.SCENARIO3_START_LV1, audioClips[13]);
        audios.Add(InteractionCode.SCENARIO3_START_LV2, audioClips[14]);
        audios.Add(InteractionCode.SCENARIO3_PAYMENT, audioClips[12]);
        audios.Add(InteractionCode.SCENARIO3_CORRECT, audioClips[10]);
        audios.Add(InteractionCode.SCENARIO3_LASTCORRECT, audioClips[11]);
    }
    
}

