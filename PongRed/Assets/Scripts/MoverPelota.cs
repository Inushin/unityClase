using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelota : MonoBehaviour
{
    private Transform miTransform;
    [Header("Velocidad Pelota")]
    public int velocidad;
    [Header("Direccion Pelota")]
    public Vector3 _velocidad;
    [Header("Script(Objecto) del servidor")]
    public GameObject server;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad*velocidad*Time.deltaTime);
        server.GetComponent<Server>().EnviarPosPelota(miTransform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("jugador"))
        {
            _velocidad.x *= -1;
            server.GetComponent<Server>().EnviarExplotar(miTransform.position);

        }
        else if (collision.transform.tag.Equals("laterales"))
        {
            _velocidad.x *= -1;
            miTransform.position = new Vector3(0, 0, 0);
        }
        else if (collision.transform.tag.Equals("arriba-abajo"))
        {
            _velocidad.y *= -1;
            server.GetComponent<Server>().EnviarExplotar(miTransform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }


}
