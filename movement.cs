using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanic : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f; // Zıplama kuvveti
    private bool isGrounded = true; // Karakterin yere temas durumu
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody bileşenini alıyoruz
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody bulunamadı! Lütfen objeye ekleyin.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Hareket girdileri
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");
        Vector3 moveSystem = new Vector3(xHorizontal, 0.0f, zVertical);
        transform.position += moveSystem * speed * Time.deltaTime;

        // Zıplama girişi
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Havada olduğumuzu belirt
        }
    }

    // Yere temas kontrolü
    private void OnCollisionEnter(Collision collision)
    {
        // Yere temas ettiğinde zıplamayı yeniden etkinleştir
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
