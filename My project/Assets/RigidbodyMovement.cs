using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class RigidbodyMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float force;
    public float jumpForce;
    public bool canJump;

    public Text scoreText;
    public float scoreValue;
    public Victory victory;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalForce = Input.GetAxis("Horizontal") * force;
        float verticalForce = Input.GetAxis("Vertical") * force;

        rb.AddForce(horizontalForce, 0f, verticalForce);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            canJump = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            scoreValue++;
            scoreText.text = "Score: "+scoreValue;

            if (scoreValue == 8)
            {
                victory.showWin();
            }
        }
    }
}
