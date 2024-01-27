using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    [SerializeField]
    bool coinmi, iksirmi;

    [SerializeField]
    GameObject patlamaEfekti;

    bool toplandimi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !toplandimi)
        {
            if(coinmi)
            {
                toplandimi = true;

                GameManager.instance.toplananCoinAdet++;

                UIManager.instance.CoinAdetGuncelle();
                SesManager.instance.KarisikSesEfektiCikar(6);

                Destroy(gameObject);
                Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
            }

            if(iksirmi)
            {
                toplandimi = true;

                PlayerHealthController.instance.CaniArtirFNC();

                Destroy(gameObject);
                Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
            }

            
        }
    }
}
