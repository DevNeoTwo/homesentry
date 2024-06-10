using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductsDB : MonoBehaviour {

    public static ProductsDB instance;

    public Product[] products = new Product[0];

    private void Awake() {
        instance = this;
    }

    void Start() { }

    void Update() { }
}

[System.Serializable]
public class Product {
    public string pName;
    public Sprite img;
    public GameObject obj;
}