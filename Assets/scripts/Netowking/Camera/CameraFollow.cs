using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow instance;

    private Transform target;
    [SerializeField] private Vector3 fixedRotation;

    private Vector3 offset;
    private bool showStore = true;
    [SerializeField] private Transform[] storePositions = new Transform[0];
    private float tShow;

    private void Awake() {
        instance = this;
    }

    void Start() {
        offset = this.transform.position;
        tShow = Time.time;
    }

    void LateUpdate() {
        if (showStore) {
            if (Time.time > tShow + 5) {
                this.transform.position = storePositions[Random.Range(0, storePositions.Length)].position;
                tShow = Time.time;
            }
            this.transform.Rotate(0, 5 * Time.deltaTime, 0, Space.World);
            return;
        }
        if (target != null) {
            this.transform.eulerAngles = fixedRotation;
            this.transform.position = target.position + offset;
        }
    }

    public void SetTarget(Transform tar) {
        target = tar;
    }

    public void CloseTutorial() {
        showStore = false;
        this.transform.position = offset;
        this.transform.eulerAngles = fixedRotation;
    }
}
