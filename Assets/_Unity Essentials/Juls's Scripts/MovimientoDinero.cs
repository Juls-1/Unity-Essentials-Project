using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDinero : MonoBehaviour
{
    public float rotationSpeed=0.8f;

    public AudioClip pickupSound;
    public GameObject onCollectEffect;
    private Vector3 posicionInicial;
    public float amplitud = 0.01f;
    public float frecuencia = 1f;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);

        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * frecuencia) * amplitud;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }

}
