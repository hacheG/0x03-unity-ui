using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;    
    public float speed = 1000.0f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;
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
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup"  )
        {
            score += 1;
            SetScoreText();
            //Debug.Log(string.Format("Score: {0}", score));
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
            //Debug.Log(string.Format("Health: {0}", health));
        }
                
        if (other.gameObject.tag == "Goal")
        {
            SetWin();
            //Debug.Log(string.Format("You win!"));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetWin()
    {
        WinLoseText.text = "You Win!";
        WinLoseText.color = Color.black;
        WinLoseBG.color = Color.green;
        WinLoseBG.gameObject.SetActive(true);
        StartCoroutine(LoadScene(3));
    }

    void SetGameOver()
    {
        WinLoseText.text = "Game Over!";
        WinLoseText.color = Color.white;
        WinLoseBG.color = Color.red;
        WinLoseBG.gameObject.SetActive(true);
        health = 5;
        score = 0;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SetGameOver();
            //Debug.Log(string.Format("Game Over!"));
            StartCoroutine(LoadScene(3));
            //SceneManager.LoadScene("maze");
        }
    }
}
