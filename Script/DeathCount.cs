using UnityEngine.UI;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    public PlayerMovement deathCount;
    public Text deathText;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {

        if ((FindObjectOfType<PlayerMovement>().gameOver))
        {
            deathCount = GameObject.Find("Player").GetComponent<PlayerMovement>();
            deathText.text = "Death Count : " + deathCount.deathCounts;
        }


    }

}