using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D kilicVurusBox;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(kilicVurusBox.IsTouchingLayers(LayerMask.GetMask("DusmanLayer")))
        {
            if(other.CompareTag("Orumcek"))
            {
                StartCoroutine(other.GetComponent<orumcekController>().GeriTepkiFNC());
            }
        }
    }
}
