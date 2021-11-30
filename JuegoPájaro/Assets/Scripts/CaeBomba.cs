using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaeBomba : MonoBehaviour
{
    public float velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    public int contador = 0;
    public SceneManager escena;
    public GameObject over;
   
    public GameObject bomba;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("gorroEntrada"))
        {

            Debug.Log("punto");
            Destroy(bomba);
            
        } else if (collision.transform.tag.Equals("suelo"))
        {
            Destroy(bomba);
            Debug.Log("-1");
            contador ++;
            if (contador == 3)
            {
                over.SetActive(true);
            }
        }
    }

}
