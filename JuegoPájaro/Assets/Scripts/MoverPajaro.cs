using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPajaro : MonoBehaviour
{

    [Header("Velocidad del pájaro")]
    public int velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    public float tiempoActual;
    [Header("Secuencia de bombas")]
    public float tiempoALanzar;
    public GameObject bomba;
    [Header("Posición bomba")]
    public Transform posBomba;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        velocidad = 3;
        _velocidad.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
        tiempoActual += Time.deltaTime;

        if (tiempoActual >= tiempoALanzar)
        {
            lanzarBomba();
            tiempoActual = 0;
        }
    }

    private void lanzarBomba()
    {
        Instantiate(bomba, posBomba.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("colIzq"))
        {
            _velocidad.x = 1;
        }else if (collision.transform.tag.Equals("colDrcha")) 
        {
            _velocidad.x = -1;
        }
    }
}
