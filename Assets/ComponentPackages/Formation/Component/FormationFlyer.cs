using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationFlyer : MonoBehaviour
{
    internal FormationLeader leader;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction);
    }

    void OnTriggerEnter(Collider zone)
    {
        leader.SendMessage("ReachedZone", zone.name);
    }
}
