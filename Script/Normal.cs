using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : MonoBehaviour
{
    public GameObject normal;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "OutOfBounds" || collisionInfo.collider.name == "FinishLine"
            || collisionInfo.collider.name == "Player")
        {
            Destroy(normal);
        }
    }
}
