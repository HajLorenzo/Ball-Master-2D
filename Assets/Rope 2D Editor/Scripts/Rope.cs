using UnityEngine;
using System.Collections.Generic;
public enum SegmentSelectionMode
{
    RoundRobin,
    Random
}
public enum LineOverflowMode
{
    Round,
    Shrink,
    Extend
}
public class Rope : MonoBehaviour {

    private static Rope _instance;
    public static Rope Instance => _instance;

    public SpriteRenderer[] SegmentsPrefabs;
    public SegmentSelectionMode SegmentsMode;
    public LineOverflowMode OverflowMode; 
    [HideInInspector]
    public bool useBendLimit = true;
    [HideInInspector]
    public int bendLimit = 45;
    [HideInInspector]
    public bool HangFirstSegment = false;
    [HideInInspector]
    public Vector2 FirstSegmentConnectionAnchor;
    [HideInInspector]
    public Vector2 LastSegmentConnectionAnchor;
    [HideInInspector]
    public bool HangLastSegment = false;
#if UNITY_EDITOR
    [HideInInspector]
    public bool BreakableJoints=false;
    [HideInInspector]
    public float BreakForce = 100;
#endif
    [Range(-0.5f,0.5f)]
    public float overlapFactor;
    public List<Vector3> nodes = new List<Vector3>(new Vector3[] {new Vector3(-3,0,0),new Vector3(3,0,0) });
    [HideInInspector]
    public bool EnablePhysics=true;

    [SerializeField] private Transform[] endPoints;
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject[] particles;
    public float disance;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        disance = Vector2.Distance(endPoints[0].position, endPoints[1].position);
        if (Vector2.Distance(endPoints[0].position, endPoints[1].position) >= maxDistance)
        {
            particles[0].SetActive(true);
            particles[1].SetActive(true);
        }
        else
        {
            particles[0].SetActive(false);
            particles[1].SetActive(false);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        