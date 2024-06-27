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
    private bool ended;

    //public bool bussy;
    [SerializeField] private GameObject itemObj;
    private GameObject currentObj;
    public int itemID;

    private bool hat;
    private bool chain;
    [SerializeField] private GameObject hatObj;
    [SerializeField] private GameObject chainObj;
    [SerializeField] private ParticleSystem hatParticles;
    [SerializeField] private ParticleSystem chainParticles;
    private float tDress;
    private float tDressDelay;

    [Networked(OnChanged = nameof(ChangeStatus))] public NetworkString<_8> status { get; set; }

    [Networked(OnChanged = nameof(ChangePoints))] public NetworkString<_16> points { get; set; }
    [Networked(OnChanged = nameof(ChangeName))] public NetworkString<_32> playerName { get; set; }

    [Networked(OnChanged = nameof(ChangeBussy))] public NetworkString<_2> bussy { get; set; }

    private float tBusy;

    IEnumerator Start() {
        if (HasInputAuthority) {
            Spawner.instance.localPlayer = this;
            DontDestroyOnLoad(this.gameObject);
            yield return new WaitForSeconds(1);
            RPC_SetName(PlayerData.instance.playerName);
            RPC_SetPoints("0");
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1) Spawner.instance.owner = true;
            else Spawner.instance.owner = false;

            //Debug.Log(Spawner.instance.owner + " - " + GameObject.FindGameObjectsWithTag("Player").Length);
            while(GameManager.instance == null)
                yield return new WaitForSeconds(0.1f);


            CameraFollow.instance.SetTarget(this.transform);
            CameraMiniMap.instance.SetTarget(this.transform);
            arrowMiniMap.color = playerColor;

            yield return new WaitForSeconds(1);

            if (Spawner.instance.owner) GameManager.instance.CreateCustomers(20);

            if (PlayerPrefs.GetString("gamemode") == "vs") {
                while (GameObject.FindGameObjectsWithTag("Player").Length != 2)
                    yield return new WaitForSeconds(0.25f);
                UIManager.instance.CloseLoading(true);
            } else
                UIManager.instance.CloseLoading(false);

            if (PlayerPrefs.GetString("gamemode") == "vs") {
                int aux = 0;
                do {
                    aux = 0;
                    foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player")) {
                        if (p.GetComponent<PlayerMovement>().status.ToString() == "ready")
                            aux++;
                    }
                    yield return new WaitForSeconds(0.1f);
                } while (aux != 2);
            } else {
                while(Spawner.instance.localPlayer.status != "ready")
                    yield return new WaitForSeconds(0.1f);
            }
            

            if (Spawner.instance.owner) StartCoroutine(GameManager.instance.SetTimer());
            tDress = Time.time;
            tDressDelay = Random.Range(20f, 60f);
            started = true;
        } else
            arrowMiniMap.color = enemyColor;
    }

    void Update() {
        itemObj.SetActive(anim.GetBool("box"));

        if (!HasInputAuthority) return;

        if (started && Time.time > tDress + tDressDelay) {
            if (Random.Range(0, 2) == 0) {
                hatObj.SetActive(true);
                Color c = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1);
                hatObj.GetComponent<MeshRenderer>().material.color = c;
                hatParticles.startColor = c;
                hatParticles.Play();
                hat = true;
            } else {
                chainObj.SetActive(true);
                chainParticles.Play();
                chain = true;
            }
            tDressDelay = Random.Range(20f, 60f);
            tDress = Time.time;
        }
        if (bussy.ToString() == "T") {
            float aux = (Time.time - tBusy) / 100;
            if (aux < 0) aux = 0;
            if (aux > 1) aux = 1;
            UIManager.instance.SetTimeBar(1 - aux);
        }
    }

    public override void FixedUpdateNetwork() {
        if (!HasInputAuthority) return;
        if (!started || ended) return;

        Vector3 vel = new Vector3(0, 0, 0);

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

    public void OnMouseDown() {
        if (!HasInputAuthority) return;
        if (hat) {
            hatObj.SetActive(false);
            hatParticles.Play();
            hat = false;
            GameManager.instance.AddPoints(200);
        }
        if (chain) {
            chainObj.SetActive(false);
            chainParticles.Play();
            chain = false;
            GameManager.instance.AddPoints(200);
        }
    }

    public void TakeItem(int id) {
        if (!HasInputAuthority) return;
        itemID = id;
        if (currentObj != null) Destroy(currentObj);
        currentObj = Instantiate(ProductsDB.instance.products[itemID].obj, itemObj.transform.position, Quaternion.identity);
        currentObj.transform.parent = itemObj.transform;
        anim.SetBool("box", true);
        itemObj.SetActive(true);
        AudioManager.instance.PlayRecogerCaja();
    }

    public void LeaveItem() {
        if (!HasInputAuthority) return;
        itemID = 0;
        if (currentObj != null) Destroy(currentObj);
        RPC_SetBussy("F");
        anim.SetBool("box", false);
        itemObj.SetActive(false);
        AudioManager.instance.PlayEntregarCaja();
        UIManager.instance.ShowTimeBar(false, 0);
        int aux = (int)(200f * UIManager.instance.GetTimeBar());
        GameManager.instance.AddPoints(200 + aux);
    }

    public void SetBussy(int id) {
        if (!HasInputAuthority) return;
        RPC_SetBussy("T");
        tBusy = Time.time;
        UIManager.instance.SetTimeBar(1);
        UIManager.instance.ShowTimeBar(true, id);
    }


    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetStatus(string s, RpcInfo rpcInfo = default) {
        if (HasInputAuthority)
            this.status = s;
    }

    static void ChangeStatus(Changed<PlayerMovement> changed) {
        changed.Behaviour.ChangeStatus();
    }

    private void ChangeStatus() {
        if (status.ToString() == "ended") {
            ended = true;
            Runner.Despawn(Spawner.instance.localPlayer.GetComponent<NetworkObject>());
            Destroy(PlayerData.instance.gameObject);
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
                Destroy(p);
        }   
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetPoints(string p, RpcInfo rpcInfo = default) {
        if (HasInputAuthority)
            this.points = p;
    }

    static void ChangePoints(Changed<PlayerMovement> changed) {
        changed.Behaviour.ChangePoints();
    }

    private void ChangePoints() {

    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetName(string n, RpcInfo rpcInfo = default) {
        if (HasInputAuthority)
            this.playerName = n;
    }

    static void ChangeName(Changed<PlayerMovement> changed) {
        changed.Behaviour.ChangeName();
    }

    private void ChangeName() {

    }


    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetBussy(string b, RpcInfo rpcInfo = default) {
        if (HasInputAuthority)
            this.bussy = b;
    }

    static void ChangeBussy(Changed<PlayerMovement> changed) {
        changed.Behaviour.ChangeBussy();
    }

    private void ChangeBussy() {

    }
}
