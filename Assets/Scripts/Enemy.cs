using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private AudioSource enemyVoiceAudio;

    public float speed;
    public float maxWalkingSpeed;
    public float detectionDistance = 15.0f;

    private float nextChange = 0;
    private float changeRate = 5.0f;
    private Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyVoiceAudio = GetComponent<AudioSource>();
        
        //Sets the start of the audio at different times pero each enemy
        enemyVoiceAudio.PlayDelayed(Random.Range(0, 12));
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is near, the enemy runs towards him
        if (Vector3.Distance(player.transform.position, transform.position) <= detectionDistance)
        {
            enemyRb.velocity = transform.TransformDirection((player.transform.position - transform.position).normalized * speed);
        }

        //If the player is far, the enemy walks to a random position at a low-random speed
        if (Vector3.Distance(player.transform.position, transform.position) > detectionDistance)
        {
            enemyRb.velocity = transform.TransformDirection((randomPosition - transform.position).normalized * Random.Range(0, maxWalkingSpeed));
        }

        //Changes the position that the enemy walks towards after some seconds
        if (Time.time > nextChange)
        {
            nextChange = Time.time + changeRate;
            randomPosition = new Vector3(Random.Range(-48, 48), 0.5f, Random.Range(-48, 48));
        }
    }
}

