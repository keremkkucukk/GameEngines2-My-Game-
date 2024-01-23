using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkYokEtManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ok"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
