using UnityEngine;

public class AppleScore : MonoBehaviour
{
    public Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = -1f - (Time.deltaTime);
    }
    public void basketDestroy(){
        GameObject basket = GameObject.Find("Baskets");
        if (basket != null)
        {
            Transform childTransform = basket.transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            if (basket.transform.childCount == 1)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
            Destroy(childObject);
        }
        else
        {
            Debug.LogWarning("Basket object not found!");
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Boundary"))
        // {
        //     AppleController appleController = GameObject.Find("AppleController").GetComponent<AppleController>();
        //     appleController.numApples--;
        // }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Gold"))
            {
                // Increase score by 500 for gold apples
                // ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
                // collision.GetComponent<BasketMove>().appleScore += 500;
            }
            else if (gameObject.CompareTag("Unripe"))
            {
                // Increase score by 50 for green apples
                // ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
                // collision.GetComponent<BasketMove>().appleScore += 50;
            }
            else if (gameObject.CompareTag("Rot"))
            {
                basketDestroy();
            }
            else
            {
                // Increase score by 100 for regular apples
                // ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
                // collision.GetComponent<BasketMove>().appleScore += 100;
            }
            //ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (!gameObject.CompareTag("Rot"))
            {
                basketDestroy();
            }
            Destroy(gameObject);
        }
    }
}
