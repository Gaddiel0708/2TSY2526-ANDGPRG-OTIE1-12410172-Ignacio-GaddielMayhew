using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab; // Drag your Sphere Prefab here in the Inspector
    public float fireForce = 1000f;

    void Update()
    {
        // 1. Mouse Tracking with a Ground Plane check
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // An imaginary flat floor
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 pointToLookAt = ray.GetPoint(rayDistance);

            // This calculates the direction from the cannon to the mouse
            Vector3 direction = (pointToLookAt - transform.position).normalized;

            // Create the rotation and apply it
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
        }

        // 2. Shooting Logic
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * fireForce);
        }
    }
}