using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;

public class QRReader : MonoBehaviour{

    private WebCamTexture camTexture;
    [SerializeField] private Renderer render;

    [SerializeField] private TMP_Text hora;
    [SerializeField] private TMP_Text bateryPer;
    [SerializeField] private Image bateryBar;

    private bool alreadyRead;

    [SerializeField] private GameObject errorMessage;

    [SerializeField] private GameObject resultWin;
    [SerializeField] private Image playerImg;
    [SerializeField] private TMP_Text nameTx;
    [SerializeField] private TMP_Text pointsTx;
    [SerializeField] private TMP_Text timeTx;

    [SerializeField] private Sprite male;
    [SerializeField] private Sprite female;

    private bool showingError;
    void Start() {
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        render.material.mainTexture = camTexture;
        if (camTexture != null) {
            camTexture.Play();
        }
        Debug.Log("started");
    }

    void Update() {
        hora.text = System.DateTime.Now.ToString("hh:mm tt");
        bateryBar.fillAmount = SystemInfo.batteryLevel;
        bateryPer.text = (int)(SystemInfo.batteryLevel * 100) + "%";

        if (alreadyRead) return;

        Debug.Log("reading");

        try {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
            if (result != null) {

                
                string decripted = NeoCrypt.instance.Desencriptar(result.Text);

                Debug.Log(decripted);

                playerImg.sprite = decripted.Split(",")[0] == "M" ? male : female;
                timeTx.text = decripted.Split(",")[1];
                nameTx.text = decripted.Split(",")[2];
                pointsTx.text = decripted.Split(",")[3];

                resultWin.SetActive(true);

                alreadyRead = true;
            }
        } catch {
            if (!showingError)
                StartCoroutine(ShowError());
        }
    }

    public void Rescan() {
        resultWin.SetActive(false);
        alreadyRead = false;
    }

    IEnumerator ShowError() {
        showingError = true;
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
        showingError = false;
    }
}
