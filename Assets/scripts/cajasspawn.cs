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
    private void Start()
    {
        spawnobjsbool = false;
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
        
        int randomindex=Random.Range(0,cajasspawnprefap.Length);
        for(int i = 0; i < cantitadobjspawn; i++)
        {
            Instantiate(cajasspawnprefap[randomindex],sitiospawn.position,sitiospawn.rotation);
            yield return new WaitForSeconds(0.6f);
        }
        yield return new WaitForSeconds(spawnintervalos);
        spawnobjsbool = false;
    }
}
