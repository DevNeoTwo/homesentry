using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField] private TMP_Text pointsTx;
    [SerializeField] private int points;
    [SerializeField] private TMP_Text timeTx;
    [SerializeField] private int gameTime;

    private void Awake() {
        instance = this;
    }

    void Start() {
        StartCoroutine(SetTimer());
    }

    void Update() {
        
    }

    IEnumerator SetTimer() {
        while (true) {
            yield return new WaitForSeconds(1);
            gameTime--;
            timeTx.text = gameTime.ToString();
        }
    }

    public void AddPoints(int poi) {
        points += poi;
        pointsTx.text = points.ToString();
    }
}
