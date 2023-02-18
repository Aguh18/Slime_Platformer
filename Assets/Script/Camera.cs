using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float Cameraspeed;
    public Transform playerpos;
    public  Vector3 offset;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerpos.position + offset, Cameraspeed* Time.deltaTime );
    }
}
