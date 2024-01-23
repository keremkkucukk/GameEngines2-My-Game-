using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHareketController : MonoBehaviour
{
    public static PlayerHareketController instance;

    Rigidbody2D rb;

    [SerializeField]
    GameObject normalPlayer, kilicPlayer, mizrakPlayer, okPlayer;

    [SerializeField]
    Transform ZeminKontrolNoktasi;

    [SerializeField]
    Animator normalAnim,kilicAnim, mizrakAnim, okAnim;

    [SerializeField]
    SpriteRenderer normalSprite,kilicSprite, mizrakSprite, okSprite;

    [SerializeField]
    GameObject kilicVurusBoxObje;


    public LayerMask zeminMaske;

    public float hareketHizi;
    public float ziplamaGucu;



    bool zemindemi;
    bool ikinciKezZiplasinmi;

    [SerializeField]
    float geriTepkiSuresi, geriTepkiGucu;

    float geriTepkiSayaci;

    bool yonSagdami;

    public bool playerCanverdimi;

    bool kiliciVurdumu;

    [SerializeField]
    GameObject atilacakMizrak;

    [SerializeField]
    Transform mizrakCikisNoktasi;

    [SerializeField]
    GameObject atilacakOk;

    [SerializeField]
    Transform okCikisNoktasi;

    private void Awake()
    {
        instance = this;
        kiliciVurdumu = false;

        rb = GetComponent<Rigidbody2D>();
        playerCanverdimi = false;

        kilicVurusBoxObje.SetActive(false);

    }


    private void Update()
    {
        if (playerCanverdimi)
            return;


        if(geriTepkiSayaci <= 0)
        {
            HareketEt();
            ZiplaFNC();
            YonuDegistirFNC();

            if(normalPlayer.activeSelf)
            {
                normalSprite.color = new Color(normalSprite.color.r, normalSprite.color.g, normalSprite.color.b, 1f);
            }
            if(kilicPlayer.activeSelf)
            {
                kilicSprite.color = new Color(kilicSprite.color.r, kilicSprite.color.g, kilicSprite.color.b, 1f);

            }
            if (mizrakPlayer.activeSelf)
            {
                mizrakSprite.color = new Color(mizrakSprite.color.r, mizrakSprite.color.g, mizrakSprite.color.b, 1f);

            }
            if (okPlayer.activeSelf)
            {
                okSprite.color = new Color(okSprite.color.r, okSprite.color.g, okSprite.color.b, 1f);

            }

            if (Input.GetMouseButtonDown(0) && kilicPlayer.activeSelf)
            {
                kiliciVurdumu = true;
                kilicVurusBoxObje.SetActive(true);

            }
            else
            {
                kiliciVurdumu = false;
            }

            if (Input.GetKeyDown(KeyCode.W)&& mizrakPlayer.activeSelf)
            {
                mizrakAnim.SetTrigger("mizrakAtti");
                Invoke("MizragiFirlat", .5f);
            }

            if (Input.GetKeyDown(KeyCode.E) && okPlayer.activeSelf)
            {
                okAnim.SetTrigger("okAtti");
                Invoke("OkuFirlat", .7f);
            }

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


        if(normalPlayer.activeSelf)
        {
            normalAnim.SetBool("zemindemi", zemindemi);
            normalAnim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        }

        if (kilicPlayer.activeSelf)
        {
            kilicAnim.SetBool("zemindemi", zemindemi);
            kilicAnim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
                        
        }

        if (mizrakPlayer.activeSelf)
        {
            mizrakAnim.SetBool("zemindemi", zemindemi);
            mizrakAnim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        }

        if (okPlayer.activeSelf)
        {
            okAnim.SetBool("zemindemi", zemindemi);
            okAnim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        }

        if (kiliciVurdumu && kilicPlayer.activeSelf)
        {
            kilicAnim.SetTrigger("kiliciVurdu");
        }

    }

    void MizragiFirlat()
    {
        GameObject mizrak = Instantiate(atilacakMizrak, mizrakCikisNoktasi.position, mizrakCikisNoktasi.rotation);
        mizrak.transform.localScale = transform.localScale;
        mizrak.GetComponent<Rigidbody2D>().velocity = mizrakCikisNoktasi.right * transform.localScale.x * 7f;

        Invoke("HerseyiKapatNormaliAc", .1f);
    }

    void OkuFirlat()
    {
        GameObject okObje = Instantiate(atilacakOk, okCikisNoktasi.position, okCikisNoktasi.rotation);
        okObje.transform.localScale = transform.localScale;

        okObje.GetComponent<Rigidbody2D>().velocity=okCikisNoktasi.right* transform.localScale.x * 15f;
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

        if (normalPlayer.activeSelf)
        {
            normalSprite.color = new Color(normalSprite.color.r, normalSprite.color.g, normalSprite.color.b, .5f);
        }

        if (kilicPlayer.activeSelf)
        {
            kilicSprite.color = new Color(kilicSprite.color.r, kilicSprite.color.g, kilicSprite.color.b, .5f);
        }

        if (mizrakPlayer.activeSelf)
        {
            mizrakSprite.color = new Color(mizrakSprite.color.r, mizrakSprite.color.g, mizrakSprite.color.b, .5f);
        }

        if (okPlayer.activeSelf)
        {
            okSprite.color = new Color(okSprite.color.r, okSprite.color.g, okSprite.color.b, .5f);
        }

        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void PlayerCanVerdiFNC()
    {
        rb.velocity = Vector2.zero;
        playerCanverdimi = true;

        if (normalPlayer.activeSelf)
        {
            normalAnim.SetTrigger("canVerdi");
        }

        if (kilicPlayer.activeSelf)
        {
            kilicAnim.SetTrigger("canVerdi");
        }

        if (mizrakPlayer.activeSelf)
        {
            mizrakAnim.SetTrigger("canVerdi");
        }

        if (okPlayer.activeSelf)
        {
            okAnim.SetTrigger("canVerdi");
        }


        StartCoroutine(PlayerYokEtSahneYenile());
    }

    IEnumerator PlayerYokEtSahneYenile()
    {
        yield return new WaitForSeconds(2f);

        GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NormaliKapatKiliciAc()
    {
        normalPlayer.SetActive(false);
        mizrakPlayer.SetActive(false);
        kilicPlayer.SetActive(true);
        okPlayer.SetActive(false);

    }

    public void HerseyiKapatMizrakAc()
    {
        normalPlayer.SetActive(false);
        kilicPlayer.SetActive(false);
        mizrakPlayer.SetActive(true);
        okPlayer.SetActive(false);

    }


    public void HerseyiKapatNormaliAc()
    {
        normalPlayer.SetActive(true);
        kilicPlayer.SetActive(false);
        mizrakPlayer.SetActive(false);
        okPlayer.SetActive(false);

    }


    public void HerseyiKapatOkuAc()
    {
        normalPlayer.SetActive(false);
        kilicPlayer.SetActive(false);
        mizrakPlayer.SetActive(false);
        okPlayer.SetActive(true);

    }


    public void PlayeriHareketsizYap()
    {
        if(normalPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            normalAnim.SetFloat("hareketHizi", 0f);
        }

        if (kilicPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            kilicAnim.SetFloat("hareketHizi", 0f);
        }

        if (mizrakPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            mizrakAnim.SetFloat("hareketHizi", 0f);
        }

        if (okPlayer.activeSelf)
        {
            rb.velocity = Vector2.zero;
            okAnim.SetFloat("hareketHizi", 0f);
        }
    }
}
