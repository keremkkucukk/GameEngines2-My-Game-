using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalinanEngelController : MonoBehaviour
{
    [SerializeField]
    float donmeHizi = 200f;

    float zAngle;

    [SerializeField]
    float minZAngle = -75f;

    [SerializeField]
    float maxZAngle = 75f;

    private void Start()
    {
        if (Random.Range(0, 2) > 0)
            donmeHizi *= -1;
    }


    private void Update()
    {
        zAngle += Time.deltaTime * donmeHizi;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);

        if(zAngle < minZAngle)
        {
            donmeHizi = Mathf.Abs(donmeHizi);
        }
        if(zAngle > maxZAngle)
        {
            donmeHizi = -Mathf.Abs(donmeHizi);
        }
    }
}
