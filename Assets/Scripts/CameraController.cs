using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (player.transform.position[0] > 3.4f || player.transform.position[0] < -3.4f)
		{
			transform.position = player.transform.position + 1.2f * offset;
		}
		else
		{
			transform.position = player.transform.position + offset;	
		}
	}
}
