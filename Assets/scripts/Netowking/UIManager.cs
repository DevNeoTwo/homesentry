using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField] private GameObject UIWin;

    [SerializeField] private Image playerImage;
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private GameObject timeBarWin;
    [SerializeField] private Image timeBar;
    [SerializeField] private Image imageBar;

    [SerializeField] private TMP_Text pointsTx;
    [SerializeField] private TMP_Text timeTx;

    [SerializeField] private GameObject loadingWin;
    [SerializeField] private TMP_Text loadingTx;

    [Header("Tutorial")]
    private int tutorialPos;
    [SerializeField] private GameObject tutorialWin;
    [SerializeField] private GameObject[] tutorialSteps = new GameObject[0];
    [SerializeField] private GameObject prevTutorialBt;
    [SerializeField] private GameObject nextTutorialBt;

    [Header("WinScreen")]
    [SerializeField] private GameObject winScreenWin;
    [SerializeField] private TMP_Text name1Tx;
    [SerializeField] private TMP_Text name2Tx;
    [SerializeField] private TMP_Text points1Tx;
    [SerializeField] private TMP_Text points2Tx;
    [SerializeField] private TMP_Text timeFinalTx;
    [SerializeField] private Image playerFinalImg;
    [SerializeField] private Image qr;


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

    public void SetPoints(string p) {
        pointsTx.text = p;
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

    public void ShowTimeBar(bool show, int id) {
        imageBar.sprite = ProductsDB.instance.products[id].img;
        timeBarWin.SetActive(show);
    }

    public void SetTimeBar(float aux) {
        timeBar.fillAmount = aux;
    }

    public float GetTimeBar() {
        return timeBar.fillAmount;
    }

    //Tutorial
    public void CloseTutorial() {
        tutorialWin.SetActive(false);
        ShowUI();
        CameraFollow.instance.CloseTutorial();
        Spawner.instance.localPlayer.RPC_SetStatus("ready");
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


    public void ShowWinScreen() {
        string ptos = GameManager.instance.totalPoints.ToString();
        ptos = string.IsNullOrWhiteSpace(ptos) ? "0" : ptos;

        string aux = PlayerData.instance.genre ? "F," : "M,";
        aux += System.DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + ",";
        aux += PlayerData.instance.playerName + ",";
        aux += ptos;
        qr.sprite = QRGenerator.instance.generateQR(NeoCrypt.instance.Encriptar(aux));

        if (PlayerPrefs.GetString("gamemode") == "vs") {
            bool playerOne = true;
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player")) {
                if (playerOne) {
                    name1Tx.text = p.GetComponent<PlayerMovement>().playerName.ToString();
                    points1Tx.text = p.GetComponent<PlayerMovement>().points.ToString();
                    playerOne = false;
                } else {
                    name2Tx.text = p.GetComponent<PlayerMovement>().playerName.ToString();
                    points2Tx.text = p.GetComponent<PlayerMovement>().points.ToString();
                }
            }
        } else {
            name1Tx.text = PlayerData.instance.playerName;
            name2Tx.text = "";
            points1Tx.text = ptos + " PTOS";
            points2Tx.text = "";
        }
        
        timeFinalTx.text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        playerFinalImg.sprite = PlayerData.instance.playerImage;

        winScreenWin.SetActive(true);
        Spawner.instance.localPlayer.RPC_SetStatus("ended");
    }

    public void Restart() {
        SceneManager.LoadScene("editor");
    }

    public void Menu() {
        SceneManager.LoadScene("mainmenu");
    }
}
