using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [Header("Controller")]
    Rigidbody rb;
    public float _speed;
    public float _jumpForce;
    bool jump = true;

    [Header("Score")]
    public int Score;
    public Text scoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
    }
    private void Update()
    {
        float X = Input.GetAxis("Horizontal")*Time.deltaTime* _speed;
        float Y = Input.GetAxis("Vertical")* Time.deltaTime* _speed;
        rb.AddForce(new Vector3(X,0,Y));
        if (Input.GetKeyDown(KeyCode.Space) && jump==true)
        {
            rb.AddForce(new Vector3(transform.position.x,transform.position.y* _jumpForce, transform.position.z));
            jump = false;
        }

        scoreText.text = "Score : " + Score.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            jump = true;
        }
        if (collision.gameObject.CompareTag("Object"))
        {
            Score++;
            Destroy(collision.gameObject);
        }
    }
}
