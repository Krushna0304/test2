using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float speed =25f;
    void Update()
    {
        transform.Rotate(0,speed * Time.deltaTime,0);
    }
}
