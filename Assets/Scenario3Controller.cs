﻿using System.Collections;
using UnityEngine;

public class Scenario3Controller : MonoBehaviour
{
    [SerializeField] private GameObject TipologiaBiglietto;
    [SerializeField] private GameObject NumeroBiglietti;
    [SerializeField] private GameObject SelezioneLingua;
    [SerializeField] private GameObject ModalitàPagamento;
    
    // Start is called before the first frame update
    void Start()
    {
        TipologiaBiglietto.SetActive(false);
        NumeroBiglietti.SetActive(false);
        SelezioneLingua.SetActive(true);
        ModalitàPagamento.SetActive(false);
        
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
            case InteractionCode.SCENARIO3_PAYMENT_CORRECT:
                ModalitàPagamento.SetActive(false);
                //TODO Add payment
                break;

        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
