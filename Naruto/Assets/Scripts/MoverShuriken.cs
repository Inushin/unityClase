using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShuriken : MonoBehaviour
{
    private Transform miTransform;
    public int velocidad;
    public Vector3 _velocidad;
    public Transform posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        posicionInicial = GameObject.Find("posDisparo").transform;
        InvokeRepeating("reiniciar", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime); 
    }

    public void reiniciar()
    {
        this.gameObject.SetActive(false);
        miTransform.position = this.posicionInicial.position;
        GameObject.Find("PoolObjectManager").GetComponent<PoolObject>().AnadirShuriken(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("itachi"))
        {
            collision.transform.gameObject.GetComponent<Animator>().SetTrigger("impacto");
            this.reiniciar();
        }
    }
}
