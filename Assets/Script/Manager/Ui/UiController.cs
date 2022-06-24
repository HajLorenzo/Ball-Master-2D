using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UiController : MonoBehaviour
{
    private static UiController _instance;
    public static UiController Instance => _instance;

    #region Variables
    [Space(10), Header("-----Variables-----")]
    public UiStatus uiStatus;

    #endregion

    #region Menu Variables
    [Space(10), Header("-----Menu Variables-----")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Transform TouchToPlay;
    #endregion

    #region Gameplay Variables
    [Space(10), Header("-----Gameplay Variables-----")]
    [SerializeField] private GameObject gameplayPanel;
    #endregion

    #region WinPanel Variables
    [Space(10), Header("-----WinPanel Variables-----")]
    [SerializeField] private GameObject winPanel;
    #endregion

    #region LosePanel Variables
    [Space(10), Header("-----Gameplay Variables-----")]
    [SerializeField] private GameObject losePanel;
    #endregion

    #region Global Variables
    [Space(10), Header("-----Global Variables-----")]
    [SerializeField] private GameObject blockPanel;
    #endregion

    private void Awake()
    {
        _instance = this;
        uiStatus = UiStatus.Menu;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        TouchToPlay.DOScale(TouchToPlay.localScale.x * 4 / 5, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    public void ChangeUiStatus(UiStatus newGamestatus)
    {
        if (uiStatus == newGamestatus || uiStatus==UiStatus.Lose) return;
        uiStatus = newGamestatus;
        switch (newGamestatus)
        {
            case UiStatus.Menu:
                break;
            case UiStatus.Playing:
                menuPanel.SetActive(false);
                gameplayPanel.SetActive(true);
            break;
            case UiStatus.Win:
                AudioManager.Instance.Play(1);
                gameplayPanel.SetActive(false);
                winPanel.SetActive(true);
                UiFadeController.Instance.DelayFade(true, 2, false);
                break;
            case UiStatus.Lose:
                AudioManager.Instance.Play(2);
                gameplayPanel.SetActive(false);
                losePanel.SetActive(true);
                UiFadeController.Instance.DelayFade(true, 2, true);
                break;
        }
    }

    public void ToggleBlockPanel(bool toggle)
    {
        blockPanel.SetActive(toggle);
    }

    #region Buttons
    public void OnPlayBtnClick() 
    {
        ChangeUiStatus(UiStatus.Playing);
    }
    #endregion
}