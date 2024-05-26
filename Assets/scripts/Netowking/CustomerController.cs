using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class CustomerController : NetworkBehaviour {

    [Networked(OnChanged = nameof(ChangeColor))] public NetworkString<_32> charColor { get; set; }

    [Networked(OnChanged = nameof(ChangeProduct))] public NetworkString<_32> product { get; set; }

    [SerializeField] private GameObject[] hairStyles = new GameObject[0];
    [SerializeField] private Color[] hairColors = new Color[0];
    [SerializeField] private Renderer bodyRender;
    [SerializeField] private Color[] bodyColors = new Color[0];
    [SerializeField] private Color[] shirtsColors = new Color[0];
    [SerializeField] private Color[] pantsColors = new Color[0];

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent nav;
    private bool walking;
    private float tState;
    private float tDelay;
    private Vector3 target;

    [SerializeField] private GameObject canvas;
    [SerializeField] private Image productImg;
    [SerializeField] private TMP_Text productTx;
    [SerializeField] private SpriteRenderer arrowImg;
    [SerializeField] private Sprite arrowIcon;
    [SerializeField] private Sprite starIcon;

    void Start() {
        if (!Spawner.instance.owner) return;

        target = this.transform.position;
        tState = Time.time;
        tDelay = Random.Range(2f, 7f);

        string aux = "";
        aux += Random.Range(0, 6) + ",";//skin color
        aux += Random.Range(0, 6) + ",";//hair style
        aux += Random.Range(0, 9) + ",";//hair color
        aux += Random.Range(0, 9) + ",";//shirt color
        aux += Random.Range(0, 9);//pants color
        RPC_SetColor(aux);
        RPC_SetProduct(Random.Range(0,2).ToString());
        this.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public override void FixedUpdateNetwork() {
        if (!Spawner.instance.owner) return;
        if (walking) {
            if (Vector3.Distance(this.transform.position, target) < 1) {
                walking = false;
                nav.isStopped = true;
                tState = Time.time;
                tDelay = Random.Range(5f, 20f);
                anim.SetBool("run", false);
            }
        } else {
            if (Time.time > tState + tDelay) {
                nav.enabled = true;
                walking = true;
                nav.isStopped = false;
                target = GameManager.instance.GetDestination();
                nav.SetDestination(target);
                anim.SetBool("run", true);
            }
        }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_SetColor(string color, RpcInfo rpcInfo = default) {
        this.charColor = color;
    }

    static void ChangeColor(Changed<CustomerController> changed) {
        changed.Behaviour.ChangeColor();
    }

    private void ChangeColor() {
        int skinColor = 0;
        int hairStyle = 0;
        int hairColor = 0;
        int shirt = 0;
        int pant = 0;
        try {
            skinColor = int.Parse(charColor.ToString().Split(",")[0]);
            hairStyle = int.Parse(charColor.ToString().Split(",")[1]);
            hairColor = int.Parse(charColor.ToString().Split(",")[2]);
            shirt = int.Parse(charColor.ToString().Split(",")[3]);
            pant = int.Parse(charColor.ToString().Split(",")[4]);
        } catch { }
        bodyRender.materials[0].color = bodyColors[skinColor];
        hairStyles[hairStyle].SetActive(true);
        hairStyles[hairStyle].GetComponent<Renderer>().material.color = hairColors[hairColor];
        bodyRender.materials[1].color = shirtsColors[shirt];
        bodyRender.materials[2].color = pantsColors[pant];
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_SetProduct(string pro, RpcInfo rpcInfo = default) {
        this.product = pro;
    }

    static void ChangeProduct(Changed<CustomerController> changed) {
        changed.Behaviour.ChangeProduct();
    }

    private void ChangeProduct() {
        //Debug.Log("asdff");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            int aux = int.Parse(product.ToString());
            productTx.text = aux.ToString();
            productImg.color = aux == 0 ? Color.red : Color.blue;
            arrowImg.sprite = starIcon;
            canvas.SetActive(true);
        }
    }
}

