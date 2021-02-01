using UnityEngine.UI;   
using UnityEngine;

public class Scoring1 : MonoBehaviour
{
    public int score;
    int fastScore;
    Scoring realScore;
    public Text scoreText;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        realScore = GameObject.Find("Time").GetComponent<Scoring>();
        score = realScore.score;
        fastScore = realScore.newScore;
        
       
        scoreText.text = "Final Time : " + score.ToString() + "  |  Fastest Time : " + fastScore.ToString();

         
        
        

    }
}
