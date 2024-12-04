using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanic : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f; 
    private bool isGrounded = true; 
    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody bulunamadı.Lütfen objeye ekleyin.");
        }
    }

  
    void Update()
    {
       
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");
        Vector3 moveSystem = new Vector3(xHorizontal, 0.0f, zVertical);
        transform.position += moveSystem * speed * Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  
        }
    }
}
