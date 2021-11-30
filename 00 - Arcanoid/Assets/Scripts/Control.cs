using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject[] niveles;
    static public int nivelActual;
    public Transform Padre;
    public GameObject Win;

    // Start is called before the first frame update
    void Start()
    {
        Padre = (Instantiate(niveles[nivelActual]) as GameObject).transform;
    }

    public void ComprobarHijos()
    {
        if(Padre.childCount == 1)
        {
            ActivarPanel();
        }
    }

    public void ActivarPanel()
    {
        Control.nivelActual++;
        if (Control.nivelActual >= niveles.Length)
        {
            Time.timeScale = 0;
            Win.SetActive(true);
        }
        else
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Continuar");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
