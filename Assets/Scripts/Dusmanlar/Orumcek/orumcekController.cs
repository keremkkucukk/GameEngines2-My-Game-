using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orumcekController : MonoBehaviour
{
    [SerializeField]
    Transform[] posizyonlar;

    public float orumcekHizi;

    public float beklemeSuresi;

    float beklemeSayac;

    Animator anim;

    int kacinciPosizyon;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        foreach (Transform pos in posizyonlar)
        {
            pos.parent = null;
        }
    }
    private void Update()
    {
        if(beklemeSayac > 0)
        {
            beklemeSayac -= Time.deltaTime;
            anim.SetBool("hareketEtsinmi", false);
        }
        else
        {
            anim.SetBool("hareketEtsinmi", true);

            if(transform.position.x > posizyonlar[kacinciPosizyon].position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x < posizyonlar[kacinciPosizyon].position.x)
            {
                transform.localScale = Vector3.one;
            }

            transform.position = Vector3.MoveTowards(transform.position, posizyonlar[kacinciPosizyon].position, orumcekHizi*Time.deltaTime);

            if (Vector3.Distance(transform.position, posizyonlar[kacinciPosizyon].position) < 0.1f)
            {
                beklemeSayac = beklemeSuresi;
                PosizyonuDegistir();
            }
        }
        
    }

    void PosizyonuDegistir()
    {
        kacinciPosizyon++;

        if (kacinciPosizyon >= posizyonlar.Length)
            kacinciPosizyon = 0;
    }
}
