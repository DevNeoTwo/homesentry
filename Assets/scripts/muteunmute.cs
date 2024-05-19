using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteunmute : MonoBehaviour
{
    Sprite soundonmusic;
    Sprite soundonfx;
    [SerializeField]Sprite soundoffmusic;
    [SerializeField] Sprite soundofffx;
    [SerializeField] Button botonmusic;
    [SerializeField] Button botonfx;
    public bool muteadomusic=false;
    public bool muteadofx = false;
    [SerializeField] AudioSource musica;
    [SerializeField]AudioSource soundfx;

    public static int mutemusic=0;
    public static int mutefx=1;

    

    private void Start()
    {
        soundonmusic = botonmusic.image.sprite;
        musica.volume = 0;
        botonmusic.image.sprite=soundoffmusic;
        soundonfx = botonfx.image.sprite;

        

        if (mutemusic == 0)
        {
            muteadomusic = false;
        }
        else
        {
            muteadomusic = true;
        }

        if(mutefx == 0)
        {
            muteadofx=false;
        }
        else 
        { 
            
            muteadofx=true;
        }


        if (!muteadomusic)
        {
            mutemusic = 0;
        }
        else
        {
            mutemusic = 1;
        }

        if (!muteadofx)
        {
            mutefx=0;
        }
        else
        {

            mutefx = 1;
        }
        Debug.Log(mutefx);
    }
    public void mutearmusic()
    {
        if (muteadomusic)
        {
            botonmusic.image.sprite = soundoffmusic;
            muteadomusic = false;
           
            musica.volume = 0;
            mutemusic = 0;
        }
        else
        {
            botonmusic.image.sprite=soundonmusic;
            muteadomusic = true;
            
            musica.volume = 0.2f;
            mutemusic = 1;
        }
    }
    public void mutearfx()
    {
        if (muteadofx)
        {
            botonfx.image.sprite = soundofffx;
            muteadofx = false;
            
            soundfx.volume = 0;
            mutefx = 0;
        }
        else
        {
            botonfx.image.sprite = soundonfx;
            muteadofx = true;
            
            soundfx.volume = 0.7f;
            mutefx = 1;
        }
    }
}
//AudioListener.volume = 1;