using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField] private audiomanager audiomanager;

    [SerializeField] private AudioSource cajaRegistradora;
    [SerializeField] private AudioSource recogerCaja;
    [SerializeField] private AudioSource entregarCaja;
    [SerializeField] private AudioSource portal;

    private void Awake() {
        instance = this;
    }

    void Start() { }

    void Update() { }

    public void PlayCajaRegistradora() {
        audiomanager.selectaudio(0, 1);
    }

    public void PlayRecogerCaja() {
        audiomanager.selectaudio(1, 1);
    }

    public void PlayEntregarCaja() {
        audiomanager.selectaudio(2, 1);
    }

    public void PlayPortal() {
        audiomanager.selectaudio(4, 1);
    }
}
