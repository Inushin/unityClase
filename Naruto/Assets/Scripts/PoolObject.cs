using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public GameObject shuriken;
    public int cantidad;
    private List<GameObject> listaShurikens;

    // Start is called before the first frame update
    void Start()
    {
        listaShurikens = new List<GameObject>();
        for(int i = 0; i < cantidad; i++)
        {
            listaShurikens.Add(Instantiate(shuriken));
        }
    }

    public void CrearShurikens(Vector3 pos)
    {
        GameObject shurikensColocar = listaShurikens[0];
        listaShurikens.RemoveAt(0);
        shurikensColocar.transform.position = pos;
        shurikensColocar.SetActive(true);
    }

    public void AnadirShuriken(GameObject shurikenAnadir)
    {
        listaShurikens.Add(shurikenAnadir);
    }
}
