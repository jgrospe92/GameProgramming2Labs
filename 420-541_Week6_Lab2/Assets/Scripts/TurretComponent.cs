using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class TurretComponent : MonoBehaviour
{
    public float maxAngle = 45f;
    private float damage = 0.1f;
    public Slider hpBar;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // direction to face
        Vector3 direction = player.position - transform.position;

        //Debug.DrawRay(transform.position, direction, Color.green);

        float dot = Vector3.Dot(transform.forward, player.transform.position.normalized);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        Debug.Log("angle: " + angle);

        if (angle <= maxAngle)
        {
            Debug.Log("kill");
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }

        // revert to center
        //Quaternion targetRotation1 = Quaternion.LookRotation(-Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation1, 5f * Time.deltaTime);

    }

    public void decreaseHp()
    {
       
        if (hpBar.value <= 1)
        {
            hpBar.value += damage;
        }
    }
}
