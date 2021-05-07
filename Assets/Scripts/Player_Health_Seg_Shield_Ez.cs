using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Seg_Shield_Ez : MonoBehaviour
{
    private GameObject respawn;

    private int playerScore;


    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 5;
    [Tooltip("The amount of points a player loses on death.")]
    public int deathPenalty = 20;

    public Text scoreText;


    public GameObject[] lifeArr;
    public GameObject[] shieldArr;



    private int maxLife;
    private int maxShield;
    private int currLife;
    private int currShield;

    // Use this for initialization
    void Start()
    {


        maxLife = lifeArr.Length;
        maxShield = shieldArr.Length;
        currShield = 0;
        currLife = maxLife;
        for (int i = 0; i < maxLife; i++)
        {
            lifeArr[i].SetActive(true);
        }
        for (int i = 0; i < maxShield; i++)
        {
            shieldArr[i].SetActive(false);
        }
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        //scoreText.text = playerScore.ToString("D1");

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(coinValue);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
        else if (collision.CompareTag("Health"))
        {
            AddHealth();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Shield"))
        {
            AddShield();
            Destroy(collision.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (currShield > 0)
        {
            shieldArr[currShield - 1].SetActive(false);
            --currShield;
        }
        else
        {
            lifeArr[currLife - 1].SetActive(false);

            --currLife;
            if (currLife == 0)
            {
                Respawn();
            }
        }

    }

    private void AddHealth()
    {
        if (currLife < maxLife)
        {
            lifeArr[currLife].SetActive(true);
            ++currLife;
        }

    }

    private void AddShield()
    {
        if (currShield < maxShield)
        {
            shieldArr[currShield].SetActive(true);
            ++currShield;
        }
    }

    public void Respawn()
    {

        while (currLife < maxLife)
        {
            lifeArr[currLife].SetActive(true);
            ++currLife;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        AddPoints(deathPenalty);
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddPoints(int amount)
    {
        playerScore += amount;
        scoreText.text = playerScore.ToString("D1");
    }

}

