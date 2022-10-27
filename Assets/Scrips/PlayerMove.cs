using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Animator playerAni;
    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);
        if(inputX != 0 ||  inputY != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
            playerAni.SetBool("IsRun", true);

        }
        else
        {
            playerAni.SetBool("IsRun", false);
        }
    }
}

