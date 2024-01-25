using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iskeletHealthController : MonoBehaviour
{
    public int maxSaglik;

    int gecerliSaglik;

    public bool iskeletOldumu;

    private void Start()
    {
        gecerliSaglik = maxSaglik;
        iskeletOldumu = false;
    }

    public void CaniAzaltFNC()
    {
        gecerliSaglik--;

        if(gecerliSaglik<=0)
        {
            gecerliSaglik = 0;
            iskeletOldumu = true;
            GetComponent<Animator>().SetTrigger("caniniVerdi");
            GetComponent<BoxCollider2D>().enabled = false;
            iskeletSpawnController.instance.ListeyiAzalt(this.gameObject);
            Destroy(gameObject, 3f);
        }
    }
}
