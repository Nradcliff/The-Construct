using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CoreThrow coreThrow;
    [SerializeField] private Transform CoreSpawn;

    [Header("Trajectory Line Smoothness/Length")]
    [SerializeField] private int segmentCount = 50;
    [SerializeField] private float curveLength = 3.5f;

    private Vector3[] segments;
    public LineRenderer lr;

    private CoreThrow launchForce;

    private float lForce;
    private const float TIME_CURVE_ADDITION = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        //lr.enabled = false;
        segments = new Vector3[segmentCount];

        lr = GetComponent<LineRenderer>();
        lr.positionCount = segmentCount;

        launchForce = coreThrow.GetComponent<CoreThrow>();
        lForce = launchForce.LaunchForce;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            lr.enabled = true;
        }
        */

        Vector3 startPos = CoreSpawn.position;
        segments[0] = startPos;
        lr.SetPosition(0, startPos);

        Vector3 startVelocity = transform.right * lForce;

        for (int i = 1; i < segmentCount; i++)
        {
            float timeOffset = (i * Time.fixedDeltaTime * curveLength);
            Vector3 gravityOffset = TIME_CURVE_ADDITION * Physics.gravity * Mathf.Pow(timeOffset, 2);

            segments[i] = segments[0] + startVelocity * timeOffset + gravityOffset;
            lr.SetPosition(i, segments[i]);
        }
    }
}
