using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAraclarKontroller : MonoBehaviour
{
    [SerializeField]
    bool kilicmi, mizrakmi, okmu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(other!=null && kilicmi)
            {
                other.GetComponent<PlayerHareketController>().HerseyiKapatKiliciAc();


            }

            if (other != null && mizrakmi)
            {
                other.GetComponent<PlayerHareketController>().HerseyiKapatMizrakAc();
            }

            if (other != null && okmu)
            {
                other.GetComponent<PlayerHareketController>().HerseyiKapatOkuAc();
            }

            Destroy(gameObject);

        }
    }

}
