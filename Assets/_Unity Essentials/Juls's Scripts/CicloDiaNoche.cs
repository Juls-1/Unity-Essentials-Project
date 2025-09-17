using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    public float rotationSpeed = 0.8f;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
