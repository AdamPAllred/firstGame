using UnityEngine.UI;   
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int score;
    int interval = 1;
    float nextTime = 0;
    public int newScore;
    public Text scoreText;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x == 0 && player.transform.position.y == 0
                && player.transform.position.z == 0)
        {
            newScore = 0;
        }

        if (Time.time >= nextTime && !(FindObjectOfType<PlayerMovement>().gameOver))
        {
            score++;
            newScore++;

            scoreText.text = "Time : " + newScore.ToString();

            nextTime += interval;

        }
        else if ((FindObjectOfType<PlayerMovement>().gameOver))
        {
            scoreText.text = "";
        }
        

    }

}
