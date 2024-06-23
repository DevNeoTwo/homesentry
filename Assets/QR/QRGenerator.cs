using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;

public class QRGenerator : MonoBehaviour {

    public static QRGenerator instance;

    private void Awake() {
        instance = this;
    }

    void Start() { }

    void Update() { }

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

    public Sprite generateQR(string text) {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return Sprite.Create(encoded, new Rect(0, 0, encoded.width, encoded.height), new Vector2(0.5f, 0.5f)); ;
    }
}
