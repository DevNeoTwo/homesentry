using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow instance;

    private Transform target;
    [SerializeField] private Vector3 fixedRotation;

    private Vector3 offset;

    private void Awake() {
        instance = this;
    }

    void Start() {
        offset = this.transform.position;
    }

    void LateUpdate() {
        if (target != null) {
            this.transform.eulerAngles = fixedRotation;
            this.transform.position = target.position + offset;
        } else
            this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, fixedRotation, 3f * Time.deltaTime);
    }

    public void SetTarget(Transform tar) {
        target = tar;
    }
}
