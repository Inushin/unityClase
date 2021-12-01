using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverGorro : MonoBehaviour
{
    public float velocidad;
    private Transform miTransform;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            miTransform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }
}
