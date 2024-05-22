using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragdrobobj : MonoBehaviour
{
    Vector3 mouseposicion;

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
}
