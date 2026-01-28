using UnityEngine;
using UnityEngine.InputSystem; // You need this namespace!

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Get the current keyboard state
        var keyboard = Keyboard.current;
        if (keyboard == null) return; // No keyboard connected

        float h = 0;
        float v = 0;

        // Check for WASD or Arrow keys
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) v = 1;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) v = -1;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) h = -1;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) h = 1;

        Vector3 movement = new Vector3(h, 0, v);

        // Normalize to prevent faster diagonal movement
        if (movement.magnitude > 1) movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}