using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject enemy;
    public GameObject jumpBoost;
    public GameObject shieldBoost;
    public GameObject normal;
    public GameObject speedBoost;
    public int deathCounts;
    public int rateOfSpawn;
    int speedBoostCount = 0;
    bool jumpBoostTime = false;
    int jumpBoostCount = 0;
    int shieldBoostCount = 0;
    bool shieldBoostTime = false;
    public int jumpSpeed;
    public int moveSpeed;
    public bool onGround = false;
    public Transform spawnPoint;
    public Transform playerLocation;
    public int enemyCount;
    int randomInt;
    float xPos;
    public bool gameOver;
    public GameObject completeLevelUI;
    int interval = 1;
    float nextTime = 0;




    void Update()
    {
        if (Time.time >= nextTime && !(FindObjectOfType<PlayerMovement>().gameOver))
        {
            if (jumpBoostCount <= 0)
            {
                jumpBoostTime = false;
            }
            else {
                jumpBoostCount--;
            }
            if (shieldBoostCount <= 0)
            {
                shieldBoostTime = false;
            }
            else
            {
                shieldBoostCount--;
            }
            if (speedBoostCount > 0)
            {
                moveSpeed = 2500;
                speedBoostCount--;
            }
            else
            {
                moveSpeed = 1750;
            }

            nextTime += interval;

        }
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("space") && onGround)
        {
            if (jumpBoostTime == true)
            {
                rb.AddForce(Vector3.up * 25, ForceMode.Impulse);
                
            }
            else
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
            onGround = false;
        }
        if (Input.GetKey("e"))
        {
            rb.AddForce(0, 0, 0);
        }

        if (!(gameOver)) {
            xPos = Random.Range(-4.75f, 4.75f);
            randomInt = Random.Range(1, rateOfSpawn);
            if (randomInt == 2)
            {
                Instantiate(enemy, new Vector3(xPos, 51, 106), Quaternion.identity);
            }
            randomInt = Random.Range(1, 600);
            if (randomInt == 1)
            {
                Instantiate(shieldBoost, new Vector3(xPos, 51, 106), Quaternion.identity);
            }
            if (randomInt == 2)
            {
                Instantiate(jumpBoost, new Vector3(xPos, 51, 106), Quaternion.identity);
            }
            if (randomInt == 3 || randomInt == 4)
            {
                Instantiate(normal, new Vector3(xPos, 51, 106), Quaternion.identity);
            }
            if (randomInt == 5)
            {
                Instantiate(speedBoost, new Vector3(xPos, 51, 106), Quaternion.identity);
            }
        }

        if (gameOver)
        {
            completeLevelUI.SetActive(true);
        }

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        onGround = true;
        if (collisionInfo.collider.tag == "Enemy")
        {
            if (shieldBoostTime == true)
            {
                return;
            }
            else
            {
                playerLocation.transform.position = spawnPoint.transform.position;
                deathCounts++;
                jumpBoostTime = false;
                shieldBoostTime = false;
            }
        }
        if (collisionInfo.collider.tag == "OutOfBounds")
        {
            playerLocation.transform.position = spawnPoint.transform.position;
            deathCounts++;
            jumpBoostTime = false;
            shieldBoostTime = false;
        }
        if (collisionInfo.collider.name == "FinishLine")
        {
            gameOver = true;
        }
        if (collisionInfo.collider.tag == "JumpBoost")
        {
            jumpBoostTime = true;
            jumpBoostCount = 5;
        }
        if (collisionInfo.collider.tag == "ShieldBoost")
        {
            shieldBoostTime = true;
            shieldBoostCount = 3;
        }
        if (collisionInfo.collider.tag == "SpeedBoost")
        {
            speedBoostCount = 5;
        }
    }
}
