using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class UiFadeController : MonoBehaviour
{
    private static UiFadeController _instance;
    public static UiFadeController Instance => _instance;

    [SerializeField] private float fadeDuration;
    private Image _fadeImage;

    private void Awake()
    {
        _instance = this;
        _fadeImage = GetComponent<Image>();
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        StartCoroutine(delay());
    }   
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        Fade(false,false);
    }
    public void Fade(bool _down, bool res)
    {
        UiController.Instance.ToggleBlockPanel(true);
        GC.Collect();
        if (_down)
            _fadeImage.DOFade(1, fadeDuration).OnComplete(() => LevelChanger(res)).SetUpdate(true).SetEase(Ease.Linear);
        else
            _fadeImage.DOFade(0, fadeDuration).OnComplete(() => UiController.Instance.ToggleBlockPanel(false));
    }
    public void DelayFade(bool _down, float delay,bool res)
    {
        StartCoroutine(Delay(_down, delay,res));
    }
    private IEnumerator Delay(bool _down, float delay, bool res)
    {
        yield return new WaitForSeconds(delay);
        Fade(_down,res);
    }
    public void LevelChanger(bool restart)
    {
        DOTween.KillAll();
        if (restart)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        else
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadSceneAsync(0);
            else
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void JustFade(int id, float speed)
    {
        _fadeImage.raycastTarget = true;
        _fadeImage.DOFade(id, speed).SetUpdate(true).SetEase(Ease.Linear).OnComplete(() => _fadeImage.raycastTarget = false);
    }
}