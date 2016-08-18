using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText scoreText;

	private bool gameOver;
	private bool restart;
	private int score;


	void Start() 
	{
		//Turn off gameOver and restart flags
		gameOver = false;
		restart = false;

		//Deactivate text objects
		restartText.text = "";
		gameOverText.text = "";

		//Initialize score to 0
		score = 0;
		UpdateScore ();

		//Start Spawning Waves
		StartCoroutine(SpawnWaves ());
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}
	IEnumerator SpawnWaves()
	{
		
		yield return new WaitForSeconds (startWait);
		while(true) 
		{
			for(int i = 0; i<hazardCount;++i)
			{
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}

	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
