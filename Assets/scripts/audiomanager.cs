using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{

    [SerializeField] private AudioClip[] audios;
    private AudioSource sonidos;

    private void Start()
    {
        sonidos = GetComponent<AudioSource>();
    }
    public void selectaudio(int indice, float volumen)
    {
        sonidos.PlayOneShot(audios[indice], volumen);
    }
}
