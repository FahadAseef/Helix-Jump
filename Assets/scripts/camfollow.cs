using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    public Transform target;
    float offset;

    private void Awake()
    {
        offset = transform.position.y - target.position.y;
    }

    void Update()
    {
        Vector3 currentposition =transform.position;
        currentposition.y=target.transform.position.y+offset;
        transform.position = currentposition;
    }
}
