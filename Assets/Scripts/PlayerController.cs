using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float swipeSensitivity;
	private Rigidbody rb;
	private bool keyPressed = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); // get input for horizontal movement

		rb.velocity = new Vector3(0, 0, 1) * speed; // set the ball's default speed

		rb.AddForce(moveHorizontal * swipeSensitivity, 0, 0, ForceMode.Impulse); // move the ball left or right with an impulse force
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("obstacle"))
		{
			DestroySelf ();
		}
	}

	void DestroySelf ()
	{
		Destroy(gameObject);
		//rb.AddExplosionForce(10.0f, transform.position, 5.0f, 3.0f);
		Scene loadedLevel = SceneManager.GetActiveScene ();
     	SceneManager.LoadScene (loadedLevel.buildIndex);
	}
}
