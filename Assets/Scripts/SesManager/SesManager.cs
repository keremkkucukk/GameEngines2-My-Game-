using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesManager : MonoBehaviour
{
    public static SesManager instance;

    [SerializeField]
    AudioSource[] sesEfektleri;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);

        } else if(this !=instance)
        {
            Destroy(gameObject);
        }

        
    }
    public void SesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();
        sesEfektleri[hangiSes].Play();
    }

    public void KarisikSesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();
        sesEfektleri[hangiSes].pitch = Random.Range(0.8f, 1.3f);
        sesEfektleri[hangiSes].Play();
    }
}
