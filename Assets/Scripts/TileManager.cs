using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour {


	public GameObject[] TilePrefabs;
	public GameObject CurrentTile;
	public GameObject PowerUp;
	private static TileManager instance;
	private Stack<GameObject> leftTiles=new Stack<GameObject>();  
	private Stack<GameObject> topTiles=new Stack<GameObject>();

	
	public static TileManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<TileManager> ();
			}
			return instance;
		}
	}

	public Stack<GameObject> LeftTiles {
		get {
			return leftTiles;
		}
		set {
			leftTiles = value;
		}
	}

	public Stack<GameObject> TopTiles {
		get {
			return topTiles;
		}
		set {
			topTiles = value;
		}
	}

	// Use this for initialization
	void Start () {
		//leftTiles.Push (CurrentTile);
		CreateTiles(100);
		for (int i = 0; i < 50; i++) {
			spawnTile ();
		}
		StartCoroutine(typeHello());
	}

	public void CreateTiles(int amount)
	{
		for (int i = 0; i < amount; i++) {
			leftTiles.Push (Instantiate (TilePrefabs [0]));
			topTiles.Push (Instantiate (TilePrefabs [1]));
			topTiles.Peek ().name = "TopTile";
			topTiles.Peek ().SetActive (false);
			leftTiles.Peek ().name = "LeftTile";
			leftTiles.Peek ().SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator typeHello()
    {
		while (true)
        {
			print("Hello");
			yield return (new WaitForSeconds(10));
		}
		

    }
	public void spawnTile()
	{
		if (leftTiles.Count == 0 || topTiles.Count == 0) {
			CreateTiles (10);
		}
		int randomPowerUp = Random.Range(0, 5);
		int randomindex = Random.Range (0, 2);
		if (randomindex == 0) {
			GameObject tmp = leftTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = CurrentTile.transform.GetChild (0).transform.GetChild (0).position;
			CurrentTile = tmp;
		}

		else if (randomindex == 1) {
			GameObject tmp = topTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = CurrentTile.transform.GetChild (0).transform.GetChild (1).position;
			CurrentTile = tmp;
		}

		if (randomPowerUp == 1)
        {
			Instantiate(PowerUp, CurrentTile.transform.position, transform.rotation);
		}
		//CurrentTile= (GameObject)Instantiate(LeftTilePrefab, CurrentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
		//CurrentTile= (GameObject)Instantiate(TilePrefabs[randomindex], CurrentTile.transform.GetChild(0).transform.GetChild(randomindex).position, Quaternion.identity);
	}

    

    public void ResetGame()
	{
		SceneManager.LoadScene ("GameScene");
	}

    public void quit()
    {
		Application.Quit();
    }
}
