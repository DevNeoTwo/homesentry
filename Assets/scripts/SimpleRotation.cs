using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour {

    [SerializeField] private Vector3 speed;

    void Start() {
        
    }

    void Update() {
        this.transform.Rotate(speed * Time.deltaTime, Space.World);
    }
}
