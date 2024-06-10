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

    public bool bussy;
    [SerializeField] private GameObject itemObj;
    public int itemID;

    IEnumerator Start() {
        if (HasInputAuthority) {
            DontDestroyOnLoad(this.gameObject);
            yield return new WaitForSeconds(1);
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1) Spawner.instance.owner = true;
            else Spawner.instance.owner = false;

            //Debug.Log(Spawner.instance.owner + " - " + GameObject.FindGameObjectsWithTag("Player").Length);
            while(GameManager.instance == null)
                yield return new WaitForSeconds(0.1f);

            if (HasInputAuthority) {
                CameraFollow.instance.SetTarget(this.transform);
                CameraMiniMap.instance.SetTarget(this.transform);
                arrowMiniMap.color = playerColor;
            } else
                arrowMiniMap.color = enemyColor;
            yield return new WaitForSeconds(1);
            if (Spawner.instance.owner) GameManager.instance.CreateCustomers(20);
            if (PlayerPrefs.GetString("gamemode") == "vs") {
                while (GameObject.FindGameObjectsWithTag("Player").Length != 2)
                    yield return new WaitForSeconds(0.25f);
                UIManager.instance.CloseLoading(true);
            } else
                UIManager.instance.CloseLoading(false);

            yield return new WaitForSeconds(1);

            if (Spawner.instance.owner) StartCoroutine(GameManager.instance.SetTimer());
            started = true;
        }
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

    public void TakeItem(int id) {
        itemID = id;
        anim.SetBool("box", true);
        itemObj.SetActive(true);
        AudioManager.instance.PlayRecogerCaja();
    }

    public void LeaveItem() {
        itemID = 0;
        bussy = false;
        anim.SetBool("box", false);
        itemObj.SetActive(false);
        AudioManager.instance.PlayEntregarCaja();
    }
}
