using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball_Pong : MonoBehaviour
{
    // Start is called before the first frame update
    bool started = false;
    Rigidbody2D rb;
    [SerializeField] TextMeshPro Score_Left = default;
    [SerializeField] TextMeshPro Score_Right = default;
    [SerializeField] PaddleAgent Agent_Left = default;
    [SerializeField] PaddleAgent Agent_Right = default;
    [SerializeField] bool autostart = false;
    [SerializeField] float speed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            }

    // Update is called once per frame
    void Update()
    {
        if (started)
            return;

        if (autostart || Input.GetKeyDown(KeyCode.Space))
            StartGame();
    
    }

    private void StartGame()
    {
        started = true;

        //Random value between 0 and 1
        var rnd = Random.value;
        rnd = Mathf.Floor(rnd + 0.5f);

        //Random direction (left or right)
        var direction = (Vector2.right * speed * rnd) + (Vector2.left * speed * (1 - rnd));
        //add tilt
        rb.AddForce(Vector2.up * ((Random.value - 0.5f) * 20));
        rb.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Right Agent scored
        if(collision.tag.Equals("Goal_Left"))
        {
            int score = int.Parse(Score_Right.text) + 1;
            Score_Right.text = "" + score;

            Agent_Left.AlterReward(-1);
            Agent_Right.AlterReward(1);
  
            ResetBall();
        }
        //Left Agent scored
        else if(collision.tag.Equals("Goal_Right"))
        {
            int score = int.Parse(Score_Left.text) + 1;
            Score_Left.text = "" + score;

            Agent_Left.AlterReward(1);
            Agent_Right.AlterReward(-1);

            ResetBall();
        }
    }

    public void ResetBall()
    {
        transform.localPosition = new Vector3(0,0,0);
        started = false;
    }

    public void onReset()
    {
        //Reset score
        Score_Left.text = "0";
        Score_Right.text = "0";

        ResetBall();
    }
}
