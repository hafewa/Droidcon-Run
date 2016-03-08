 
using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public Transform target;
	public bool LockTarget = false;

	void Start ()
	{
		InitialPos = transform.position;
	}

	private Vector3 InitialPos;
	// Update is called once per frame
	void Update ()
	{
		Vector3 newPos = InitialPos;
		newPos.z = AndroidGuy.get.transform.position.z;

		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * 8);
		if (LockTarget) {
			transform.LookAt(target);
		}
	}

          
}
   