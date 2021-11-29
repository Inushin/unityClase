using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPalas : MonoBehaviour
{

    private Transform miTransform2;
    public int velocidad;
    public Vector3 _velocidad;

    // Start is called before the first frame update
    void Start()
    {
        miTransform2 = this.transform;
        velocidad = 2;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform2.Translate(_velocidad * velocidad * Time.deltaTime);
        Movimiento();
    }

    private void Movimiento()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _velocidad.x = 2;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _velocidad.x = -2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag.Equals("Columna"))
        {
            _velocidad.x = 0;
        }
    }

}
