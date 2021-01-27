using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleePlayer : MonoBehaviour
{
    public Rigidbody seeker;
    public Transform player;
    public float maxSpeed;
    private float currentOrientation;
    public float getNewOrientation(Vector3 currentVelocity)
    {
        if (currentVelocity.magnitude > 0)
            return Mathf.Atan2(currentVelocity.x, currentVelocity.z);
        else return Mathf.Atan2(seeker.rotation.eulerAngles.x, seeker.rotation.eulerAngles.z);
    }
    public Vector3 getSteering()
    {
        Vector3 velocity;
        velocity = seeker.position - player.position;
        velocity.y = 0;
        velocity /= velocity.magnitude;
        velocity *= maxSpeed;
        return velocity;

    }

    void Update()
    {
        seeker.velocity = getSteering();
        Debug.Log(seeker.velocity);
        currentOrientation = getNewOrientation(seeker.velocity);
        seeker.rotation = Quaternion.Euler(0, currentOrientation * Mathf.Rad2Deg, 0);
        Debug.Log(currentOrientation);
    }
}
