using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Dialogues : MonoBehaviour
{
	private static Dictionary<InteractionCode, string> dialogues = new Dictionary<InteractionCode, string>();
    private static Dictionary<MenuInteractionCode, string> menuDialogues = new Dictionary<MenuInteractionCode, string>();
    private Dialogues instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        menuDialogues.Add(MenuInteractionCode.LOAD1_1, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD1_2, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD1_3, "Andiamo alla fermata della metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_1, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_2, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_3, "Entriamo dentro la metro!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_2, "Compriamo il biglietto!");
        menuDialogues.Add(MenuInteractionCode.LOAD2_3, "Compriamo il biglietto!");
        
        dialogues.Add(InteractionCode.MAINMENU_START, "Ciao! Sei pronto per questa avventura?\nSeleziona il livello che vuoi giocare.");
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
        
        dialogues.Add(InteractionCode.SCENARIO3_START_LV1, "Ora puoi acquistare il biglietto. Osserva attentamente le opzioni e scegli l'opzione indicata dal cerchio verde nell'immagine,");
        dialogues.Add(InteractionCode.SCENARIO3_START_LV2, "Prova ad acquistare il biglietto senza alcun aiuto.");
        dialogues.Add(InteractionCode.SCENARIO3_PAYMENT, "Ottimo! Ora devi pagare il biglietto. Costa 2 euro.");
        dialogues.Add(InteractionCode.SCENARIO3_CORRECT, "Bravissimo! Passiamo al prossimo livello.");
        dialogues.Add(InteractionCode.SCENARIO3_LASTCORRECT, "Bravissimo! Se hai completato anche gli altri scenari, sei pronto per l'avventura in realtà aumentata.");
    }

    public static string GetPhrase(InteractionCode code)
    {
	    dialogues.TryGetValue(code, out var phrase);
	    return phrase;
    }

    public static string GetPhrase(MenuInteractionCode code)
    {
        menuDialogues.TryGetValue(code, out var phrase);
        return phrase;
    }
    
}

/*
 * public static Dictionary<string, string> dialogues = new Dictionary<string, string>();
    public static Dictionary<string, string> dialogues = new Dictionary<string, string>();
    public static Dictionary<string, string> dialogues = new Dictionary<string, string>();
    public static Dictionary<string, string> scenario3 = new Dictionary<string, string>();
    private void Start()
    {
        dialogues.Add("START", "Ciao! Sei pronto per questa avventura?\nSeleziona il livello che vuoi giocare.");
        
        dialogues.Add("START", "Seleziona il logo M della metro rossa!");
        dialogues.Add("CORRECT", "Bravo! Hai fatto la scelta corretta.\n" +
                                 "Passiamo al prossimo livello.");
        dialogues.Add("LASTCORRECT", "Bravo! Hai fatto la scelta corretta.\n" +
                                     "Ora entriamo dentro la metro.");
        dialogues.Add("WRONG", "Non è quella l'insegna della metro rossa.");
        dialogues.Add("HELP", "Guarda intorno a te e cerca di individuare un logo rosso messo in alto.\n" +
                              "La stazione della metro rossa ha il corrimano rosso.");
        
        dialogues.Add("START", "Siamo dentro la metro! Guardati intorno e seleziona la macchinetta per fare il biglietto.");
        dialogues.Add("CORRECT", "Bravo! Hai selezionato la macchinetta.\n" +
                                "Passiamo al prossimo livello.");
        dialogues.Add("LASTCORRECT", "Bravo! Ora compriamo il biglietto.");
        dialogues.Add("WRONG", "Quello è un cartellone pubblicitario. Non è la macchinetta dei biglietti.");
        dialogues.Add("HELP", "La macchinetta è facile da individuare: è rossa ed è molto alta.");
        
        scenario3.Add("START1", "Ora puoi acquistare il biglietto. Osserva attentamente le opzioni e scegli l'opzione indicata dal cerchio verde nell'immagine,");
        scenario3.Add("START2", "Prova ad acquistare il biglietto senza alcun aiuto.");
        scenario3.Add("PAYMENT", "Ottimo! Ora devi pagare il biglietto. Costa 2 euro.");
        scenario3.Add("CORRECT", "Bravissimo! Passiamo al prossimo livello.");
        scenario3.Add("LASTCORRECT", "Bravissimo! Se hai completato anche gli altri scenari, sei pronto per l'avventura in realtà aumentata.");
        */
