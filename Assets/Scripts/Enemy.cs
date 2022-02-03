using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private AudioSource enemyVoiceAudio;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyVoiceAudio = GetComponent<AudioSource>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyVoiceAudio.PlayDelayed(Random.Range(0, 12));
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = transform.TransformDirection((player.transform.position - transform.position).normalized * speed);
    }
}
