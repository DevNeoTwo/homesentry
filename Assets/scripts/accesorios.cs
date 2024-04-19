using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accesorios : MonoBehaviour
{
    [SerializeField] GameObject[] zapatoshombre;
    [SerializeField] GameObject[] zapatosmujer;
    [SerializeField] GameObject[] carnet;
    [SerializeField] GameObject[] cosasseguridad;

   public bool botas;
    public bool carnetbool;
    public bool escudo;
    public bool codigobarras;

    audiomanager audiomanagerscript;
    fadescreen fadescreenscript;
    public int opcionseleccionada;
    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript= FindObjectOfType<fadescreen>();
    }
    public void zapatoboton()
    {
        if (fadescreenscript.faded)  {

            zapatoshombre[0].SetActive(false);
            zapatoshombre[1].SetActive(true);

            zapatosmujer[0].SetActive(false);
            zapatosmujer[1].SetActive(true);
            audiomanagerscript.selectaudio(0, 0.7f);
            botas = true;
        } 
        
    }
    public void botoncarnet()
    {
        if (fadescreenscript.faded)
        {
            carnet[0].SetActive(true);
            carnet[1].SetActive(true);
            carnetbool = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }

    public void botonescudito()
    {
        if (fadescreenscript.faded) {
            cosasseguridad[0].SetActive(true);
            escudo = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }

    public void botoncodigobbarras()
    {
        if (fadescreenscript.faded)
        {
            cosasseguridad[1].SetActive(true);
            codigobarras = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }
}
