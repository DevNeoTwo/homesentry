using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadescreen : MonoBehaviour
{
    [SerializeField] Image imagen;
    [SerializeField] float duracion;
    public bool faded;
    cambiarnivel cambialvlscript;
    audiomanager audiomanagerscript;
    [SerializeField] bool fadeinicial;
    [SerializeField] GameObject UIitem;
    private void Start()
    {
        faded = false;
        audiomanagerscript = FindObjectOfType<audiomanager>();
        cambialvlscript =FindObjectOfType<cambiarnivel>();

        if(fadeinicial){

            StartCoroutine(fadeclaro());

        }
        
    }

    IEnumerator fadeclaro()
    {
        Color colorinicial = imagen.color;
        Color objetivocolor = new Color(0, 0, 0, 0);

        float tiempopasado = 0f;
        while(tiempopasado<duracion)
        {
            tiempopasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempopasado / duracion);
            imagen.color=Color.Lerp(colorinicial, objetivocolor, t);
            yield return null;
        }
        imagen.color = objetivocolor;
        
        faded = true;
    }

    IEnumerator fadeobscuro()
    {
        Color colorinicial = imagen.color;
        Color objetivocolor = new Color(0, 0, 0, 1);

        float tiempopasado = 0f;
        while (tiempopasado < duracion)
        {
            tiempopasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempopasado / duracion);
            imagen.color = Color.Lerp(colorinicial, objetivocolor, t);
            yield return null;
        }
        imagen.color = objetivocolor;
        
        faded = false;
        cambialvlscript.cambiaescena();
    }

    public void hacefade()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        if (!faded)
        {
            StartCoroutine(fadeclaro());
        }
        else
        {
            StartCoroutine(fadeobscuro());
        }
        if (!fadeinicial)
        {
            UIitem.SetActive(false);
        }
        
    }
}
