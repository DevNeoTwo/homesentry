using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    [SerializeField] private AudioSource source;

    void Start() { }

    void Update() { }

    private void OnTriggerEnter(Collider other) {
        source.pitch = Random.Range(0.85f, 1.15f);
        source.Play();
    }
}
