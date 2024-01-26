using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    

    float halfYukseklik, halfGenislik;


    Vector2 sonPos;

    [SerializeField]
    Transform backgrounds;


    


    private void Start()
    {
        halfYukseklik = Camera.main.orthographicSize;

        halfGenislik = halfYukseklik * Camera.main.aspect;

        sonPos = transform.position;
    }

    private void Update()
    {
        

        if(backgrounds!=null)
        {
            BackgroundHareketFNC();
        }

    }


    void BackgroundHareketFNC()
    {
        Vector2 aradakiFark = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);

        backgrounds.position += new Vector3(aradakiFark.x, aradakiFark.y, 0f);

        sonPos = transform.position;
    }
}
