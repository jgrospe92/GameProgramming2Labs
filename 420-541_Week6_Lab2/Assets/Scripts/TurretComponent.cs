using UnityEngine;
using UnityEngine.UI;

public class TurretComponent : MonoBehaviour
{
    public float maxAngle = 45;
    private float damage = 0.1f;
    public Slider hpBar;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position- transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Debug.Log("angle " + angle);

        // rotation
        //Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up);
        //transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * 50);
        // using Euler
        transform.eulerAngles = Vector3.up * angle;
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
