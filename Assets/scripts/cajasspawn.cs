using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajasspawn : MonoBehaviour
{
    [SerializeField] GameObject[] cajasspawnprefap;
    [SerializeField] Transform sitiospawn;
    [SerializeField] float spawnintervalos;
    [SerializeField] int cantitadobjspawn;
    bool spawnobjsbool;
    public int randomindex;

    [SerializeField] GameObject[] cajasactivables;
    [SerializeField] int objectosactivar;
    private void Start()
    {
        spawnobjsbool = false;
        actualizacaja();
    }
    private void FixedUpdate()
    {
        if (!spawnobjsbool)
        {
            spawnobjsbool = true;
            StartCoroutine(spawnobj());
        }
        
    }

    IEnumerator spawnobj()
    {
        
        for(int i = 0; i < cantitadobjspawn; i++)
        {
            
            GameObject newobj = Instantiate(cajasspawnprefap[randomindex], sitiospawn.position, sitiospawn.rotation);
            yield return new WaitForSeconds(0.6f);
            randomindex = Random.Range(0, cajasspawnprefap.Length);
        }
        yield return new WaitForSeconds(spawnintervalos);
        spawnobjsbool = false;
    }

    public void incrementaobjetos()
    {
        if (objectosactivar < cajasactivables.Length)
        {
            objectosactivar++;
            actualizacaja();
        }
    }

    private void actualizacaja()
    {
        for (int i = 0; i < cajasactivables.Length; i++)
        {
            if (i < objectosactivar)
            {
                cajasactivables[i].SetActive(true);
            }
            else
            {
                cajasactivables[i].SetActive(false);
            }
        }
    }
}

//Instantiate(cajasspawnprefap[randomindex],sitiospawn.position,sitiospawn.rotation);
