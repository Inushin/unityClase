using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverGorro : MonoBehaviour
{
    private Transform miTransform;
    public int velocidad;
    public Vector3 _velocidad;
      

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocidad = 3;
            _velocidad.x = 1;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocidad = 3;
            _velocidad.x = -1;
        }
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }

}
