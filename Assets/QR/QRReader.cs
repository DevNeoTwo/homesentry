using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRReader : MonoBehaviour{

    private WebCamTexture camTexture;
    private Rect screenRect;


    void Start() {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null) {
            camTexture.Play();
        }
    }

    void Update() {
        
    }

    void OnGUI() {
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
        try {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
            if (result != null) {
                Debug.Log(result.Text); 
                Debug.Log("DECODED TEXT FROM QR:  " + NeoCrypt.instance.Desencriptar(result.Text));
            }
        } catch {}
    }
}
