using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector2 pPos = (Vector2) player.transform.position;
        float distance = ((Vector2) transform.position - pPos).magnitude;
        Vector2 newPos = Vector2.Lerp((Vector2)transform.position, pPos, distance/150);
        gameObject.transform.position = new Vector3(newPos.x, newPos.y, gameObject.transform.position.z);
    }

    public void setActivePlayer(GameObject p)
    {
        player = p;
    }
}
