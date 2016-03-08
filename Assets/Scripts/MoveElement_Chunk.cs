using UnityEngine;
using System.Collections;

public class MoveElement_Chunk : MonoBehaviour
{     
	void Start ()
	{
				
	}
         
	void Update ()
	{
		if (!AndroidGuy.get.IsDead) {
			transform.Translate (GameManager.moveVector * GameManager.get.speed * Time.deltaTime);
		}

	}

	void FixedUpdate ()
	{

		if (transform.position.x > 110)
			GameManager.get.DestroyChunk (this);
	}
 
}
   