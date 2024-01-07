using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandikController : MonoBehaviour
{
    Animator anim;

    int kacinciVurus;

    [SerializeField]
    GameObject parlamaEfekti;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        kacinciVurus = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("kilicVurusBox"))
        {
            if(kacinciVurus == 0)
            {

                anim.SetTrigger("sallanma");

                Instantiate(parlamaEfekti, transform.position, transform.rotation);
            } else if (kacinciVurus == 1)
            {
                anim.SetTrigger("sallanma");
                Instantiate(parlamaEfekti, transform.position, transform.rotation);

            }
            else
            {
                anim.SetTrigger("parcalanma");
            }
            kacinciVurus++;
            
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
