using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    Transform ZeminKontrolNoktasi;

    public LayerMask zeminMaske;

    public float hareketHizi;
    public float ziplamaGucu;



    bool zemindemi;
    bool ikinciKezZiplasinmi;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        HareketEt();
        ZiplaFNC();
    }


    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * hareketHizi, rb.velocity.y);
    }

    void ZiplaFNC()
    {
        zemindemi = Physics2D.OverlapCircle(ZeminKontrolNoktasi.position, .2f, zeminMaske);

        if(Input.GetButtonDown("Jump") && (zemindemi  || ikinciKezZiplasinmi))
        {
            if(zemindemi)
            {
                ikinciKezZiplasinmi = true;
            }
            else
            {
                ikinciKezZiplasinmi = false;
            }

            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
        }
    }
}
