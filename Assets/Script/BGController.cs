using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Move();    
        CheckBounds();
    }

    private void Reset()
    {
        transform.position = new Vector3(0.0f,verticalBoundary);
    }

    private void Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed);
    }

    private void CheckBounds()
    {
        if(transform.position.y <= -verticalBoundary)
        {
            Reset();
        }
    }
}
