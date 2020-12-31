using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject SchermataBenvenuto;
    [SerializeField] private GameObject SchermataLivelli;
    [SerializeField] private GameObject SchermataVolume;

    private void Start()
    {
        
        SchermataBenvenuto.SetActive(false);
        SchermataLivelli.SetActive(false);
        SchermataVolume.SetActive(false);
        if (DataContainer.GetInstance().IsFirstStart())
        {
            SchermataBenvenuto.SetActive(true);
            DataContainer.GetInstance().SetFirstStart(false);
        }
        else
        {
            SchermataLivelli.SetActive(true);
        }
    }

    public void MenuHandle(MenuInteractionCode code)
    {
        switch (code)
        {
            case MenuInteractionCode.HOME:
                Home();
                break;
            case MenuInteractionCode.IMPOSTAZIONI:
                Impostazioni();
                break;
            case MenuInteractionCode.INIZIAMO:
                Iniziamo();
                break;
            case MenuInteractionCode.VOLUME:
                Volume();
                break;
            
        }
        
        
    }

    private void Volume()
    {
        SchermataBenvenuto.SetActive(false);
        SchermataVolume.SetActive(true);
    }

    private void Iniziamo()
    {
        SchermataBenvenuto.SetActive(false);
        SchermataLivelli.SetActive(true);
    }

    private void Home()
    {
        SchermataBenvenuto.SetActive(true);
        SchermataLivelli.SetActive(false);
        SchermataVolume.SetActive(false);
    }

    private void Impostazioni()
    {
        SchermataBenvenuto.SetActive(false);
        SchermataVolume.SetActive(true);
    }
    
    
}
