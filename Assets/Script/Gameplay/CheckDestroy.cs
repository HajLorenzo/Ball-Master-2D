using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestroy : MonoBehaviour
{
    [SerializeField] private HingeJoint2D hingeJoint;
    private bool des = false;
    private float timer, defaultTimer;

    private void Awake()
    {
        defaultTimer = 0.5f;
        timer = defaultTimer;
    }
    private void Update()
    {
        if (!des)
        {
            if (timer <= 0)
            {
                if (hingeJoint == null)
                {
                    des = true;
                    UiController.Instance.ChangeUiStatus(UiStatus.Lose);
                }
                timer = defaultTimer;
            }
            else
                timer -= Time.deltaTime;
        }
    }
}