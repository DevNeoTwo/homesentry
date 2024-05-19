using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField] private Animator anim;
    [SerializeField] private float speed;

    [SerializeField] private SpriteRenderer arrowMiniMap;

    void Start() {
        if (HasInputAuthority) {
            CameraFollow.instance.SetTarget(this.transform);
            CameraMiniMap.instance.SetTarget(this.transform);
            arrowMiniMap.color = Color.green;
        } else
            arrowMiniMap.color = Color.red;
    }

    void Update() { }

    public override void FixedUpdateNetwork() {
        if (!HasInputAuthority) return;

        bool run = true;
        if (Input.GetKey(KeyCode.LeftShift))
            run = true;
        anim.SetBool("run", run);

        //translation
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0, 0, run ? speed * Runner.DeltaTime * 2 : speed * Runner.DeltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0, 0, run ? -speed * Runner.DeltaTime * 2 : -speed * Runner.DeltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(run ? -speed * Runner.DeltaTime * 2 : -speed * Runner.DeltaTime, 0, 0, Space.World);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(run ? speed * Runner.DeltaTime * 2 : speed * Runner.DeltaTime, 0, 0, Space.World);
        //rotation
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            this.transform.eulerAngles = new Vector3(0, 315, 0);
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            this.transform.eulerAngles = new Vector3(0, 45, 0);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            this.transform.eulerAngles = new Vector3(0, 225, 0);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            this.transform.eulerAngles = new Vector3(0, 135, 0);
        else if (Input.GetKey(KeyCode.W))
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        else if (Input.GetKey(KeyCode.A))
            this.transform.eulerAngles = new Vector3(0, 270, 0);
        else if (Input.GetKey(KeyCode.S))
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKey(KeyCode.D))
            this.transform.eulerAngles = new Vector3(0, 90, 0);
        //animations
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            anim.SetBool("walk", true);
        } else {
            anim.SetBool("walk", false);
        }
    }
}
