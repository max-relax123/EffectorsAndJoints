using UnityEngine;
using UnityEngine.InputSystem;

public class CarController2D : MonoBehaviour
{
    [Header("Настройки колес")]
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    [Header("Параметры движения")]
    public float motorSpeed = 1000f;
    public float maxMotorTorque = 10000f;

    private JointMotor2D motor;
    private float moveInput;

    void Start()
    {
        motor = new JointMotor2D { maxMotorTorque = maxMotorTorque };
    }

    void Update()
    {
        moveInput = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed) moveInput += 1f;
            if (Keyboard.current.aKey.isPressed) moveInput -= 1f;
        }
    }

    void FixedUpdate()
    {
        if (moveInput != 0)
        {
            motor.motorSpeed = -moveInput * motorSpeed;

            backWheel.useMotor = true;
            frontWheel.useMotor = true;

            backWheel.motor = motor;
            frontWheel.motor = motor;
        }
        else
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
    }
}
