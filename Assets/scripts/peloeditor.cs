using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class peloeditor : MonoBehaviour {

    public static peloeditor instance;

    public Material pelomat;
    public Renderer render;
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] tiposcabelloshombre;
    [SerializeField] GameObject[] tiposcabellosmujer;
    public int colorcabello=1;
    public int estilocabello=1;
    audiomanager audiomanagerscript;
    fadescreen fadescreenscript;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
         render= players[players.Length - 1].GetComponent<Renderer>();
        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript = FindObjectOfType<fadescreen>();
        if (render != null)
        {
            pelomat = render.material;
        }
        
        
    }
    private void FixedUpdate()
    {
        //colores de cabellos ****
        if(colorcabello == 1)
        {
            pelomat.color = new Color32(0,0,0,255);
        }
        if(colorcabello == 2) 
        {
            pelomat.color = new Color32(211, 211, 211, 255);
        }
        if (colorcabello == 3)
        {
            pelomat.color = new Color32(69, 37, 0, 255);
        }
        if (colorcabello == 4)
        {
            pelomat.color = new Color32(79, 60, 29, 255);
        }
        if (colorcabello == 5)
        {
            pelomat.color = new Color32(145, 1, 1, 255);
        }
        if (colorcabello == 6)
        {
            pelomat.color = new Color32(213, 153, 0, 255);
        }
        if (colorcabello == 7)
        {
            pelomat.color = new Color32(26, 47, 125, 255);
        }
        if (colorcabello == 8)
        {
            pelomat.color = new Color32(13, 110, 40, 255);
        }
        if (colorcabello == 9)
        {
            pelomat.color = new Color32(0, 107, 107, 255);
        }
        if (colorcabello == 10)
        {
            pelomat.color = new Color32(157, 0, 66, 255);
        }
        if (colorcabello == 11)
        {
            pelomat.color = new Color32(64, 6, 121, 255);
        }
        if (colorcabello == 12)
        {
            pelomat.color = new Color32(78, 0, 90, 255);
        }
        if (colorcabello == 13)
        {
            pelomat.color = new Color32(123, 44, 0, 255);
        }
        if (colorcabello == 14)
        {
            pelomat.color = new Color32(23, 73, 46, 255);
        }
        //***************************//***********************************//*************
        //estilos de cabellos**

        if (estilocabello==1)
        {
            tiposcabelloshombre[0].SetActive(true);
            tiposcabellosmujer[0].SetActive(true);

            tiposcabelloshombre[1].SetActive(false);
            tiposcabelloshombre[2].SetActive(false);
            tiposcabelloshombre[3].SetActive(false);
            tiposcabelloshombre[4].SetActive(false);
            tiposcabelloshombre[5].SetActive(false);
            tiposcabellosmujer[1].SetActive(false);
            tiposcabellosmujer[2].SetActive(false);
            tiposcabellosmujer[3].SetActive(false);
            tiposcabellosmujer[4].SetActive(false);
            tiposcabellosmujer[5].SetActive(false);
        }
        if (estilocabello == 2)
        {
            tiposcabelloshombre[1].SetActive(true);
            tiposcabellosmujer[1].SetActive(true);

            tiposcabelloshombre[0].SetActive(false);
            tiposcabelloshombre[2].SetActive(false);
            tiposcabelloshombre[3].SetActive(false);
            tiposcabelloshombre[4].SetActive(false);
            tiposcabelloshombre[5].SetActive(false);
            tiposcabellosmujer[0].SetActive(false);
            tiposcabellosmujer[2].SetActive(false);
            tiposcabellosmujer[3].SetActive(false);
            tiposcabellosmujer[4].SetActive(false);
            tiposcabellosmujer[5].SetActive(false);
        }
        if (estilocabello == 3)
        {
            tiposcabelloshombre[2].SetActive(true);
            tiposcabellosmujer[2].SetActive(true);

            tiposcabelloshombre[1].SetActive(false);
            tiposcabelloshombre[0].SetActive(false);
            tiposcabelloshombre[3].SetActive(false);
            tiposcabelloshombre[4].SetActive(false);
            tiposcabelloshombre[5].SetActive(false);
            tiposcabellosmujer[1].SetActive(false);
            tiposcabellosmujer[0].SetActive(false);
            tiposcabellosmujer[3].SetActive(false);
            tiposcabellosmujer[4].SetActive(false);
            tiposcabellosmujer[5].SetActive(false);
        }
        if (estilocabello == 4)
        {
            tiposcabelloshombre[3].SetActive(true);
            tiposcabellosmujer[3].SetActive(true);

            tiposcabelloshombre[1].SetActive(false);
            tiposcabelloshombre[2].SetActive(false);
            tiposcabelloshombre[0].SetActive(false);
            tiposcabelloshombre[4].SetActive(false);
            tiposcabelloshombre[5].SetActive(false);
            tiposcabellosmujer[1].SetActive(false);
            tiposcabellosmujer[2].SetActive(false);
            tiposcabellosmujer[0].SetActive(false);
            tiposcabellosmujer[4].SetActive(false);
            tiposcabellosmujer[5].SetActive(false);
        }
        if (estilocabello == 5)
        {
            tiposcabelloshombre[4].SetActive(true);
            tiposcabellosmujer[4].SetActive(true);

            tiposcabelloshombre[1].SetActive(false);
            tiposcabelloshombre[2].SetActive(false);
            tiposcabelloshombre[3].SetActive(false);
            tiposcabelloshombre[0].SetActive(false);
            tiposcabelloshombre[5].SetActive(false);
            tiposcabellosmujer[1].SetActive(false);
            tiposcabellosmujer[2].SetActive(false);
            tiposcabellosmujer[3].SetActive(false);
            tiposcabellosmujer[0].SetActive(false);
            tiposcabellosmujer[5].SetActive(false);
        }
        if (estilocabello == 6)
        {
            tiposcabelloshombre[5].SetActive(true);
            tiposcabellosmujer[5].SetActive(true);

            tiposcabelloshombre[1].SetActive(false);
            tiposcabelloshombre[2].SetActive(false);
            tiposcabelloshombre[3].SetActive(false);
            tiposcabelloshombre[4].SetActive(false);
            tiposcabelloshombre[0].SetActive(false);
            tiposcabellosmujer[1].SetActive(false);
            tiposcabellosmujer[2].SetActive(false);
            tiposcabellosmujer[3].SetActive(false);
            tiposcabellosmujer[4].SetActive(false);
            tiposcabellosmujer[0].SetActive(false);
        }

    }

    //selector colores botones del canvas***

    public void nextcolor()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            colorcabello++;
            if (colorcabello > 14)
            {
                colorcabello = 1;
            }

        }
         
    }

    public void backcolor()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            colorcabello--;
            if (colorcabello < 1)
            {
                colorcabello = 14;
            }
        }
        
    }

    /*
    public void color1()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 1;
    }
    public void color2()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 2;
    }
    public void color3()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 3;
    }
    public void color4()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 4;
    }
    public void color5()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 5;
    }
    public void color6()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 6;

    }
    public void color7()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 7;
    }
    public void color8()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 8;
    }
    public void color9()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 9;
    }
    public void color10()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 10;
    }
    public void color11()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 11;
    }
    public void color12()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 12;
    }
    public void color13()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 13;
    }
    public void color14()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        colorcabello = 14;
    }*/
    //****************//*********************//***********

    public void nextcabello() {

        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            estilocabello++;
            if (estilocabello > 6)
            {
                estilocabello = 1;
            }

        }
         
    }
    public void previouscabello()
    {
        if (fadescreenscript.faded)
        {
            audiomanagerscript.selectaudio(0, 0.7f);
            estilocabello--;
            if (estilocabello < 1)
            {
                estilocabello = 6;
            }
        }
        
    }
}
