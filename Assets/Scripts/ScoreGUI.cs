using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGUI : MonoBehaviour
{
    public float highScore;



    private void Awake()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0);
    }

    
    public void FixedUpdate()
    {
      if (highScore < Character.characterInstance.finalScore)
      {
        PlayerPrefs.SetFloat("highScore", Character.characterInstance.finalScore);
      }
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(330,10,120,20), "Score: " + Character.characterInstance.finalScore.ToString());
        GUI.Box(new Rect(340,30,110,20), "High Score: " + highScore);
    }
}
