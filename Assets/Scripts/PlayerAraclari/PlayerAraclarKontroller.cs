using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAraclarKontroller : MonoBehaviour
{
    [SerializeField]
    bool kilicmi, mizrakmi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(other!=null && kilicmi)
            {
                other.GetComponent<PlayerHareketController>().NormaliKapatKiliciAc();


            }

            if (other != null && mizrakmi)
            {
                other.GetComponent<PlayerHareketController>().HerseyiKapatMizrakAc();
            }

            Destroy(gameObject);

        }
    }

}
