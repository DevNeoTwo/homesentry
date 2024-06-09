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
    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript= FindObjectOfType<fadescreen>();
        instruccionnumero = 0;
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
            textotuto.text = "Activar la ARL es muy importante antes de empezar a trabajar";
            transformtuto.anchoredPosition = new Vector2(0f, 75f);
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
            textotuto.text = "Registrar tu hora de ingreso a trabajar nos ayudará a llevar un mejor control de tu tiempo trabajado";
            transformtuto.anchoredPosition = new Vector2(0f, 143f);
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
            textotuto.text = "Presiona aquí para rotar tu avatar y tener una vista de 360°";
            transformtuto.anchoredPosition = new Vector2(81f, -148f);
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
            textotuto.text = "Escoge el color de piel de tu avatar";
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
            textotuto.text = "Cambia entre diferentes estilos de cabello para tu avatar y Escoge el color que más te guste";
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
            textotuto.text = "Escoge el género de tu avatar";
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
            textotuto.text = "Selecciona la camiseta que más te guste";
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
            textotuto.text = "Selecciona el pantalón que más te guste";
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
            textotuto.text = "Ponte las botas especiales para trabajar";
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
            textotuto.text = "El carnet que te identifica siempre a la vista generara una mayor confianza hacia los clientes";
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
