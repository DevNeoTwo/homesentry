using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow instance;

    private Transform target;

    private Vector3 offset;

    private void Awake() {
        instance = this;
    }

    void Start() {
        offset = this.transform.position;
    }

    void LateUpdate() {
        if(target != null)
            this.transform.position = target.position + offset;
    }

    public void SetTarget(Transform tar) {
        target = tar;
    }
}
