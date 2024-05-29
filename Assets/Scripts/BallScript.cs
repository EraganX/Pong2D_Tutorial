using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text aiScoreText;

    private int playerScore;
    private int AiScore;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, Random.Range(-0.25f, +0.25f)) * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                float changeDir1 = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
                rb.velocity = new Vector2(1, changeDir1) * speed;
                break;
            case "Ai":
                float changeDir2 = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
                rb.velocity = new Vector2(-1, changeDir2) * speed;
                break;
            case "GoalAI":
                ResetBall(false);
                break;
            case "GoalPlayer":
                ResetBall(true);
                break;
        }
    }

    private void ResetBall(bool isPlayerGoal)
    {
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        if (isPlayerGoal)
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            rb.velocity = new Vector2(-1,Random.Range(-0.25f,+0.25f)) * speed;

        }
        else
        {
            AiScore++;
            aiScoreText.text = AiScore.ToString();
            rb.velocity = new Vector2(1, Random.Range(-0.25f, +0.25f)) * speed;
            //rb.velocity = Vector2.right * speed;
        }

        Invoke(nameof(EnableTrail), 0.3f);
    }

    private void EnableTrail()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
}
