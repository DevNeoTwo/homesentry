using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;
using UnityEngine.UI;

public class cajasspawn : MonoBehaviour {

    public static cajasspawn instance;

    [SerializeField] GameObject[] cajasspawnprefap;
    [SerializeField] GameObject[] cajasspawnprefap1;
    [SerializeField] GameObject[] cajasspawnprefap2;
    [SerializeField] GameObject[] cajasspawnprefap3;
    [SerializeField] GameObject[] cajasspawnprefap4;
    [SerializeField] GameObject[] cajasspawnprefap5;
    [SerializeField] Transform sitiospawn;
    [SerializeField] float spawnintervalos;
    [SerializeField] int cantitadobjspawn;
    bool spawnobjsbool;
    public int randomindex;
    

    [SerializeField] GameObject[] cajasactivables_A;
    [SerializeField] GameObject[] cajasactivables_B;
    [SerializeField] GameObject[] cajasactivables_C;
    public int objectosactivar_A;
    public int objectosactivar_B;
    public int objectosactivar_C;

    [SerializeField] private float tiempo;
    private float tCurrent;
    public Camera cam;
    public int puntos;
    [SerializeField] TextMeshProUGUI textopuntos;
    [SerializeField] Image timerfill;
    [SerializeField] float duracionfill;

    [SerializeField] Material marcamaterial;
    [SerializeField] Texture[] marcatextura;
    [SerializeField] Texture[] emisiontextura;

    [SerializeField] GameObject spriteindex1;
    [SerializeField] Sprite[] sprites1;

    [SerializeField] GameObject spriteindex2;
    [SerializeField] Sprite[] sprites2;

    [SerializeField] GameObject spriteindex3;
    [SerializeField] Sprite[] sprites3;

    int numrandom;
    bool randomizado;
    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        spawnobjsbool = false;
        randomizado = false;
        actualizacaja_A();
        actualizacaja_B();
        actualizacaja_C();
        StartCoroutine(decrementofillimg());

    }
    private void FixedUpdate()
    {
        if (!spawnobjsbool)
        {
            spawnobjsbool = true;
            StartCoroutine(spawnobj());
        }

    }

    private void Update() {
        if (Time.time > tCurrent + tiempo) {
            //finalizar
        }
    }

    public void Restart() {
       // StartCoroutine(rotatesizestar.FindObjectOfType<rotatesizestar>().GetComponent<rotatesizestar>().escalador());
        objectosactivar_A = 0;
        objectosactivar_B = 0;
        objectosactivar_C = 0;
        spawnintervalos = 2;
        actualizacaja_A();
        actualizacaja_B();
        actualizacaja_C();
        tCurrent = Time.time;
        spawnobjsbool = false;
        puntos=0;
        duracionfill = 20;
        timerfill.fillAmount = 1;
        StartCoroutine(decrementofillimg());
        
        texturasmarcas();
        numrandom = Random.Range(1, 7);
        
        //StartCoroutine(spawnobj());
    }
    IEnumerator decrementofillimg()
    {
        float starttime=Time.time;
        float endtime=Time.time+duracionfill;
       
        while (Time.time<endtime)
        {
            float tiempopasado=Time.time-starttime;
            float porcentajecompleto=1f-(tiempopasado/duracionfill);
            timerfill.fillAmount=porcentajecompleto;
            yield return null;
        }
        timerfill.fillAmount = 0;
    }
    IEnumerator spawnobj()
    {
        
        for(int i = 0; i < cantitadobjspawn; i++)
        {
            if (camisaspantalones.instance.top == 1||camisaspantalones.instance.top==9)//sentry
            {
                randomizado=false;
                
                    randomindex = Random.Range(0, cajasspawnprefap5.Length);
                
            }
            if (camisaspantalones.instance.top == 2)//zoom
            {
                randomizado = false;
                randomindex = Random.Range(0, cajasspawnprefap1.Length);
            }
            if (camisaspantalones.instance.top == 3)//natureheart
            {
                randomizado = false;
                randomindex = Random.Range(0, cajasspawnprefap2.Length);
            }
            if (camisaspantalones.instance.top == 4)//blackdeker
            {
                randomizado = false;
                randomindex = Random.Range(0, cajasspawnprefap3.Length);
            }
            if (camisaspantalones.instance.top == 5|| camisaspantalones.instance.top == 6)//imusa
            {
                randomizado = false;
                randomindex = Random.Range(0, cajasspawnprefap4.Length);
            }
            if (camisaspantalones.instance.top == 7)//mercadeo
            {
                randomizado = true;
                if(randomizado)
                {
                    if (numrandom == 1)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap5.Length);
                    }
                    if (numrandom == 2)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap1.Length);
                    }
                    if (numrandom == 3)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap2.Length);
                    }
                    if (numrandom == 4)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap3.Length);
                    }
                    if (numrandom == 5)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap4.Length);
                    }
                    if (numrandom == 6)
                    {
                        randomindex = Random.Range(0, cajasspawnprefap.Length);
                    }
                }
                
            }
            if (camisaspantalones.instance.top == 8)//ninjashark
            {
                randomizado=false;
                randomindex = Random.Range(0, cajasspawnprefap.Length);
            }

            if (randomindex == 0 && objectosactivar_A >= cajasactivables_A.Length)
            {
                spawnintervalos = 1f;
                break;
            }
            if (randomindex == 1 && objectosactivar_B >= cajasactivables_B.Length)
            {
                spawnintervalos = 0.5f;
                break;
            }
            if (randomindex == 2 && objectosactivar_C >= cajasactivables_C.Length)
            {
                spawnintervalos = 0.2f;
                break;
            }

            if(camisaspantalones.instance.top == 1|| camisaspantalones.instance.top==9)//homesentry
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap5[randomindex], sitiospawn.position, sitiospawn.rotation);
                
                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[5];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[5];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[5];

                spriteindex1.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
            }
            if (camisaspantalones.instance.top == 2)//zoom
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap1[randomindex], sitiospawn.position, sitiospawn.rotation);
                
                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[1];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[1];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[1];

                spriteindex1.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            }
            if (camisaspantalones.instance.top == 3)//natureheart
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap2[randomindex], sitiospawn.position, sitiospawn.rotation);

                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[2];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[2];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[2];

                spriteindex1.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.13f, 0.13f, 1f);
            }
            if (camisaspantalones.instance.top == 4)//blackdecker
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap3[randomindex], sitiospawn.position, sitiospawn.rotation);

                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[3];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[3];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[3];

                spriteindex1.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.15f, 0.15f, 1f);

            }
            if (camisaspantalones.instance.top == 5|| camisaspantalones.instance.top == 6)//imusa
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap4[randomindex], sitiospawn.position, sitiospawn.rotation);

                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[4];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[4];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[4];

                spriteindex1.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            }

            if (camisaspantalones.instance.top == 7)//mercadeo
            {
                randomizado = true;

                if (randomizado)
                {
                    if (numrandom == 1)//sentry
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap5[randomindex], sitiospawn.position, sitiospawn.rotation);

                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[5];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[5];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[5];
                    }
                    if (numrandom == 2)//zoom
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap1[randomindex], sitiospawn.position, sitiospawn.rotation);
                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[1];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[1];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[1];
                    }
                    if (numrandom == 3)//natureheart
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap2[randomindex], sitiospawn.position, sitiospawn.rotation);

                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[2];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[2];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[2];
                    }
                    if (numrandom == 4)//blackdecker
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap3[randomindex], sitiospawn.position, sitiospawn.rotation);

                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[3];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[3];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[3];
                    }
                    if (numrandom == 5)//imusa
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap4[randomindex], sitiospawn.position, sitiospawn.rotation);

                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[4];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[4];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[4];
                    }
                    if (numrandom == 6)//sharkninja
                    {
                        GameObject newobj = Instantiate(cajasspawnprefap[randomindex], sitiospawn.position, sitiospawn.rotation);

                        spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[0];
                        spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[0];
                        spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[0];
                    }
                }
               
            }

            if (camisaspantalones.instance.top == 8)//sharkninja
            {
                randomizado = false;
                GameObject newobj = Instantiate(cajasspawnprefap[randomindex], sitiospawn.position, sitiospawn.rotation);

                spriteindex1.GetComponent<SpriteRenderer>().sprite = sprites1[0];
                spriteindex2.GetComponent<SpriteRenderer>().sprite = sprites2[0];
                spriteindex3.GetComponent<SpriteRenderer>().sprite = sprites3[0];

                spriteindex1.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex2.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
                spriteindex3.transform.localScale = new Vector3(0.15f, 0.15f, 1f);

            }

            yield return new WaitForSeconds(0.5f);
         
        }
        yield return new WaitForSeconds(spawnintervalos);
        spawnobjsbool = false;
    }
  
    void texturasmarcas()
    {
        
        if (camisaspantalones.instance.top == 1)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[0]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[0]);
            
        }
        if (camisaspantalones.instance.top == 2)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[1]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[1]);
        }
        if (camisaspantalones.instance.top == 3)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[2]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[2]);
        }
        if (camisaspantalones.instance.top == 4)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[3]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[3]);
        }
        if (camisaspantalones.instance.top == 5)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[4]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[4]);
        }
        if (camisaspantalones.instance.top == 6)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[5]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[5]);
        }
        if (camisaspantalones.instance.top == 7)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[6]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[6]);
        }
        if (camisaspantalones.instance.top == 8)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[7]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[7]);
        }
        if (camisaspantalones.instance.top == 9)
        {
            marcamaterial.SetTexture("_MainTex", marcatextura[8]);
            marcamaterial.SetTexture("_EmissionMap", emisiontextura[8]);
        }
    }

    public void incrementaobjetos_A()
    {
        if (objectosactivar_A < cajasactivables_A.Length)
        {
                objectosactivar_A++;
                actualizacaja_A();
        }
        
    }
    public void incrementaobjetos_B()
    {
        if (objectosactivar_B < cajasactivables_B.Length)
        {
                objectosactivar_B++;
                actualizacaja_B();
        }
    }
    public void incrementaobjetos_C()
    {
        if (objectosactivar_C < cajasactivables_C.Length)
        {
                objectosactivar_C++;
                actualizacaja_C();
        }
    }

    private void actualizacaja_A()
    {
        for (int i = 0; i < cajasactivables_A.Length; i++)
        {
            if (i < objectosactivar_A)
            {
                cajasactivables_A[i].SetActive(true);
            }
            else
            {
                cajasactivables_A[i].SetActive(false);
            }
        }

    }
    private void actualizacaja_B()
    {
        for (int i = 0; i < cajasactivables_B.Length; i++)
        {
            if (i < objectosactivar_B)
            {
                cajasactivables_B[i].SetActive(true);
            }
            else
            {
                cajasactivables_B[i].SetActive(false);
            }
        }
    }
    private void actualizacaja_C()
    {
        for (int i = 0; i < cajasactivables_C.Length; i++)
        {
            if (i < objectosactivar_C)
            {
                cajasactivables_C[i].SetActive(true);
            }
            else
            {
                cajasactivables_C[i].SetActive(false);
            }
        }
    }
    public void addscore()
    {
        puntos+=25;
        textopuntos.text = "PUNTOS: "+puntos.ToString();
    }
}

//Instantiate(cajasspawnprefap[randomindex],sitiospawn.position,sitiospawn.rotation);
