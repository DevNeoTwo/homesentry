using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField] private Animator anim;
    [SerializeField] private float speed;

    [SerializeField] private SpriteRenderer arrowMiniMap;
    [SerializeField] private Color playerColor;
    [SerializeField] private Color enemyColor;

    [SerializeField] private Rigidbody rb;

    private bool started;

    IEnumerator Start() {
        DontDestroyOnLoad(this.gameObject);
        yield return new WaitForSeconds(5);
        if (HasInputAuthority) {
            CameraFollow.instance.SetTarget(this.transform);
            CameraMiniMap.instance.SetTarget(this.transform);
            arrowMiniMap.color = playerColor;
        } else
            arrowMiniMap.color = enemyColor;
        yield return new WaitForSeconds(1);
        GameManager.instance.CreateCustomers();
        if (PlayerPrefs.GetString("GameMode") == "vs") {
            while (GameObject.FindGameObjectsWithTag("Player").Length < 2)
                yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(1);
        started = true;
    }

    void Update() { }

    public override void FixedUpdateNetwork() {
        if (!HasInputAuthority) return;
        if (!started) return;

        Vector3 vel = new Vector3(0, -300 * Runner.DeltaTime, 0);

        //translation
        if (Input.GetKey(KeyCode.W))
            vel.z = speed * Runner.DeltaTime;
        if (Input.GetKey(KeyCode.S))
            vel.z = -speed * Runner.DeltaTime;
        if (Input.GetKey(KeyCode.A))
            vel.x = -speed * Runner.DeltaTime;
        if (Input.GetKey(KeyCode.D))
            vel.x = speed * Runner.DeltaTime;
        rb.velocity = vel;

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
            anim.SetBool("run", true);
        } else {
            anim.SetBool("run", false);
        }
    }
}
