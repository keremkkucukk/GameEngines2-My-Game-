using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkPoolManager : MonoBehaviour
{
    public static OkPoolManager instance;

    [SerializeField]
    GameObject okPrefab;

    GameObject okObje;

    List<GameObject> okPool = new List<GameObject> ();

    private void Awake()
    {
        instance = this;

        OklariOlusturFNC();
    }

    void OklariOlusturFNC()
    {
        for( int i = 0; i < 10; i++)
        {
            okObje = Instantiate(okPrefab);
            okObje.SetActive(false);
            okObje.transform.parent = transform;

            okPool.Add(okObje);
        }
    }

    public void OkuFirlatFNC(Transform okCikisNoktasi, Transform parent)
    {
        for(int i = 0; i < okPool.Count; i++)
        {
            if (!okPool[i].gameObject.activeInHierarchy)
            {
                okPool[i].transform.localScale = parent.localScale;
                okPool[i].gameObject.SetActive(true);
                okPool[i].gameObject.transform.position = okCikisNoktasi.position;

                if(parent.transform.localScale.x>0)
                {
                    okPool[i].GetComponent<Rigidbody2D>().velocity = okCikisNoktasi.right * transform.localScale.x * 15f;
                }
                else
                {
                    okPool[i].GetComponent<Rigidbody2D>().velocity = -okCikisNoktasi.right * transform.localScale.x * 15f;
                }

                return;

            }
            
        }
    }

}
