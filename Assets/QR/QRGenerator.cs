using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRGenerator : MonoBehaviour {

    [SerializeField] private Material mat;

    // Start is called before the first frame update
    void Start() {
        Texture2D myQR = generateQR(NeoCrypt.instance.Encriptar("mirando cuantas letras le caben a este pinchi codigo qr espero que muchas porque necesito poner muchas informacion equisdent"));
        mat.mainTexture = myQR;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private static Color32[] Encode(string textForEncoding, int width, int height) {
        var writer = new BarcodeWriter {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text) {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }
}
