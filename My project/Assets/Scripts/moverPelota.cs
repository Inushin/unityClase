using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPelota : MonoBehaviour
{

    public Vector3 direccion;
    public float velocidad;
    public Transform miTransform;


    // Start is called before the first frame update
    void Start()
    {
        miTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(direccion * velocidad * Time.deltaTime);
    }
}
