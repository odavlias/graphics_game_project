using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float swipeSensitivity;
	private float boostSpeed;
	private Rigidbody rb;
	private int boostRank = 0;
	private int maxBoostRank = 2;
	private int minBoostRank = -2;
	private float rankWeight = 1;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); // get input for horizontal movement
		if (boostRank == 0)
		{
			rankWeight = 1.0f; // set the ball's default speed
		}
		else if (boostRank == 1)
		{
			rankWeight = 1.2f; // first rank boost
		}
		else if (boostRank == 2)
		{
			rankWeight = 1.5f; // second rank boost
		}
		else if (boostRank == -1)
		{
			rankWeight = 0.8f;
		}
		else if (boostRank == -2)
		{
			rankWeight = 0.5f;
		}
		
		rb.velocity = new Vector3(0, 0, 1) * rankWeight * speed;
		rb.AddForce(moveHorizontal * swipeSensitivity, 0, 0, ForceMode.Impulse); // move the ball left or right with an impulse force
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("obstacle"))
		{
			DestroySelf ();
		}

		if (other.gameObject.CompareTag("accelerator"))
		{
			if (boostRank <= maxBoostRank)
			{
				boostRank += 1;
			}
		}

		if (other.gameObject.CompareTag("decelerator"))
		{
			if (boostRank >= -2)
			{
				boostRank -= 1;
			}
		}
	}

	void DestroySelf ()
	{
		Destroy(gameObject);
		//rb.AddExplosionForce(10.0f, transform.position, 5.0f, 3.0f);
		Scene loadedLevel = SceneManager.GetActiveScene ();
     	SceneManager.LoadScene (loadedLevel.buildIndex);
	}

	void Boost ()
	{
		rb.velocity = new Vector3(0, 0, 1) * boostSpeed;
	}
}
