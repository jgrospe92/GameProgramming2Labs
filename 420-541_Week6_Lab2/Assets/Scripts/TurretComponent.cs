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

        Debug.DrawRay(transform.position, direction, Color.green);

 
        float angle = Mathf.Acos(Vector3.Dot(direction.normalized, transform.forward.normalized)) * Mathf.Rad2Deg;

        Debug.Log("angle: " + angle);

        if (angle <= maxAngle)
        {
            Debug.Log("kill");
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }

        //// rotation
        ////Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up);
        ////transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * 50);
        //// using Euler
      //transform.eulerAngles = Vector3.up * angle;
        //transform.rotation = Quaternion.LookRotation(Vector3.forward * angle);

        //float d = Vector3.Dot(transform.forward, player.forward);
        //float a = Mathf.Acos(d) * Mathf.Rad2Deg;
      
        
    }

    // todo make a method to rotate the turrent 45 deg towards the player

    public void decreaseHp()
    {
       
        if (hpBar.value <= 1)
        {
            hpBar.value += damage;
        }
    }
}
