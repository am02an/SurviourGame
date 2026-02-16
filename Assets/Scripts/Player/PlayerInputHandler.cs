using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerController playerController;
    public Joystick joystick;

    void Update()
    {
        Vector3 input = new Vector3(
            joystick.Horizontal,
            0,
            joystick.Vertical
        );

        playerController.SetMovementInput(input);
    }
}
