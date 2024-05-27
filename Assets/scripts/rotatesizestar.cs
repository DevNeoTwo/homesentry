using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotatesizestar : MonoBehaviour
{
    [SerializeField] float velocidadrota;
     Image imagen;
    [SerializeField] float escala;
    [SerializeField] float duracion;
    [SerializeField] float delay;
    bool escalando = true;
    private void Start()
    {
        imagen = GetComponent<Image>();
        
    }
    void Update()
    {
        imagen.rectTransform.Rotate(0,0, velocidadrota*Time.deltaTime);
        StartCoroutine(escalador());
    }
    IEnumerator escalador()
    {
        while (escalando) { 
        Vector3 escalaoriginal = imagen.rectTransform.localScale;
        Vector3 objetivoescala = escalaoriginal * escala;
        float tiempopasado = 0f;
        while(tiempopasado<duracion)
        {
            tiempopasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempopasado / duracion);
            imagen.rectTransform.localScale = Vector3.Lerp(escalaoriginal,objetivoescala,t);
            yield return null;
        }
        imagen.rectTransform.localScale = objetivoescala;
        yield return new WaitForSeconds(delay);
        tiempopasado = 0f;
        while (tiempopasado< duracion)
        {
            tiempopasado += Time.deltaTime;
            float t=Mathf.Clamp01(tiempopasado/duracion);
            imagen.rectTransform.localScale=Vector3.Lerp(objetivoescala,escalaoriginal,t);
            yield return null;
        }
        imagen.rectTransform.localScale = escalaoriginal;
        }
    }
}
