using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class BasketMove: MonoBehaviour
{
    public TMP_Text scoreText;
    private float speed;
    public float appleScore = 0;

    public void OnMouseMove(InputValue Value)
    {
        speed = Camera.main.ScreenToWorldPoint(Value.Get<Vector2>()).x;
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(speed, transform.position.y);
        scoreText.text = "Score: " + appleScore;
    }
}
