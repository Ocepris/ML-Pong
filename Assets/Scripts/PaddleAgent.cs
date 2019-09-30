using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;

public class PaddleAgent : Agent
{
    [SerializeField] Ball_Pong Ball;
    Rigidbody2D rBody;
    private void Start()
    {
        rBody = Ball.GetComponent<Rigidbody2D>();

    }

    public override void AgentReset()
    {
        Vector3 pos = transform.localPosition;
        pos.y = 0;
        transform.localPosition = pos;
        Ball.onReset();
    }

    public override void CollectObservations()
    {
        AddVectorObs(Ball.transform.localPosition);
        AddVectorObs(transform.localPosition);
        AddVectorObs(rBody.velocity.x);
        AddVectorObs(rBody.velocity.y);
    }

    float speed = 0.2f;
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        int action = Mathf.FloorToInt(vectorAction[0]);
        Vector3 pos = transform.position;

        if (action==0)
        {
            pos.y += 1 * speed;
        }
        if (action == 2)
        {
            pos.y -= 1 * speed;
        }
        transform.position = pos;

        pos = transform.localPosition;
        pos.y = Mathf.Clamp(pos.y, -4, 4);
        transform.localPosition = pos;
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ball"))
            AddReward(1f);
    }

    public void AlterReward(int reward)
    {
        float oldReward = GetReward();
        SetReward(oldReward + reward);
    }
}
