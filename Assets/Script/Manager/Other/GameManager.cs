using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    #region DontDestroy Scripts
    [Space(10), Header("----------DontDestroy Scripts----------")]
    [SerializeField] private GameObject objectPooler;
    #endregion



    [HideInInspector] public int ballCount;
    [HideInInspector] public int correctCount = 0;
    private int winCount;

    private void Awake()
    {
        _instance = this;
        Init();
    }
    private void Init()
    {
        Application.targetFrameRate = 60;
        Instantiate(objectPooler, transform.position, Quaternion.identity);
    }
    private IEnumerator Start()
    {
        ballCount = GameObject.FindObjectsOfType<Ball>().Length;
        yield return new WaitForSeconds(0.5f);
        winCount = ballCount;
    }

    public void CheckWin()
    {
        if (ballCount == 0)
        {
            if (correctCount == winCount)
                UiController.Instance.ChangeUiStatus(UiStatus.Win);
            else
                UiController.Instance.ChangeUiStatus(UiStatus.Lose);
        }
    }
}