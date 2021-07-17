using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -19.62f;
    public float jumpHeight = 5f;

    bool iHaveJumped = false;

    // public Transform groundCheck;
    // public float groundDistance =0.4f;
    // public LayerMask groundMask;


    Vector3 velocity;

    
    
    // bool isGrounded;

    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(/*isGrounded &&*/  iHaveJumped && velocity.y >= -(Mathf. Sqrt(jumpHeight * -2f * gravity)))
        {
                velocity.y +=gravity * Time.deltaTime;
        }               
            
        else if(velocity.y < -(Mathf. Sqrt(jumpHeight * -2f * gravity))){
            velocity.y = 0f;
            iHaveJumped = false;
        }
        
        
        



        // if(velocity.y <= Mathf. Sqrt(jumpHeight * -2f * gravity))
        // {
        //     velocity.y = 0f;
        // }
        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical");
        
        Vector3 move =transform.right*x +transform.forward*z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && (!iHaveJumped)/*&& isGrounded*/)
        {
            velocity.y = Mathf. Sqrt(jumpHeight * -2f * gravity);
            iHaveJumped = true;
        }

        
        controller.Move(velocity*Time.deltaTime);
     
    }
       
    

    /*{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}*/

}
