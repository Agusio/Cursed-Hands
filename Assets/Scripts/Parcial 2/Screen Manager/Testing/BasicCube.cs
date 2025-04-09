using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCube : MonoBehaviour
{
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime;
    }
}
