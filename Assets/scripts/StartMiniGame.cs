using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class StartMiniGame : MonoBehaviour {

    [SerializeField] private GameObject miniGame;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (other.GetComponent<NetworkObject>().HasStateAuthority == Spawner.instance.localPlayer) {
                StartCoroutine(MiniGame());
            }
        }
    }

    IEnumerator MiniGame() {
        this.GetComponent<Collider>().enabled = false;
        UIManager.instance.HideUI();
        miniGame.SetActive(true);
        cajasspawn.instance.Restart();
        yield return new WaitForSeconds(15);
        audiomanager.instance.selectaudio(5, 1);
        yield return new WaitForSeconds(1);
        audiomanager.instance.selectaudio(5, 1);
        yield return new WaitForSeconds(1);
        audiomanager.instance.selectaudio(5, 1);
        yield return new WaitForSeconds(1);
        audiomanager.instance.selectaudio(5, 1);
        yield return new WaitForSeconds(1);
        audiomanager.instance.selectaudio(5, 1);
        yield return new WaitForSeconds(1);
        miniGame.SetActive(false);
        UIManager.instance.ShowUI();
        GameManager.instance.AddPoints(cajasspawn.instance.puntos);
        this.gameObject.SetActive(false);
    }
}
