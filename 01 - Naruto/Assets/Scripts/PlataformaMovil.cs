using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    private Transform miTransform;
    private float tiempoActual;

    [Header("Variable para la velocidad de movimiento")]
    public float velocidad;

    [Header("Variable para la dirección de la plataforma")]
    public string direccion;

    [Header("Variable para el tiempo que transcurre hasta cambiar de dirección")]
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        tiempoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual += Time.deltaTime;
        if (direccion.Equals("Horizontal"))
        {
            miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }else
        {
            miTransform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (tiempoActual >= tiempo)
        {
            velocidad *= -1;
            tiempoActual = 0;
        }

    }
}
