using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour
{

    public int velocidad;
    private int _velocidad;
    private Transform miTransform;
    private bool dentroPlataforma;
    private bool parado;
    private float crono;

    private Animator miAnimator;
    public LayerMask mascaras;
    public Transform topLeftPos, bottomRightPos;

    private GameObject naruto;
    public GameObject bolaFuego;
    public GameObject posBolaFuego;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        miTransform = this.transform;

        miAnimator = GetComponent<Animator>();
        dentroPlataforma = true;
        parado = false;
        crono = 0;
        _velocidad = velocidad;
        miAnimator.SetInteger("velocidad", 1);
        naruto = GameObject.Find("Naruto_0");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, naruto.transform.position);
        if (distance > 2)
        {
            miTransform.Translate(Vector3.right * _velocidad * Time.deltaTime);
            dentroPlataforma = Physics2D.OverlapArea(topLeftPos.position, bottomRightPos.position, mascaras);
        
            if (!dentroPlataforma && !parado)
        {
            parar();
        }
            if (parado)
            {
                crono += Time.deltaTime;
                if (crono >= 2)
                {
                    arrancar();
                    crono = 0;
                }
            }
            else
            {
                parar();
                disparar();
            }
        }
    }

    private void disparar()
    {
        Debug.Log("*****DISPARO*****");
        miAnimator.SetTrigger("disparo");
    }

    public void fuego()
    {
        GameObject disparo = Instantiate(bolaFuego);
        disparo.transform.position = posBolaFuego.transform.position;
    }

    private void parar()
    {
        this.velocidad *= -1;
        _velocidad = 0;
        parado = true;
        miAnimator.SetInteger("velocidad", _velocidad);
    }

    private void arrancar()
    {
        _velocidad = velocidad;
        dentroPlataforma = true;
        miAnimator.SetInteger("velocidad", 1);
        miTransform.localScale = new Vector3(miTransform.localScale.x * -1, 1, 1);
        parado = false;
    }

    public void impacto_shuriken()
    {
        Destroy(this.gameObject);
    }

}
