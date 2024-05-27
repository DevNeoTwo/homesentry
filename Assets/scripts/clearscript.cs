using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class clearscript : MonoBehaviour
{
    [SerializeField] Image imagen;
    [SerializeField] float duracion;
    bool faded;
    void Start()
    {
        StartCoroutine(fadeclaro());
    }

    IEnumerator fadeclaro()
    {
        Color colorinicial = imagen.color;
        Color objetivocolor = new Color(0, 0, 0, 0);

        float tiempopasado = 0f;
        while (tiempopasado < duracion)
        {
            tiempopasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempopasado / duracion);
            imagen.color = Color.Lerp(colorinicial, objetivocolor, t);
            yield return null;
        }
        imagen.color = objetivocolor;

        faded = true;
        if (faded)
        {
            Destroy(this.gameObject);
        }
    }
}
