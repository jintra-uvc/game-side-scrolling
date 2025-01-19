using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    // public Health PlayerHealth;
    // public SoundManager soundManager;
    // public AudioSource audioSource;
    

    public bool controlEnabled = true;
    public float speed = 6.0f;
    public float jumpForce = 7.0f;

    private bool isGround = false;
    //private bool isDeath = false;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
            // Movement
            float step = speed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizontalInput, 0) * step;
            this.transform.position += movement;

            // Jump
            if (Input.GetButtonDown("Jump") && isGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGround = false;
                // SoundManager.playSound("jumpSound");
            }


        }

        // check IsAlive
        // if (PlayerHealth.currentHP <= 0 && !isDeath)
        // {
        //     controlEnabled = false;
        //     audioSource.Stop();
        //     isDeath= true;
        //     SoundManager.playSound("playerDeath");
        // }
    }

    // Check on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}