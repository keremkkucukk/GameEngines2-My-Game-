using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iskeletAttackController : MonoBehaviour
{
    [SerializeField]
    Transform attackPos;

    [SerializeField]
    float atakYaricap;

    [SerializeField]
    LayerMask playerLayer;


    public void AtakYapFNC()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(attackPos.position, atakYaricap,playerLayer);

        if(playerCollider!=null && !playerCollider.GetComponent<PlayerHareketController>().playerCanverdimi)
        {
            playerCollider.GetComponent<PlayerHareketController>().GeriTepkiFNC();
            playerCollider.GetComponent<PlayerHealthController>().CaniAzaltFNC();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, atakYaricap);
    }

}
