using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoost : MonoBehaviour
{
    public GameObject SBoost;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "OutOfBounds" || collisionInfo.collider.name == "FinishLine" 
            || collisionInfo.collider.name == "Player")
        {
            Destroy(SBoost);
        }
    }
}