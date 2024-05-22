using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragdrobobj : MonoBehaviour
{
    Vector3 mouseposicion;
    public int objid;
    Vector3 getmousepos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mouseposicion=Input.mousePosition-getmousepos();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition-mouseposicion);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("cubobasura")) 
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
