using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * 0.5f, 0f, 0f);
    }
}
