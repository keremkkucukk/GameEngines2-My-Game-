using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilicToplamaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(other!=null)
            {
                other.GetComponent<PlayerHareketController>().NormaliKapatKiliciAc();

                Destroy(gameObject);

            }


        }
    }

}
