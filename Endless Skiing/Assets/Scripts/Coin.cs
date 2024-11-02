using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;
    [SerializeField] AudioClip pickupSound;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        AudioSource.PlayClipAtPoint(pickupSound, transform.position);


        // Destroy this coin object
        Destroy(gameObject);
    }

    private void Start () {

	}

	private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
	}
}