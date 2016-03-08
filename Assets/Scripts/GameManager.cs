using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	static public GameManager get;
	public int score = 0;
	public Text scoreUI;
	public float speed = 30;
	public float SpeedAmount = 1;
	public float SpeedInterval = 5;

	public Text spendingUI;
	public int spending = 1;
	public int spendingAmount = 1;
	public float spendingInterval = 5;

	public bool randomize = true;
	public GameObject[] chunks;
	
	public float BigPath = 20f;
	public float SmallPath = 10f;
	public  float pathSize = 10f;

	public bool IsPaused = false;
	static public float chunkSize = 50;
	static public Vector3 moveVector = new Vector3(1, 0, 0);
	static public GameObject lastChunk;
	int id;

	// Use this for initialization
	void Awake(){
		get = this;
		id = 0;
		for (int i = 0; i < 5; i++)
		{
			GameObject obj = InstantiateChunk();
			obj.transform.position = new Vector3(-i * chunkSize, 0, 0);
			
			lastChunk = obj;
		}
	}
	void Start () {
		InvokeRepeating ("IncreaseSpeed", SpeedInterval, SpeedInterval);
		InvokeRepeating ("IncreaseSpending", spendingInterval, spendingInterval);
		InvokeRepeating ("DecreaseScore", 1f, 1f);
	}
	void IncreaseSpeed(){
		speed += SpeedAmount;
	}
	void IncreaseSpending(){
		spending += spendingAmount;
	}
	void DecreaseScore(){
		score -= spending;
		if (score <= 0) {
			CancelInvoke();
			speed=0;
			AndroidGuy.get.Die();
			print("Broke");
			Camera.main.gameObject.GetComponent<PlayerCamera> ().LockTarget = true;
		}
	}
	GameObject InstantiateChunk()
	{
		
		if (randomize) {
			return (GameObject)Instantiate(chunks[Random.Range(0, chunks.Length)]);
			
		} else {
			id = ( id + 1 ) % chunks.Length;
			return (GameObject)Instantiate(chunks[id]);
		}
		
	}
	public void DestroyChunk(MoveElement_Chunk moveElement)
	{
		Vector3 newPos = lastChunk.transform.position;
		newPos.x -= chunkSize;
		
		Destroy(moveElement.gameObject);
		
		lastChunk = InstantiateChunk();
		lastChunk.transform.position = newPos;
	}

	// Update is called once per frame
	void Update () {
		scoreUI.text = "Money : $" + score;
		spendingUI.text = "Spending : $" + spending;
	}
}
