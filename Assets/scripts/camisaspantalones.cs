using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camisaspantalones : MonoBehaviour {

    public static camisaspantalones instance;

    [SerializeField] Material[] camisamaterials;
    [SerializeField] Material[] pantalonmaterials;

    [SerializeField] Texture[] hombrecamisatexture;
    [SerializeField] Texture[] hombrepanttexture;

    [SerializeField] Texture[] mujercamisatexture;
    [SerializeField] Texture[] mujerpanttexture;

    public int top = 1;
    public int bottom = 1;

    audiomanager audiomanagerscript;
    fadescreen fadescreenscript;

    [SerializeField] Animator pantanim;
    [SerializeField] Animator camisanim;

    //nombre script+instance
    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[0]);
        pantalonmaterials[0].SetTexture("_MainTex", hombrepanttexture[0]);

        camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[0]);
        pantalonmaterials[1].SetTexture("_MainTex", mujerpanttexture[0]);

        audiomanagerscript = FindObjectOfType<audiomanager>();
        fadescreenscript = FindObjectOfType<fadescreen>();
    }
    private void FixedUpdate()
    {
        if (fadescreenscript.faded)
        {
            if (top == 1)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[0]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[0]);
            }
            if (bottom == 1)
            {
                pantalonmaterials[0].SetTexture("_MainTex", hombrepanttexture[0]);
                pantalonmaterials[1].SetTexture("_MainTex", mujerpanttexture[0]);
            }

            if (top == 2)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[1]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[1]);
            }
            if (bottom == 2)
            {
                pantalonmaterials[0].SetTexture("_MainTex", hombrepanttexture[1]);
                pantalonmaterials[1].SetTexture("_MainTex", mujerpanttexture[1]);
            }

            if (top == 3)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[2]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[2]);
            }
            if (bottom == 3)
            {
                pantalonmaterials[0].SetTexture("_MainTex", hombrepanttexture[2]);
                pantalonmaterials[1].SetTexture("_MainTex", mujerpanttexture[2]);
            }

            if (top == 4)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[3]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[3]);
            }
            

            if (top == 5)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[4]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[4]);
            }
            if (top == 6)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[5]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[5]);
            }
            if (top == 7)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[6]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[6]);
            }
            if (top == 8)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[7]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[7]);
            }
            if (top == 9)
            {
                camisamaterials[0].SetTexture("_MainTex", hombrecamisatexture[8]);
                camisamaterials[1].SetTexture("_MainTex", mujercamisatexture[8]);
            }
        }
           

    }
    public void nexttop()
    {
        if (fadescreenscript.faded)
        {
            camisanim.SetTrigger("animder");
            top++;
            audiomanagerscript.selectaudio(0, 0.7f);
            if (top > 9)
            {
                top = 1;
            }
        }
        
    }
    public void backtop()
    {
        if (fadescreenscript.faded)
        {
            camisanim.SetTrigger("animizq");
            top--;
            audiomanagerscript.selectaudio(0, 0.7f);
            if (top < 1)
            {
                top = 9;
            }
        }
        
    }
    public void nextbottom()
    {
        if (fadescreenscript.faded)
        {
            pantanim.SetTrigger("animder");
            bottom++;
            audiomanagerscript.selectaudio(0, 0.7f);
            if (bottom > 3)
            {
                bottom = 1;
            }
        }

        
    }

    public void backbottom()
    {
        if (fadescreenscript.faded)
        {
            pantanim.SetTrigger("animizq");
            bottom--;
            audiomanagerscript.selectaudio(0, 0.7f);
            if (bottom < 1)
            {
                bottom = 3;
            }
        }
        
    }
}
