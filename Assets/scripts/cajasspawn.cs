using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class cajasspawn : MonoBehaviour {

    public static cajasspawn instance;

    [SerializeField] GameObject[] cajasspawnprefap;
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

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        spawnobjsbool = false;
        actualizacaja_A();
        actualizacaja_B();
        actualizacaja_C();
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
    }

    IEnumerator spawnobj()
    {
        
        for(int i = 0; i < cantitadobjspawn; i++)
        {
           randomindex = Random.Range(0, cajasspawnprefap.Length);
           
            if(randomindex == 0 && objectosactivar_A >= cajasactivables_A.Length)
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
            GameObject newobj = Instantiate(cajasspawnprefap[randomindex], sitiospawn.position, sitiospawn.rotation);
            yield return new WaitForSeconds(0.5f);
         
        }
        yield return new WaitForSeconds(spawnintervalos);
        spawnobjsbool = false;
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
}

//Instantiate(cajasspawnprefap[randomindex],sitiospawn.position,sitiospawn.rotation);
