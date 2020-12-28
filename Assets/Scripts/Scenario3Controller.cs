using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scenario3Controller : MonoBehaviour
{
    [SerializeField] private GameObject TipologiaBiglietto;
    [SerializeField] private GameObject NumeroBiglietti;
    [SerializeField] private GameObject SelezioneLingua;
    [SerializeField] private GameObject ModalitàPagamento;
    [SerializeField] private GameObject SchermataMonete;
    [SerializeField] private Text ProcederePagamento;
    
    // Start is called before the first frame update
    void Start()
    {
        TipologiaBiglietto.SetActive(false);
        NumeroBiglietti.SetActive(false);
        SelezioneLingua.SetActive(true);
        ModalitàPagamento.SetActive(false);
        SchermataMonete.SetActive(false);
        
    }

    public void Deactivate(InteractionCode code)
    {
        StartCoroutine(WaitAndDeactivate(code));
    }

    private IEnumerator WaitAndDeactivate(InteractionCode code)
    {
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
            case InteractionCode.SCENARIO3_PAYMENTMODE_CORRECT:
                ModalitàPagamento.SetActive(false);
                SchermataMonete.SetActive(true);
                FindObjectOfType<MoneteController>().Initialize();
                break;

        }

        yield return null;
    }

    public void UpdateValue(int currentMoney)
    {
        ProcederePagamento.text = "Importo corrente: " + (int) (currentMoney / 100) + "." + (int) (currentMoney % 100);

        if (currentMoney >= 200)
        {
            FindObjectOfType<MoneteController>().gameObject.SetActive(false);
            FindObjectOfType<LevLoad>().LoadLevel(0);
        }
    }
}
