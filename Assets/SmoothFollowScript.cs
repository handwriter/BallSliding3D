using UnityEngine;
using System.Collections;

public class SmoothFollowScript : MonoBehaviour
{

    public Transform target;
    private Vector3 startPosition;
    private Vector3 myStartPosition;

    private void Start()
    {
        startPosition = target.position;
        myStartPosition = transform.position;
    }

    void Update()
    {
        transform.position = myStartPosition + (target.position - startPosition);
    }
}