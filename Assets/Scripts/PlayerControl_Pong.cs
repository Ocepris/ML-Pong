using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Pong : MonoBehaviour
{
    //Player 1 and 2
    [SerializeField] GameObject p1 = default;
    [SerializeField] GameObject p2 = default;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        p1.transform.position += Vector3.up * 5 * Input.GetAxis("Vertical") *Time.deltaTime;
        p2.transform.position += Vector3.up * 5 * Input.GetAxis("Vertical") * Time.deltaTime;

        var pos = p1.transform.position;
        pos.y = Mathf.Clamp(pos.y, -5, 5);
        p1.transform.position = pos;

        pos = p2.transform.position;
        pos.y = Mathf.Clamp(pos.y, -5, 5);
        p2.transform.position = pos;

    }

}
