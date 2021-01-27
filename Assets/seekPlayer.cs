using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekPlayer : MonoBehaviour
{
    /*
    private struct data
    {
        public Vector2 pos;
        public float orientation;
    };
    private struct kinematicSteeringObject
    {
        public Vector2 vel;
        public float orientation;
    };
    public Rigidbody rb;
    public Transform player;
    public float maxSpeed;
    kinematicSteeringObject seeker;
  
    private float getNewOrientation()
    {
        if (rb.velocity.magnitude > 0)
        {
            return Mathf.Atan2(-rb.velocity.x, rb.velocity.z);
        }
        else return Mathf.Atan2(-rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y) ;
    }

    private kinematicSteeringObject getSteering()
    {
        data character;
        data target;
        kinematicSteeringObject steering;
        character.pos.x = rb.position.x;
        character.pos.y = rb.position.y;
        target.pos.x = player.position.x;
        target.pos.y = player.position.y;
        steering.vel = target.pos - character.pos;
        steering.vel /= steering.vel.magnitude;
        steering.vel *= maxSpeed;
        steering.orientation = getNewOrientation();
       
        return steering;
    }
    */
    
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
        velocity = player.position - seeker.position;
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
