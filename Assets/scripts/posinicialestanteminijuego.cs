using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posinicialestanteminijuego : MonoBehaviour
{

    [SerializeField] GameObject[] objetos;
    [SerializeField] Transform[] posiciones;
    void Start()
    {
       /* for(int i = 0;i<posiciones.Length;i++)
        {*/
            List<Transform> posicioneslist = new List<Transform> { posiciones[0], posiciones[1], posiciones[2] };

        cambiaposiciones(posicioneslist);

            objetos[0].transform.position = posicioneslist[0].transform.position;
            objetos[1].transform.position = posicioneslist[1].transform.position;
            objetos[2].transform.position = posicioneslist[2].transform.position;
        
        

    }
    void cambiaposiciones(List<Transform> posicioneslist)
    {
        int n=posicioneslist.Count;
        while (n > 1)
        {
            n--;
            int k=Random.Range(0,n+1);
            Transform valor = posicioneslist[k];
            posicioneslist[k] = posicioneslist[n];
            posicioneslist[n]= valor;
        }
    }
  
}
