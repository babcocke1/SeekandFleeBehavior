using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public Rigidbody rb;
    // Start is called before the first frame update
    public float forwardForce = 2000f;
    public float sidewaysForce = 2000f;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("d")) 
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-1.0f * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce( 0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce( 0, 0, -1.0f * sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (rb.position.y  < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
     


    }
}
