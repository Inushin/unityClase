using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverShuriken : MonoBehaviour
{

    private Transform miTransform;
    public int velocidad;
    public Vector3 _velocidad;
    public Transform posInicial;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        posInicial = GameObject.Find("posDisparo").transform;
        InvokeRepeating("reiniciar", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }

    public void Reiniciar()
    {
        this.gameObject.SetActive(false);
        miTransform.position = this.posInicial.position;
        GameObject.Find("PullObjectManager").GetComponent<PullObject>().AnadirShuriken(this.gameObject);
    }
}
