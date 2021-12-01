using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPajaro : MonoBehaviour
{
    [Header("Velocidad del pájaro")]
    public int velocidad;
    private Transform miTransform;
    private float tiempoActual;
    [Header("Frecuencia de bombas")]
    public float tiempoALanzar;
    [Header("Prefab bomba")]
    public GameObject bomba;
    [Header("Posición de la generación de la bomba")]
    public Transform posBomba;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        tiempoActual += Time.deltaTime;
        if(tiempoActual >= tiempoALanzar)
        {
            lanzarBomba();
            tiempoActual = 0;
        }
    }

    private void lanzarBomba()
    {
        Instantiate(bomba, posBomba.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Columnas"))
        {
            velocidad *= -1;
            miTransform.localScale = new Vector3(miTransform.localScale.x*-1, 1, 1);
        }
    }
}

