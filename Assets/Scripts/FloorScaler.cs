using UnityEngine;
using System.Collections;
 public class FloorScaler : MonoBehaviour {

	// Use this for initialization
	public GameObject[] FloorParts;
	public GameObject CoinPrefab;

	void Start () {
		for (int i=0; i<10-GameManager.get.speed/10f; i++) {
			if(Random.Range (0, 10)>0){
				int randomSide = Random.Range (0, 3);
				GameObject newCoin  = (GameObject)Instantiate(CoinPrefab);
				newCoin.transform.SetParent(FloorParts[randomSide].transform);
				newCoin.transform.localPosition = new Vector3(i*10, 1,5);
				//newCoin.transform.lossyScale = new Vector3(1,1,1);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for (int i= 0; i<  FloorParts.Length; i++) {
			 
			Vector3 newScale = FloorParts[i].transform.localScale;
			if(i==AndroidGuy.get.side){
				newScale.z = GameManager.get.BigPath/GameManager.get.pathSize;
			}else{

				newScale.z = GameManager.get.SmallPath/GameManager.get.pathSize;
			}
			FloorParts[i].transform.localScale = Vector3.Lerp(FloorParts[i].transform.localScale, newScale, Time.fixedDeltaTime * 10);
		}
		float startPos = 0f;
		for (int i=0; i<FloorParts.Length; i++) {
			Vector3 newPos = FloorParts[i].transform.localPosition;
			newPos.z = startPos;
			FloorParts[i].transform.localPosition = newPos;
			startPos += (FloorParts[i].transform.localScale.z) * GameManager.get.pathSize;
		}
	}
}
