using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField] private GameObject UIWin;

    [SerializeField] private Image playerImage;
    [SerializeField] private TMP_Text playerName;

    [SerializeField] private TMP_Text pointsTx;
    [SerializeField] private int points;
    [SerializeField] private TMP_Text timeTx;

    [SerializeField] private GameObject loadingWin;
    [SerializeField] private TMP_Text loadingTx;

    private int tutorialPos;
    [SerializeField] private GameObject tutorialWin;
    [SerializeField] private GameObject[] tutorialSteps = new GameObject[0];
    [SerializeField] private GameObject prevTutorialBt;
    [SerializeField] private GameObject nextTutorialBt;

    private void Awake() {
        instance = this;
    }

    void Start() {
        playerImage.sprite = PlayerData.instance.playerImage;
        playerName.text = PlayerData.instance.playerName;
    }

    void Update() {

    }

    public void SetTime(string t) {
        timeTx.text = t;
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

    public void ShowUI() {
        UIWin.SetActive(true);
        CameraMiniMap.instance.GetComponent<Camera>().enabled = true;
    }

    public void HideUI() {
        UIWin.SetActive(false);
        CameraMiniMap.instance.GetComponent<Camera>().enabled = false;
    }

    //Tutorial
    public void CloseTutorial() {
        tutorialWin.SetActive(false);
        ShowUI();
        CameraFollow.instance.CloseTutorial();
    }

    public void NextTutorial() {
        if (tutorialPos <= tutorialSteps.Length)
            tutorialPos++;
        if (tutorialPos == tutorialSteps.Length)
            CloseTutorial();
        else
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

        prevTutorialBt.SetActive(tutorialPos != 0);
    }
}
