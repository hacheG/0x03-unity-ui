using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;    
    public float speed = 1000.0f;
    private int score = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //rb.AddForce(0,0,  speed * Time.deltaTime);
        //rb.AddForce()
        if ( Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0,speed * Time.deltaTime );
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0,0 ,-speed * Time.deltaTime );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup"  )
        {
            score += 1;
            Debug.Log(string.Format("Score: {0}", score));
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log(string.Format("Health: {0}", health));
        }
                
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log(string.Format("You win!"));
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log(string.Format("Game Over!"));
            health = 5;
            score = 0;
            SceneManager.LoadScene("maze");
        }
    }
}
