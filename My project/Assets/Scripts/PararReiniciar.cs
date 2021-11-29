using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararReiniciar : MonoBehaviour
{

    public GameObject pelota;

    public void Parar()
    {
        pelota.GetComponent<moverPelota>().velocidad = 0;
    }

}
