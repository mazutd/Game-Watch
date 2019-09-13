using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startLives = 3;
    int points = 0;
	public int newLevelPoints  = 3; 
	int startLevel = 1;
	int lastLevel;
	public TextMeshPro scoreText;
	public TextMeshPro Level;
	public LivesController livesController;

    void OnEnable()
	{
		JumperController.OnJumperCrash += JumperCrashed;
		JumperController.OnJumperSave += JumperSaved;
	}

	void OnDisable()
	{
		JumperController.OnJumperCrash -= JumperCrashed;
		JumperController.OnJumperSave -= JumperSaved;
	}

    void Start()
	{
		UpdateScoreLabel();
		livesController.InitLives(startLives);
		float speed = gameObject.GetComponent<JumperSpawner>().randomSpawnDelay;
	}


	public void JumperCrashed()
	{
		if (!livesController.RemoveLife() )
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
			Debug.Log("GAME OVER!");
		}
	}

    public void JumperSaved()
	{
		points++;
		UpdateScoreLabel();
		

	}

    void UpdateScoreLabel()
	{
		Debug.Log(lastLevel);
		if(points == lastLevel+newLevelPoints){
			startLevel = startLevel+1;
			Level.text = (startLevel).ToString();
			lastLevel = points;
			JumperSpawner jSwaner = gameObject.GetComponent<JumperSpawner>();
			Debug.Log(jSwaner.randomSpawnDelay);
			jSwaner.randomSpawnDelay =Mathf.Clamp( jSwaner.randomSpawnDelay-0.5F, 0, 100);

		}
		scoreText.text = points.ToString();
	}

}
