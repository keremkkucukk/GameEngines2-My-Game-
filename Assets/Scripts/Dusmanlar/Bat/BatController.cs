using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [SerializeField]
    float takipMesafesi = 8f;

    [SerializeField]
    float batHiz;

    [SerializeField]
    Transform hedefPlayer;

    Animator anim;

    Rigidbody2D rb;

    BoxCollider2D batCollider;

    public float atakYapmaSuresi;
    float atakYapmaSayac;

    float mesafe;

    Vector2 hareketYonu;

    public int maxSaglik;
    int gecerliSaglik;

    [SerializeField]
    GameObject iksirPrefab;

    private void Awake()
    {
        hedefPlayer = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        batCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        if(atakYapmaSayac<0)
        {
            if(hedefPlayer && gecerliSaglik>0 && !PlayerHareketController.instance.playerCanverdimi)
            {
                mesafe = Vector2.Distance(transform.position, hedefPlayer.position);

                if (mesafe < takipMesafesi)
                {
                    anim.SetTrigger("ucusaGecti");

                    hareketYonu = hedefPlayer.position - transform.position;

                    if (transform.position.x > hedefPlayer.position.x)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (transform.position.x < hedefPlayer.position.x)
                    {
                        transform.localScale = Vector3.one;
                    }

                    rb.velocity = hareketYonu * batHiz;

                }
            }

        }
        else
        {
            atakYapmaSayac -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(batCollider.IsTouchingLayers(LayerMask.GetMask("PlayerLayer")))
        {
            if(other.CompareTag("Player"))
            {
                rb.velocity = Vector2.zero;
                atakYapmaSayac = atakYapmaSuresi;
                anim.SetTrigger("atakYapti");

                other.GetComponent<PlayerHareketController>().GeriTepkiFNC();
                other.GetComponent<PlayerHealthController>().CaniAzaltFNC();
            }
        }
    }

    public void CaniAzaltFNC()
    {
        gecerliSaglik--;
        atakYapmaSayac = atakYapmaSuresi;

        rb.velocity = Vector2.zero;

        if(gecerliSaglik<=0)
        {
            gecerliSaglik = 0;
            batCollider.enabled = false;

            Instantiate(iksirPrefab, transform.position, Quaternion.identity);

            anim.SetTrigger("canVerdi");
            Destroy(gameObject, 3f);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, takipMesafesi);
    }
}
