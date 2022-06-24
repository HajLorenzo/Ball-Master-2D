using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bag : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float defaultScale;
    private float animScale;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale.x;
        animScale = defaultScale * 4 / 5;
    }
    public void GetBall(Ball ball)
    {
        if (transform.localScale.x == defaultScale)
            transform.DOScale(animScale, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        if (ball.spriteRenderer.color == spriteRenderer.color)
        {
            GameManager.Instance.correctCount++;
            GameObject confettiParticle = ObjectPoolManager.Instance.GetObject(0);
            confettiParticle.transform.position = ball.transform.position;
            confettiParticle.SetActive(true);
            AudioManager.Instance.Play(0);
        }
        else
            AudioManager.Instance.Play(3);
        GameManager.Instance.ballCount--;
        GameManager.Instance.CheckWin();
        Destroy(ball.gameObject);
    }
}