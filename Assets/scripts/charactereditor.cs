using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class charactereditor : MonoBehaviour {

    public static charactereditor instance;

    [SerializeField] GameObject[] spritegeneroui;
    [SerializeField] GameObject[] players;
    
    public Material pielmat;
     Renderer render;
    public bool mujer = false;
    
    public int color = 1;
    [SerializeField] float velocidadrota;
    public bool rotandoder;
    bool rotandoizq;
    audiomanager audiomanagerscript;
    fadescreen fadescreenscript;
    [SerializeField] Animator generoanim;
    [SerializeField] Animator cambiaropaanim_mujer;
    [SerializeField] Animator cambiaropaanim_hombre;

    public string nombrejugador;
    [SerializeField] TMP_InputField nombrepuesto;
    public bool textonombre;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        render = players[players.Length-1].GetComponent<Renderer>();
        fadescreenscript = FindObjectOfType<fadescreen>();
        if (render != null)
        {
            pielmat = render.material;
        }
        
        
    }
    private void FixedUpdate()
    {
        nombrejugador = nombrepuesto.text;
        if (rotandoder)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(0, velocidadrota * Time.deltaTime, 0,Space.World);
        }
        if (rotandoizq){
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(0, -velocidadrota * Time.deltaTime, 0, Space.World);
        }
        if (color == 1)
        {
            pielmat.color = new Color32(255, 196, 165, 255);
        }
        if (color == 2)
        {
            pielmat.color = new Color32(248, 178, 143, 255);
        }
        if (color == 3)
        {
            pielmat.color = new Color32(194, 129, 96, 255);
        }
        if (color == 4)
        {
            pielmat.color = new Color32(140, 82, 53, 255);
        }
        if (color == 5)
        {
            pielmat.color = new Color32(110, 61, 36, 255);
        }
        if (color == 6)
        {
            pielmat.color = new Color32(82, 42, 22, 255);
        }
        if (color == 7)
        {
            pielmat.color = new Color32(68, 33, 16, 255);
        }

        if (string.IsNullOrWhiteSpace(nombrepuesto.text))
        {

            textonombre = false;
        }
        else
        {
            textonombre = true;
        }
    }
    

    public void color1()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 1;
        }
        
    }
    public void color2()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 2;
        }
        
    }
    public void color3()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 3;
        }
        
    }
    public void color4()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 4;
        }
        
    }
    public void color5()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 5;
        }
        
    }
    public void color6()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 6;
        }
        

    }
    public void color7()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            color = 7;
        }
        
    }
    public void female()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            if (!mujer)
            {
                players[0].SetActive(false);
              //  spritegeneroui[0].SetActive(false);
                players[1].SetActive(true);
               // spritegeneroui[1].SetActive(true);
                mujer = true;
            }
            else
            {
                players[0].SetActive(true);
               // spritegeneroui[0].SetActive(true);
                players[1].SetActive(false);
               // spritegeneroui[1].SetActive(false);
                mujer = false;
            }
        }
        
        
    }

    public void derecha() {
        if(mujer)
        {
            generoanim.SetTrigger("hombremujer");
        }
        else
        {
            generoanim.SetTrigger("mujerhombre");
        }
        
        
    }
    public void izquierda()
    {
        if (!mujer)
        {
            generoanim.SetTrigger("backmujer");
        }
        else
        {
            generoanim.SetTrigger("backhombre");
        }
    }

    
    public void playclick()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
    }
    public void playanimmirar()
    {
        if (!mujer)
        {
            cambiaropaanim_hombre.SetTrigger("mirarse");
        }
        else { cambiaropaanim_mujer.SetTrigger("mirarse"); }
    }
    

    public void cabelloanim()
    {
        if (!mujer)
        {
            cambiaropaanim_hombre.SetTrigger("miraalrededor");
        }
        else
        {
            cambiaropaanim_mujer.SetTrigger("miraalrededor");
        }
        
    }
   
    public void cabellocolor()
    {
        if (!mujer)
        {
            cambiaropaanim_hombre.SetTrigger("feliz");
        }
        else
        {
            cambiaropaanim_mujer.SetTrigger("feliz");
        }
    }

    public void rotaplayerderecha()
    {

        if (fadescreenscript.faded)
        {
            
            if (rotandoder) { rotandoder = false; }
            else { rotandoder = true; }
        }
        
       
    }
    public void rotaplayerizquierda()
    {
        if (fadescreenscript.faded)
        {
            
            if (rotandoizq) { rotandoizq = false; }
            else { rotandoizq = true; }
        }
        
    }

}
