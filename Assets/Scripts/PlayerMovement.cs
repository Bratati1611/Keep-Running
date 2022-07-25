using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Vector3 dir;
	private bool isDead;
	public GameObject resetButton;
	public GameObject quitButton;
	public int score = 0;
	public Text Scoretext;
	// Use this for initialization
	void Start () {
		isDead = false;
		dir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !isDead) {
			//score+=2;
			
			if (dir == Vector3.forward)
				dir = Vector3.left;
			else
				dir = Vector3.forward;
		}

		float amountToMove = speed * Time.deltaTime;
		transform.Translate (dir * amountToMove);
	}

	public Transform mainCamera;
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Tile") 
		{
			RaycastHit hit;
			Ray downRay = new Ray (transform.position, -Vector3.up);
			if(!Physics.Raycast(downRay, out hit))
			{
				isDead = true;
				resetButton.SetActive(true);
				quitButton.SetActive(true);
				if(transform.childCount>0)
					transform.GetChild(0).transform.parent = null;
			}
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag == "Powerups")
		{
			print("Collision Entered");
			Destroy(collision.gameObject);
			score++;
			print(score);
			Scoretext.text = score.ToString();
		}

	}

}
