using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  
public class Ball : MonoBehaviour
{
    private bool isCollected = false;
    private bool isActive = false;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    #region temp
    private Ray ray;
    private RaycastHit hit;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        if (!isActive)
        {
            if (UiController.Instance.uiStatus==UiStatus.Playing && rb.bodyType == RigidbodyType2D.Kinematic)
            {
                isActive = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.DOScale(transform.localScale.x - transform.localScale.x / 3, 0.1f)
                    .SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear);
                transform.GetChild(0).gameObject.SetActive(true);
            }
          }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        isCollected = true;
        if (other.CompareTag(Constant.Bag))
            other.GetComponent<Bag>().GetBall(this);
        else if(other.CompareTag(Constant.Block))
        {
            GameManager.Instance.ballCount--;
            GameManager.Instance.CheckWin();
            Destroy(gameObject);
        }
    }
}