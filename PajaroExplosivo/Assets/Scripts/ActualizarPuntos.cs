using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ActualizarPuntos : MonoBehaviour
{
    private TextMeshProUGUI marcador;
    private int puntos = 0;
    public int vidas = 3;
    public TextMeshProUGUI marcadorVidas;
    // Start is called before the first frame update
    void Start()
    {
        marcador = GetComponent<TextMeshProUGUI>();
        marcador.text = puntos + "";
        marcadorVidas.text = vidas + "";
    }

    public void restarVidas()
    {
        vidas--;
        marcadorVidas.text = vidas + "";
        if (vidas <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void actualizarPuntos()
    {
        puntos += 1;
        marcador.text = puntos+"";
    }
}
