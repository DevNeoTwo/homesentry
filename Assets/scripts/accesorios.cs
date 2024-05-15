using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Image[] boton;
    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript= FindObjectOfType<fadescreen>();

        cosasseguridad[0].SetActive(true);
        cosasseguridad[1].SetActive(false);

        cosasseguridad[2].SetActive(true);
        cosasseguridad[3].SetActive(false);
    }
    public void zapatoboton()
    {
        if (fadescreenscript.faded)  {

            boton[0].color = new Color32(11, 52, 144, 255);
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
            boton[1].color = new Color32(11, 52, 144, 255);
            carnet[0].SetActive(true);
            carnet[1].SetActive(true);
            carnetbool = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }

    public void botonescudito()
    {
        if (fadescreenscript.faded) {
            boton[2].color = new Color32(11, 52, 144, 255);
            cosasseguridad[0].SetActive(false);
            cosasseguridad[1].SetActive(true);
            escudo = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }

    public void botoncodigobbarras()
    {
        if (fadescreenscript.faded)
        {
            boton[3].color = new Color32(11, 52, 144, 255);
            cosasseguridad[2].SetActive(false);
            cosasseguridad[3].SetActive(true);
            codigobarras = true;
            audiomanagerscript.selectaudio(0, 0.7f);
        }
        
    }
}
