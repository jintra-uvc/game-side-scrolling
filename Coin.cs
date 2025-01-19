using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text scoreText;
    public int allCoin;
    public int currentCoin = 0;
    public string tagName = "Coin";

    private void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag(this.tagName);
        allCoin = coins.Length;
    }

    private void LateUpdate()
    {
        if (allCoin == currentCoin)
        {
            Debug.Log("You Won");

            //menu.SetActive(true);
            //label.text = "You Won";
        }
    }

    void onCollected(GameObject obj)
    {
        currentCoin++;
        scoreText.text = currentCoin.ToString();
        Destroy(obj);
        SoundManager.playSound("coinSound");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(this.tagName))
        {
            onCollected(collision.gameObject);
        }
    }
}