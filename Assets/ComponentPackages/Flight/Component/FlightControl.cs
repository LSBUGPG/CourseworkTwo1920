using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public float maxSpeed = 340.0f;
    public float climbAngle = 20.0f;
    public float bankAngle = 20.0f;

    float climb = 0.0f;
    float bank = 0.0f;

    public Vector2 range = new Vector2(50.0f, 30.0f);

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        climb = -Mathf.Clamp(
            vertical * climbAngle,
            -climbAngle,
            climbAngle);

        bank = -Mathf.Clamp(
            horizontal * bankAngle,
            -bankAngle,
            bankAngle);

        transform.rotation = Quaternion.Euler(climb, 0.0f, bank);
        
        Vector3 movement =
            Vector3.left * bank +
            Vector3.down * climb;

        Vector3 position = transform.position + movement * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -range.x, range.x);
        position.y = Mathf.Clamp(position.y, -range.y, range.y);

        transform.position = position;
    }
}
