using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	private float fallDelay=1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			//Debug.Log ("Spawn tiles");
			TileManager.Instance.spawnTile ();
			StartCoroutine (fallDown ());
		}
	}
	 
	IEnumerator fallDown()
	{
		yield return new WaitForSeconds (fallDelay);
		//GetComponent<Rigidbody> ().isKinematic = false;
		this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		yield return new WaitForSeconds (2);
		switch (gameObject.name) {

		case "LeftTile":
			TileManager.Instance.LeftTiles.Push (gameObject);
			//this.GetComponent<Rigidbody> ().iskinematic = true;
			this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			break;

		case "TopTile":
			TileManager.Instance.TopTiles.Push (gameObject);
			//this.GetComponent<Rigidbody> ().iskinematic = true;
			this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			break;
		}
	}
}
