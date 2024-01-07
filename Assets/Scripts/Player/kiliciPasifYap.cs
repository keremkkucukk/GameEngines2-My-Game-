using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiliciPasifYap : MonoBehaviour
{
    public GameObject kilicVurusBox;

    public void KiliciKapat()
    {
        kilicVurusBox.SetActive(false);
    }
}
