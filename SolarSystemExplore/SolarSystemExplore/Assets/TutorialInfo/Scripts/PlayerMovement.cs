using UnityEngine;
using UnityEngine.InputSystem; // 1. Added this to use the new system

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // 2. Read input from the keyboard (WASD or Arrow Keys)
        Vector2 inputVector = Vector2.zero;

        if (Keyboard.current != null)
        {
            // This reads WASD and Arrow keys automatically
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) inputVector.y = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) inputVector.y = -1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) inputVector.x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) inputVector.x = 1;
        }

        // 3. Convert that input into a 3D movement vector
        // Note: Vertical input (W/S) moves the player along the Z axis (forward/back)
        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);

        // 4. Move the player
        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
    }
}