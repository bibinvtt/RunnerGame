using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
    public float score = 0.0f;
    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 5;
    public int scoreToNextLevel = 10;
    public Text scoreText;
    void Start () {
        		
	}

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = "Score : " + ((int)score).ToString();

    }
    void LevelUp()
    {
        if (difficultyLevel > maxDifficultyLevel)
            return;
        difficultyLevel++;
        scoreToNextLevel *= 2;
        GetComponent<playerMotor>().SetSpeed(difficultyLevel);
    }
}
                                                            