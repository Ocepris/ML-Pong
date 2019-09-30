using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactRedirector : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ball"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            
            //Get Collision point on paddle
            var contactPoint = collision.GetContact(0);
            float cpY = contactPoint.point.y;
            float y = transform.position.y;

            //sets the y cord at the top of the paddle
            y += transform.localScale.y/2;
            
            //Normalized impact point
            float nImapact = (y - cpY) / transform.localScale.y; 
            
            //Redirects the ball in dependence of the impact point
            if(nImapact<0.2f)
            {
                contactPoint.rigidbody.AddForce(Vector2.up * 80f);
            }
            else if (nImapact < 0.4f)
            {
                contactPoint.rigidbody.AddForce(Vector2.up * 60f);
            }
            else  if (nImapact < 0.6f)
            {
            }
            else if (nImapact < 0.8f)
            {
                contactPoint.rigidbody.AddForce(Vector2.up * -60f);
            }
            else if (nImapact < 1)
            {
                contactPoint.rigidbody.AddForce(Vector2.up * -80f);
            }

        }
    }
}
