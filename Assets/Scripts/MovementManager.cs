using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float moveSpeed = 1;
    private float input;
    private Vector3 moveDirection;
    private AnimationCurve spawnFrequency;
    private Keyframe[] ks;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.left;
        input = 1;
       // InvokeRepeating("SkipMovement", 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(input * moveSpeed * Time.deltaTime * moveDirection);

        if (transform.position.x <= -4.0f)
        {
            Destroy(gameObject);
        }
    }

    public void StopMovement()
    {
        input = 0;
    }

    public void StartMovement()
    {
        input = 1;
        SkipMovement();
    }

    public void SkipMovement()
    {
        transform.Translate(input * moveSpeed * Time.deltaTime * moveDirection);
    }
}
