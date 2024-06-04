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

    [SerializeField] private GameObject loadingWin;
    [SerializeField] private TMP_Text loadingTx;

    private int tutorialPos;
    [SerializeField] private GameObject[] tutorialSteps = new GameObject[0];
    [SerializeField] private GameObject prevTutorialBt;
    [SerializeField] private GameObject nextTutorialBt;

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

    public void CloseLoading(bool vs) {
        StartCoroutine(ClosingLoading(vs));
    }

    IEnumerator ClosingLoading(bool vs) {
        loadingTx.text = "Contrincante encontrado";
        yield return new WaitForSeconds(vs ? 1 : 0);
        loadingWin.SetActive(false);
    }

    //Tutorial
    public void CloseTutorial() {

    }

    public void NextTutorial() {
        if (tutorialPos < tutorialSteps.Length)
            tutorialPos++;
        SetStepTutorial();
    }

    public void PrevTutorial() {
        if (tutorialPos > 0)
            tutorialPos--;
        SetStepTutorial();
    }

    public void SetStepTutorial() {
        for (int i = 0; i < tutorialSteps.Length; i++)
            tutorialSteps[i].SetActive(false);
        tutorialSteps[tutorialPos].SetActive(true);

        nextTutorialBt.SetActive(true);
        prevTutorialBt.SetActive(true);

        if (tutorialPos == 0) prevTutorialBt.SetActive(false);
        if (tutorialPos == tutorialSteps.Length - 1) nextTutorialBt.SetActive(false);
    }
}
