using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*speed,rb.velocity.y,0);
        rb.velocity = move;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Fruit"))
        {
            GameManager.Instance.UpdateScore();
            ScoreText.text = "Score: " + GameManager.Instance.score;
            Destroy(collision.gameObject);
        }
    }
}
