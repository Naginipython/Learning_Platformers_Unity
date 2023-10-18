using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    //SerializeField lets me edit the numbers in Unity. If I used public, it does the same thing, but other scripts would be able to reference them.
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        /* BASIC KEY MOVEMENT
        if (Input.GetKeyDown("space")) {
            //velocity adds force to a specific direction
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }

        //GetKey vs GetKeyDown: GetKeyDown only takes the inital press, used once, GetKey keeps pressing until unpressed
        if (Input.GetKey("up")) {
            //I put the velocity of the Rigidbody in so it doesn't dead-stop
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        if (Input.GetKey("right")) {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey("down")) {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
        }
        if (Input.GetKey("left")) {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        */

        //If you go to Edit > Project Settings > Input Manager, and bring down the Axes toggle, you can find more info
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horInput*moveSpeed, rb.velocity.y, verInput*moveSpeed);
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }
    }

    bool IsGrounded() {
        //This creates a sphere that checks for some info, and returns a bool. 
        //groundCheck is given by dragging and dropping the Ground Check gameObject into the serialized field,
        //and ground is given by first, editing the prefab of Platform to add a layer 'ground' then selecting it. 
        //The serializefield can find it easily, just choose it in the Inspector.
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy Head")) {
            //Other is the Head, we need to kill the parent of that, EnemyObj
            Debug.Log("Player Hit Enemy");
            Destroy(other.transform.parent.gameObject);
            Jump();
        }
    }

    void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }
}
