using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager _instance;
    public static ObjectPoolManager Instance => _instance;

    #region Pool Variables

    [Space(10),Header("----------Pool Variables----------")]

    [SerializeField] private GameObject[] objectPrefab;
    [SerializeField] private int[] amount;
    private GameObject[] _parents;
    private List<List<GameObject>> _objectsPools;

    #endregion

    private void Awake()
    {
        _instance = this;
        Init();
    }
    private void Init()
    {
        _objectsPools = new List<List<GameObject>>();
        _parents = new GameObject[objectPrefab.Length];
        GameObject t;
        for (int i = 0; i < objectPrefab.Length; i++)
        {
            _parents[i] = new GameObject();
            _parents[i].name = objectPrefab[i].name;
            _parents[i].transform.SetParent(transform);
            _objectsPools.Add(new List<GameObject>());
            for (int j = 0; j < amount[i]; j++)
            {
                t = (GameObject)Instantiate(objectPrefab[i]);
                t.SetActive(false);
                _objectsPools[i].Add(t);
                t.transform.SetParent(_parents[i].transform);
            }
        }
    }

    public GameObject GetObject(int id)
    {
        for (int i = 0; i < amount[id]; i++)
        {
            if (!_objectsPools[id][i].activeSelf)
                return _objectsPools[id][i];
        }
        return null;
    }
    public void ResizePoolSize(int id)
    {
        GameObject t;
        for (int i = 0; i < 5; i++)
        {
            t = (GameObject)Instantiate(objectPrefab[id]);
            _objectsPools[id].Add(t);
        }
        amount[id] += 5;
    }
}