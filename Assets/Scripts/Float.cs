using System;
using Unity.Mathematics;
using UnityEngine;

public class Float : MonoBehaviour
{
   public float speed = 2f;
   public float height = 0.5f;

   private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;   
    }
    private void Update()
    {
        float newY = startPosition.y + MathF.Sin(Time.time * speed)* height;
        transform.position = new Vector3(transform.position.x, newY, 0);
    }
}
