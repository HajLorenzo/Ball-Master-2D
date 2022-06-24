using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    private Rigidbody2D rb;
    private float offset;
    private void Awake()
    {
        offset = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMouseDrag()
    {
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset)));
    }
}