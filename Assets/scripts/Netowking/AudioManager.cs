using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

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
        cajaRegistradora.pitch = Random.Range(0.85f, 1.15f);
        cajaRegistradora.Play();
    }

    public void PlayRecogerCaja() {
        recogerCaja.pitch = Random.Range(0.85f, 1.15f);
        recogerCaja.Play();
    }

    public void PlayEntregarCaja() {
        entregarCaja.pitch = Random.Range(0.85f, 1.15f);
        entregarCaja.Play();
    }

    public void PlayPortal() {
        portal.pitch = Random.Range(0.85f, 1.15f);
        portal.Play();
    }
}
