using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1Component;
    [SerializeField] float releaseXmin;
    [SerializeField] float releaseXmax;
    [SerializeField] float speed;
    [SerializeField] AudioClip[] ballEffects;
    [SerializeField] float randomxy = 0.2f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached compnent references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1Component.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LauchBallOnMouseClick();
        }


       
    }

    private void LauchBallOnMouseClick()
    {
       if( Input.GetMouseButtonDown(0))
       {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(UnityEngine.Random.Range(releaseXmin, releaseXmax), speed);
       }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1Component.transform.position.x, paddle1Component.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomxy), UnityEngine.Random.Range(0, randomxy));

        if (hasStarted)
        {
            AudioClip clip = ballEffects[UnityEngine.Random.Range(0, ballEffects.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }
}
