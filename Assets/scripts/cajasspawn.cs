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
    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        spawnobjsbool = false;
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
        duracionfill = 15;
        timerfill.fillAmount = 1;
        StartCoroutine(decrementofillimg());
        StartCoroutine(rotatesizestar.FindObjectOfType<rotatesizestar>().GetComponent<rotatesizestar>().escalador());
        texturasmarcas();
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
            if (camisaspantalones.instance.top == 0)
            {
                randomindex = Random.Range(0, cajasspawnprefap.Length);
            }
            if (camisaspantalones.instance.top > 0)
            {
                randomindex = Random.Range(0, cajasspawnprefap1.Length);
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

            if(camisaspantalones.instance.top == 0)
            {
                GameObject newobj = Instantiate(cajasspawnprefap[randomindex], sitiospawn.position, sitiospawn.rotation);
            }
            if (camisaspantalones.instance.top > 0)
            {
                GameObject newobj = Instantiate(cajasspawnprefap1[randomindex], sitiospawn.position, sitiospawn.rotation);
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
        puntos+=50;
        textopuntos.text = "PUNTOS: "+puntos.ToString();
    }
}

//Instantiate(cajasspawnprefap[randomindex],sitiospawn.position,sitiospawn.rotation);
