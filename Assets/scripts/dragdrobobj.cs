using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dragdrobobj : MonoBehaviour
{
    Vector3 mouseposicion;
    public int objid;
    cajasspawn cajasspawnscript;
    bool dragobj;
    bool destroyobj;
    private void Start()
    {
        cajasspawnscript = FindObjectOfType<cajasspawn>();
        objid = cajasspawnscript.randomindex;
    }

    Vector3 getmousepos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mouseposicion=Input.mousePosition-getmousepos();
        dragobj = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition-mouseposicion);
        dragobj = true;
    }

    private void OnMouseUp()
    {
        dragobj=false;
    }

    private void Update()
    {
        if (destroyobj&&!dragobj)
        {
            cajasspawnscript.incrementaobjetos();
            Destroy(this.gameObject, 0.13f);
            destroyobj = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("cubobasura")) 
        {
            Destroy(this.gameObject, 0.5f);
        }
        if (other.gameObject.CompareTag("espacio1") && this.objid == 0)
        {
            
            destroyobj = true;
            
        }


        if (other.gameObject.CompareTag("espacio2") && this.objid == 1 && !dragobj)
        {

            destroyobj = true;
            
        }


        if (other.gameObject.CompareTag("espacio3") && this.objid == 2 && !dragobj)
        {
            destroyobj = true;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (!dragobj && other.gameObject.CompareTag("espacio1") || other.gameObject.CompareTag("espacio2") || other.gameObject.CompareTag("espacio3"))
        {
            
            Destroy(this.gameObject, 0.5f);
            
        }
        
    }
}
