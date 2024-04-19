using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField] private Animator anim;

    void Start() {
        
    }

    void Update() {
        
    }

    public override void FixedUpdateNetwork() {
        if (!HasInputAuthority) return;
        if (Input.GetKey(KeyCode.W)) {
            this.transform.Translate(0, 0, 3 * Runner.DeltaTime, Space.World);
            this.transform.eulerAngles = new Vector3(0,0,0);
        }
        if (Input.GetKey(KeyCode.S)) {
            this.transform.Translate(0, 0, -3 * Runner.DeltaTime, Space.World);
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            this.transform.Translate(-3 * Runner.DeltaTime, 0, 0, Space.World);
            this.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            this.transform.Translate(3 * Runner.DeltaTime, 0, 0, Space.World);
            this.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        //animations
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            anim.SetBool("walk", true);
        } else {
            anim.SetBool("walk", false);
        }
    }
}
