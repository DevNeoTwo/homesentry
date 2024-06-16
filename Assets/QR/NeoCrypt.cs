using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public class NeoCrypt : MonoBehaviour {

    public static NeoCrypt instance;

    [SerializeField] private string key;
    [SerializeField] private string iv;
    private Aes aes;

    private void Awake() {
        instance = this;
    }

    void Start() {
        aes = Aes.Create();
        aes.KeySize = 256;
        aes.Key = ASCIIEncoding.ASCII.GetBytes(key);
        aes.IV = ASCIIEncoding.ASCII.GetBytes(iv);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
    }

    public string Encriptar(string text) {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        var encryptor = aes.CreateEncryptor();
        var encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
        return Convert.ToBase64String(encryptedBytes);
    }

    public string Desencriptar(string text) {
        try {
            byte[] txtByteData = Convert.FromBase64String(text);
            var decryptor = aes.CreateDecryptor();
            var result = decryptor.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
            return ASCIIEncoding.ASCII.GetString(result);
        } catch {
            return "";
        }
    }
}
