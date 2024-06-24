using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class CustomerController : NetworkBehaviour {

    [Networked(OnChanged = nameof(ChangeColor))] public NetworkString<_32> charColor { get; set; }

    [Networked(OnChanged = nameof(ChangeProduct))] public NetworkString<_2> product { get; set; }


    [SerializeField] private GameObject[] hairStyles = new GameObject[0];
    [SerializeField] private Color[] hairColors = new Color[0];
    [SerializeField] private Renderer bodyRender;
    [SerializeField] private Renderer hands;
    [SerializeField] private Color[] bodyColors = new Color[0];
    [SerializeField] private Color[] shirtsColors = new Color[0];
    [SerializeField] private Color[] pantsColors = new Color[0];

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent nav;
    private bool walking;
    private bool waiting;
    private float tState;
    private float tDelay;
    private Vector3 target;

    [SerializeField] private GameObject canvas;
    [SerializeField] private Image productImg;
    [SerializeField] private TMP_Text productTx;
    [SerializeField] private SpriteRenderer arrowImg;

    [SerializeField] private GameObject carrito;
    private bool carritoShown;

    [SerializeField] private bool ending;


    [SerializeField] private bool gender;

    public GameObject player;

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
        int product = Random.Range(0,3);
        if (product != 0) product = Random.Range(1, ProductsDB.instance.products.Length);
        RPC_SetProduct(product.ToString());
        this.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public override void FixedUpdateNetwork() {
        if (anim.GetBool("box") && !carritoShown) {
            carrito.SetActive(true);
            this.GetComponent<Collider>().enabled = false;
            this.canvas.SetActive(false);

            int aux = int.Parse(product.ToString());
            GameObject itemAux = Instantiate(ProductsDB.instance.products[aux].obj, carrito.transform.position, Quaternion.identity);
            itemAux.transform.parent = carrito.transform;

            carritoShown = true;
            return;
        }
        if (!Spawner.instance.owner) return;
        if (waiting) return;

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
        hands.material.color = bodyColors[skinColor];
        hairStyles[hairStyle].SetActive(true);
        hairStyles[hairStyle].GetComponent<Renderer>().material.color = hairColors[hairColor];
        if (gender) {
            bodyRender.materials[2].color = shirtsColors[shirt];
            bodyRender.materials[3].color = pantsColors[pant];
        } else {
            bodyRender.materials[1].color = shirtsColors[shirt];
            bodyRender.materials[2].color = pantsColors[pant];
        }
        
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

            if (other.GetComponent<PlayerMovement>().bussy && other.GetComponent<PlayerMovement>().itemID.ToString() == product.ToString() && waiting && player == other.gameObject) {
                other.GetComponent<PlayerMovement>().LeaveItem();
                StartCoroutine(EndMovement());
                return;
            }

            if (other.GetComponent<PlayerMovement>().bussy) return;

            if (waiting) return;

            if (player != null) return;

            int aux = int.Parse(product.ToString());

            if (aux == 0) StartCoroutine(ShowCloud()); //no item
            else {
                waiting = true;
                walking = false;
                nav.isStopped = true;
                anim.SetBool("run", false);

                other.GetComponent<PlayerMovement>().SetBussy();

                //productTx.text = ProductsDB.instance.products[aux].pName;
                productTx.text = "";
                productImg.sprite = ProductsDB.instance.products[aux].img;
                arrowImg.color = Color.white;
                canvas.SetActive(true);
                player = other.gameObject;
            }
        }
    }

    IEnumerator EndMovement() {
        anim.SetBool("box", true);
        anim.SetBool("run", true);
        nav.SetDestination(GameManager.instance.cajaPoint.position);
        nav.isStopped = false;
        nav.speed = 7;

        while(Vector3.Distance(this.transform.position, GameManager.instance.cajaPoint.position) > 1)
            yield return new WaitForSeconds(0.1f);

        nav.SetDestination(GameManager.instance.portalPoint.position);
        nav.isStopped = false;
        int aux = (int)(200f * UIManager.instance.GetTimeBar());
        GameManager.instance.AddPoints(200 + aux);

        //money sound and particles
        AudioManager.instance.PlayCajaRegistradora();

        while (Vector3.Distance(this.transform.position, GameManager.instance.portalPoint.position) > 1)
            yield return new WaitForSeconds(0.1f);

        AudioManager.instance.PlayPortal();
        GameManager.instance.CreateCustomers(2);
        Runner.Despawn(this.gameObject.GetComponent<NetworkObject>());
    }

    IEnumerator ShowCloud() {
        productTx.text = "...";
        canvas.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
    }
}