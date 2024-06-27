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

    public void ChangeSpawn(int id) {
        for (int i = 1; i < products.Length; i++)
            products[i].spawn.SetActive(false);
        products[id].spawn.SetActive(true);
    }
}

[System.Serializable]
public class Product {
    public string pName;
    public Sprite img;
    public GameObject obj;
    public GameObject spawn;
}