using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private Animator miAnimator;
    // Start is called before the first frame update
    void Start()
    {
        miAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Suelo"))
        {
            miAnimator.SetTrigger("Explotar");
            GetComponent<Collider2D>().isTrigger = true;

            GameObject.Find("Marcador").GetComponent<ActualizarPuntos>().restarVidas();

        }else if (collision.transform.tag.Equals("Gorro"))
        {
            destruirBomba();
            GameObject.Find("Marcador").GetComponent<ActualizarPuntos>().actualizarPuntos();
        }
    }

    public void destruirBomba()
    {
        Destroy(this.gameObject);
    }


}
