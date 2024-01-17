using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    
    
    public int maxSaglik, gecerliSaglik;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gecerliSaglik = maxSaglik;
        
        if(UIManager.instance != null)
        {
            UIManager.instance.SlideriGuncelle(gecerliSaglik, maxSaglik);
        }

    }

    public void CaniAzaltFNC()
    {
        gecerliSaglik--;

        UIManager.instance.SlideriGuncelle(gecerliSaglik, maxSaglik);

        if (gecerliSaglik <= 0)
        {
            gecerliSaglik = 0;
           // gameObject.SetActive(false);

            PlayerHareketController.instance.PlayerCanVerdiFNC();
        }
    }

    public void CaniArtirFNC()
    {
        gecerliSaglik++;

        if(gecerliSaglik >= maxSaglik)
            gecerliSaglik = maxSaglik;

        UIManager.instance.SlideriGuncelle(gecerliSaglik, maxSaglik);
    }

}
