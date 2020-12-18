using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Dialogues : MonoBehaviour
{
	private static Dictionary<SelectableCode, string> dialogues = new Dictionary<SelectableCode, string>();
    private void Start()
    {
        dialogues.Add(SelectableCode.MAINMENU_START, "Ciao! Sei pronto per questa avventura?\nSeleziona il livello che vuoi giocare.");
        
        dialogues.Add(SelectableCode.LOAD1_1, "Andiamo alla fermata della metro!");
        dialogues.Add(SelectableCode.LOAD2_1, "Entriamo dentro la metro!");
        dialogues.Add(SelectableCode.SCENARIO1_START, "Seleziona il logo M della metro rossa!");
        dialogues.Add(SelectableCode.SCENARIO1_CORRECT, "Bravo! Hai fatto la scelta corretta.\n" +
                                                          "Passiamo al prossimo livello.");
        dialogues.Add(SelectableCode.SCENARIO1_LASTCORRECT, "Bravo! Hai fatto la scelta corretta.\n" +
                                                              "Ora entriamo dentro la metro.");
        dialogues.Add(SelectableCode.SCENARIO1_WRONG, "Non è quella l'insegna della metro rossa.");
        dialogues.Add(SelectableCode.SCENARIO1_HELP, "Guarda intorno a te e cerca di individuare un logo rosso messo in alto.\n" +
                                                      "La stazione della metro rossa ha il corrimano rosso.");
        
        dialogues.Add(SelectableCode.SCENARIO2_START, "Siamo dentro la metro! Guardati intorno e seleziona la macchinetta per fare il biglietto.");
        dialogues.Add(SelectableCode.SCENARIO2_CORRECT, "Bravo! Hai selezionato la macchinetta.\n" +
                                                          "Passiamo al prossimo livello.");
        dialogues.Add(SelectableCode.SCENARIO2_LASTCORRECT, "Bravo! Ora compriamo il biglietto.");
        dialogues.Add(SelectableCode.SCENARIO2_WRONG, "Quello è un cartellone pubblicitario. Non è la macchinetta dei biglietti.");
        dialogues.Add(SelectableCode.SCENARIO2_HELP, "La macchinetta è facile da individuare: è rossa ed è molto alta.");
        
        dialogues.Add(SelectableCode.SCENARIO3_START_LV1, "Ora puoi acquistare il biglietto. Osserva attentamente le opzioni e scegli l'opzione indicata dal cerchio verde nell'immagine,");
        dialogues.Add(SelectableCode.SCENARIO3_START_LV2, "Prova ad acquistare il biglietto senza alcun aiuto.");
        dialogues.Add(SelectableCode.SCENARIO3_PAYMENT, "Ottimo! Ora devi pagare il biglietto. Costa 2 euro.");
        dialogues.Add(SelectableCode.SCENARIO3_CORRECT, "Bravissimo! Passiamo al prossimo livello.");
        dialogues.Add(SelectableCode.SCENARIO3_LASTCORRECT, "Bravissimo! Se hai completato anche gli altri scenari, sei pronto per l'avventura in realtà aumentata.");
    }

    public static string GetPhrase(SelectableCode code)
    {
	    dialogues.TryGetValue(code, out var phrase);
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
