using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkController : MonoBehaviour
{
    [SerializeField]
    GameObject parlamaEfect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("iskeletLayer")))
        {
            if(other.CompareTag("iskelet"))
            {
                gameObject.SetActive(false);
                Instantiate(parlamaEfect, other.transform.position, other.transform.rotation);
                other.GetComponent<iskeletHealthController>().CaniAzaltFNC();
            }
        }
    }


}
