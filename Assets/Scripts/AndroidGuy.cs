using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AndroidGuy : MonoBehaviour {
	public GameObject youlose;
	public int side;
	public bool IsDead = false;
	Vector3 newPos;
	float deadTime;
	bool jumped = false;
	public static AndroidGuy get;

	public void GoLeft ()
	{
		if (IsDead)
			return;
		side = Mathf.Max (0, side - 1);

	}
	public void GoRight ()
	{
		if (IsDead)
			return;
		side = Mathf.Min (2, side + 1);
	}
	public void Die(){
		if (!IsDead) {
			deadTime = Time.time;
			IsDead = true;
		}
	}
 	void Start () {
		get = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.get.IsPaused) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.Q)) {
			GoLeft ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			GoRight ();
		} 
		if (!IsDead) {
			Vector3 oldPos = transform.position;
			newPos = new Vector3 (oldPos.x, oldPos.y, GameManager.get.BigPath / 2f + side * GameManager.get.SmallPath);
			
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * 10);

		} else {

			if(transform.position.z<2 && !jumped){
				Rigidbody rb = gameObject.AddComponent<Rigidbody>();
				rb.AddForce(new Vector3(0, 1, -1)*350);
				jumped=true;
				youlose.SetActive(true);
			}else{
				transform.RotateAround(new Vector3(0,0,-10),Vector3.up,-Time.deltaTime*20f);
			}
		}

	}

	 
}
