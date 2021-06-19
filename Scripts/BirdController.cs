using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public float tilt = 5;
    Quaternion downRotation;
    Quaternion forwardRotation;

    public Score scoreText;
    public GameObject replayButton;
    public GameObject componentStack;
    public GameObject clickHelperUI;

    bool isDead;

  

    void Start()
    {
        SceneManager.GetActiveScene();
        isDead = false;
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && isDead == false)
        {
            Time.timeScale = 1;
            //flap
            rb.velocity = Vector2.up * speed; // (0,1) because we don't move to the X axis
            transform.rotation = forwardRotation;
        }
        // transform.rotation is now a quaternion, not an vector3.euler -> its mean that we are going from a source value to a target value over a certain amount of tine
        // source value is a transform.rotation, target value is downRotation and the last is the tilt variable.
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tilt * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            scoreText.ScoreUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            // game over
            isDead = true;
            Time.timeScale = 0;
            replayButton.SetActive(true);
            Instantiate(componentStack, new Vector2(0.2f, 3f), Quaternion.identity);
            Instantiate(componentStack, new Vector2(51f, 1f), Quaternion.identity);
            Instantiate(componentStack, new Vector2(3f, 1.5f), Quaternion.Euler(0f, 0f, 30f));
            Instantiate(componentStack, new Vector2(-1f, 0f), Quaternion.Euler(0f, 0f, 70f));

        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // each scene has an index, load the active scene (we have 1 scene)
        
    }

  
}
