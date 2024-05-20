using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    void Start() {
        
    }

    void LateUpdate() {
        this.transform.LookAt(Camera.main.transform.position);
        this.transform.eulerAngles = new Vector3(-1 * this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.eulerAngles += new Vector3(0, 180, 0);
    }
}
