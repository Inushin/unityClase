using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelota : MonoBehaviour
{
    public int velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        velocidad = 2;
        _velocidad.x = 3;
        _velocidad.y = 2;

    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Columna"))
        {
            _velocidad.x *= -1;
        }else if (collision.transform.tag.Equals("Suelo"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }else if (collision.transform.tag.Equals("Techo"))
        {
            _velocidad.y *= -1;
        }
        else if (collision.transform.tag.Equals("BloqueArriba") || collision.transform.tag.Equals("BloqueAbajo"))
        {
            _velocidad.y *= -1;
            Destroy(collision.transform.parent.gameObject);
            GameObject.Find("Padre").gameObject.GetComponent<Control>().ComprobarHijos();
        }
        else if (collision.transform.tag.Equals("BloqueLaterales"))
        {
            _velocidad.x *= -1;
            Destroy(collision.transform.parent.gameObject);
            GameObject.Find("Padre").gameObject.GetComponent<Control>().ComprobarHijos();
        }


        if (collision.transform.tag.Equals("Pala"))
        {
            _velocidad.y *= -1;
        }



    }
}
