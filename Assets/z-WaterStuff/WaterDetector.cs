using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.attachedRigidbody != null)
        {
            //if ()
            transform.parent.GetComponent<DynamicWater2D>().Splash(transform.position.x, Hit.attachedRigidbody.velocity.y * Hit.attachedRigidbody.mass / 40f);
        }
    }
}
