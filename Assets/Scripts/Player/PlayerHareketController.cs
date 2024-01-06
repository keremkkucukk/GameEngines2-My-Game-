using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    public static PlayerHareketController instance;

    Rigidbody2D rb;

    [SerializeField]
    Transform ZeminKontrolNoktasi;

    [SerializeField]
    Animator anim;

    [SerializeField]
    SpriteRenderer sr;

    public LayerMask zeminMaske;

    public float hareketHizi;
    public float ziplamaGucu;



    bool zemindemi;
    bool ikinciKezZiplasinmi;

    [SerializeField]
    float geriTepkiSuresi, geriTepkiGucu;

    float geriTepkiSayaci;

    bool yonSagdami;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(geriTepkiSayaci <= 0)
        {
            HareketEt();
            ZiplaFNC();
            YonuDegistirFNC();

            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
        else
        {
            geriTepkiSayaci -= Time.deltaTime;

            if(yonSagdami)
            {
                rb.velocity = new Vector2(-geriTepkiGucu, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(geriTepkiGucu, rb.velocity.y);

            }
        }


        anim.SetBool("zemindemi", zemindemi);
        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
    }


    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(h * hareketHizi, rb.velocity.y);
        
    }

    void YonuDegistirFNC()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            yonSagdami = false;
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
            yonSagdami = true;
        }
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

    public void GeriTepkiFNC()
    {
        geriTepkiSayaci = geriTepkiSuresi;

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);


        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
