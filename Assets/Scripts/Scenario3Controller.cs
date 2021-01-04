using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenario3Controller : MonoBehaviour
{
    [SerializeField] private GameObject TipologiaBiglietto;
    [SerializeField] private GameObject NumeroBiglietti;
    [SerializeField] private GameObject SelezioneLingua;
    [SerializeField] private GameObject ModalitàPagamento;
    [SerializeField] private GameObject SchermataMonete;
    [SerializeField] private GameObject StampaInCorso;
    [SerializeField] private GameObject RitirareBiglietto;
    [SerializeField] private GameObject CompletarePagamento;
    [SerializeField] private GameObject ImportoIntrodotto;
    [SerializeField] private GameObject SchermataCarta;

    private SpriteRenderer[] importi;

    private bool processing;
    
    // Start is called before the first frame update
    void Start()
    {
        importi = new SpriteRenderer[11];
        TipologiaBiglietto.SetActive(false);
        NumeroBiglietti.SetActive(false);
        SelezioneLingua.SetActive(true);
        ModalitàPagamento.SetActive(false);
        SchermataMonete.SetActive(false);
        StampaInCorso.SetActive(false);
        RitirareBiglietto.SetActive(false);
        SchermataCarta.SetActive(false);
        //Get various sprites of ImportoIntrodotto
        importi = ImportoIntrodotto.GetComponentsInChildren<SpriteRenderer>();
        FindObjectOfType<GameController>().WriteInConsole("importi has length " + importi.Length.ToString());
        CompletarePagamento.SetActive(false);
        ImportoIntrodotto.SetActive(false);
        processing = false;
    }

    public void HandleMachineInterface(InteractionCode code)
    {
        if (processing) return;   
        StartCoroutine(WaitAndSwap(code));
    }

    private IEnumerator WaitAndSwap(InteractionCode code)
    {
        processing = true;
        yield return new WaitForSeconds(0.5f);
        
        switch (code)
        {
            case InteractionCode.SCENARIO3_LANGUAGE_CORRECT:
                SelezioneLingua.SetActive(false);
                TipologiaBiglietto.SetActive(true);
                break;
            case InteractionCode.SCENARIO3_TICKETTYPE_CORRECT:
                TipologiaBiglietto.SetActive(false);
                NumeroBiglietti.SetActive(true);
                break;
            case InteractionCode.SCENARIO3_TICKETNUMBER_CORRECT:
                NumeroBiglietti.SetActive(false);
                ModalitàPagamento.SetActive(true);
                break;
            case InteractionCode.SCENARIO3_PAYMENTMODE_MONEY:
                ModalitàPagamento.SetActive(false);
                SchermataMonete.SetActive(true);
                CompletarePagamento.SetActive(true);
                ImportoIntrodotto.SetActive(true);
                FindObjectOfType<MoneteController>().Initialize();
                break;
            case InteractionCode.SCENARIO3_PAYMENTMODE_CARD:
                ModalitàPagamento.SetActive(false);
                //TODO Schermata attesa pagamento con carta
                SchermataCarta.SetActive(true);
                break;
            case InteractionCode.SCENARIO3_PAYMENTCOMPLETE:
                SchermataMonete.SetActive(false);
                SchermataCarta.SetActive(false);
                CompletarePagamento.SetActive(false);
                ImportoIntrodotto.SetActive(false);
                StampaInCorso.SetActive(true);
                yield return new WaitForSeconds(5f);
                FindObjectOfType<GameController>().Handle(
                    SceneManager.GetActiveScene().buildIndex == 7 ? InteractionCode.SCENARIO3_CORRECT : InteractionCode.SCENARIO3_LASTCORRECT);
                StampaInCorso.SetActive(false);
                RitirareBiglietto.SetActive(true);
                break;
                
        }

        processing = false;
        yield return null;
    }

    public void UpdateValue(int currentMoney)
    {

        importi[currentMoney / 50].enabled = true;

        if (currentMoney == 200)
        {
            FindObjectOfType<GameController>().Handle(InteractionCode.SCENARIO3_PAYMENTCOMPLETE);
            
        }
        else if (currentMoney > 200)
        {
            FindObjectOfType<AvatarController>().Talk(InteractionCode.SCENARIO3_PAYMENTCOMPLETE_CHANGE);
            FindObjectOfType<GameController>().Handle(InteractionCode.SCENARIO3_PAYMENTCOMPLETE);

        }
    }
}
