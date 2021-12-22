using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDisparo : MonoBehaviour
{
    private Transform miTransform;
    public int velocidad;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("naruto"))
        {
            Destroy(collision.transform.gameObject);
        }
    }

    public void desaparecer()

    {
        Destroy(this.gameObject);
    }
}
