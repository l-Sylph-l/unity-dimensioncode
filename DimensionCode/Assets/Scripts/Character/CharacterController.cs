using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    private Rigidbody rigidbody;
    private GameObject currentCollision;

    bool isOnGround = true;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;

        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isOnGround = true;

            currentCollision = collision.gameObject;
            Debug.Log("Current Collision: " + currentCollision.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        //if (Input.GetKeyDown("escape"))
        //{
        //    // turn on the cursor
        //    Cursor.lockState = CursorLockMode.None;
        //}

        // Jump     
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rigidbody.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            isOnGround = false;
            currentCollision = null;
        }
    }

    public GameObject GetCurrentCollider()
    {
        return currentCollision;
    }
}