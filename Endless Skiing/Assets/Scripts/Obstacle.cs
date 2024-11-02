using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

    PlayerMovement playerMovement;
    [SerializeField] AudioClip deathSound; 

    private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            
            // Kill the player
            playerMovement.Die();
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }

    private void Update () {
	
	}
}