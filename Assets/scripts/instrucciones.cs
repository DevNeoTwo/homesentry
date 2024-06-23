using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class instrucciones : MonoBehaviour
{
    public int instruccionnumero;
    [SerializeField] GameObject[] imageninstruccion;
    [SerializeField] RectTransform transformtuto;
    [SerializeField] TextMeshProUGUI textotuto;
    [SerializeField] string nivel;
    audiomanager audiomanagerscript;
    fadescreen fadescreenscript;
    [SerializeField] GameObject backbtn;
    [SerializeField] RectTransform nextbtn;
    [SerializeField] GameObject cuadritoextra;
    [SerializeField] RectTransform transfortext;
    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript= FindObjectOfType<fadescreen>();
        instruccionnumero = 0;
        cuadritoextra.SetActive(false);
    }
    private void LateUpdate()
    {
        if(instruccionnumero == 0)
        {
            imageninstruccion[0].SetActive(true);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Escribe aquí tu nombre";
            transformtuto.anchoredPosition=new Vector2 (0f, -148f);
            transfortext.anchoredPosition = new Vector2(0f, 21f);
            backbtn.SetActive(false);
            nextbtn.anchoredPosition = new Vector2(-420, 51);
        }
        if(instruccionnumero == 1)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(true);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            cuadritoextra.SetActive(false);
            textotuto.text = "Antes de ingresar a la tienda, verifica \n que cuentes con la ARL vigente y \n preséntala al equipo de seguridad";
            transformtuto.anchoredPosition = new Vector2(0f, 75f);
            transfortext.anchoredPosition = new Vector2(0f, 21f);
            backbtn.SetActive(true);
            nextbtn.anchoredPosition = new Vector2(-247, 51);
        }
        if (instruccionnumero == 2)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(true);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            cuadritoextra.SetActive(true);
            textotuto.text = "¿No registraste tu marcación? Verifica que\ncuentes con  el código de barras que te da\nel acceso a que puedas" +
                "registrar tu visita\ncon las siguientes recomendaciones";
            transfortext.anchoredPosition = new Vector2(-105f, 21f);
            transformtuto.anchoredPosition = new Vector2(0f, 143f);
            //x 105
            //x 0
        }
        if (instruccionnumero == 3)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(true);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            cuadritoextra.SetActive(false);
            textotuto.text = "Presiona aquí para rotar tu avatar y tener una\nvista de 360°";
            transformtuto.anchoredPosition = new Vector2(81f, -148f);
            transfortext.anchoredPosition = new Vector2(0f, 21f);
        }
        if (instruccionnumero == 4)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(true);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Elije el color de piel de tu personaje";
            transformtuto.anchoredPosition = new Vector2(96f, 230f);
        }
        if (instruccionnumero == 5)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(true);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Cambia entre diferentes estilos de cabello para\ntu personaje y Escoge el color que más te guste";
            transformtuto.anchoredPosition = new Vector2(-478f, -209f);
        }
        if (instruccionnumero == 6)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(true);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Escoge el género de tu personaje";
            transformtuto.anchoredPosition = new Vector2(1f, -194f);
        }
        if (instruccionnumero == 7)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(true);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Selecciona el uniforme que te\nidentificará en la tienda";
            transformtuto.anchoredPosition = new Vector2(-297f, -24f);
        }
        if (instruccionnumero == 8)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(true);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Elije el pantalón que complementa\ntu uniforme";
            transformtuto.anchoredPosition = new Vector2(0f, 80f);
        }
        if (instruccionnumero == 9)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(true);
            imageninstruccion[10].SetActive(false);
            textotuto.text = "Verifica que cuentes con (calzado de\nseguridad) para ingresar a la tienda";
            transformtuto.anchoredPosition = new Vector2(0f, 7f);
        }
        if (instruccionnumero == 10)
        {
            imageninstruccion[0].SetActive(false);
            imageninstruccion[1].SetActive(false);
            imageninstruccion[2].SetActive(false);
            imageninstruccion[3].SetActive(false);
            imageninstruccion[4].SetActive(false);
            imageninstruccion[5].SetActive(false);
            imageninstruccion[6].SetActive(false);
            imageninstruccion[7].SetActive(false);
            imageninstruccion[8].SetActive(false);
            imageninstruccion[9].SetActive(false);
            imageninstruccion[10].SetActive(true);
            textotuto.text = "Usa siempre un carnet que contenga tu nombre\ny la marca que representas en la tienda";
            transformtuto.anchoredPosition = new Vector2(0f, 0f);
        }
    }

    public void siguienteinstruccion() 
    {
        
        if (instruccionnumero <= 10)
        {
            instruccionnumero++;
            
        }
        if(instruccionnumero > 10)
        {
            
            omitir();
        }
        if(instruccionnumero <= 10)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
        }
    }

    public void anteriorinstruccion()
    {
       
        if (instruccionnumero > 0)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            instruccionnumero--;
        }
    }

    public void omitir()
    {
        fadescreenscript.hacefade();
        //audiomanagerscript.selectaudio(0, 0.7f);
        //SceneManager.LoadScene(nivel);
    }

   
}
