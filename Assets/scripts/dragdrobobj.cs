using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dragdrobobj : MonoBehaviour {

    Vector3 mouseposicion;
    public int objid;
    bool dragobj;
    bool destroyobj_A;
    bool destroyobj_B;
    bool destroyobj_C;

    [SerializeField] private bool destroyByTime;

    private void Start()
    {
        objid = cajasspawn.instance.randomindex;
        if (destroyByTime) Destroy(this.gameObject, 10);
    }

    Vector3 getmousepos()
    {
        return cajasspawn.instance.cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mouseposicion=Input.mousePosition-getmousepos();
        dragobj = true;
    }

    private void OnMouseDrag()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = cajasspawn.instance.cam.ScreenToWorldPoint(Input.mousePosition-mouseposicion);
        dragobj = true;
    }

    private void OnMouseUp()
    {
        dragobj=false;
        Destroy(this.gameObject, 0.15f);
    }

    private void Update()
    {
        if (destroyobj_A && !dragobj)
        {
            cajasspawn.instance.incrementaobjetos_A();
            Destroy(this.gameObject, 0.13f);
            destroyobj_A = false;
        }
        if (destroyobj_B && !dragobj)
        {
            cajasspawn.instance.incrementaobjetos_B();
            Destroy(this.gameObject, 0.13f);
            destroyobj_B = false;
        }

        if (destroyobj_C && !dragobj)
        {
            cajasspawn.instance.incrementaobjetos_C();
            Destroy(this.gameObject, 0.13f);
            destroyobj_C = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cubobasura") && !dragobj) {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("espacio1") && this.objid == 0)
        {

            destroyobj_A = true;
            
        }
        else
        {
            destroyobj_A=false;
        }


        if (other.gameObject.CompareTag("espacio2") && this.objid == 1 )
        {

            destroyobj_B = true;
            
        }
        else
        {
            destroyobj_B=false;
        }

        if (other.gameObject.CompareTag("espacio3") && this.objid == 2 )
        {
            destroyobj_C = true;
        }
        else
        {
            destroyobj_C=false;
        }

    }
    private void OnTriggerStayssss(Collider other)
    {
        if (other.gameObject.CompareTag("cubobasura") && !dragobj)
        {
            Destroy(this.gameObject, 0.5f);
        }

        if (!dragobj && other.gameObject.CompareTag("espacio1"))
        {
            destroyobj_A = true;
            Destroy(this.gameObject);
        }
       

        if (!dragobj && other.gameObject.CompareTag("espacio2"))
        {
            destroyobj_B = true;
            Destroy(this.gameObject);
        }
        

        if (!dragobj && other.gameObject.CompareTag("espacio3"))
        {
            destroyobj_C = true;
            Destroy(this.gameObject);
        }
       

    }
}
