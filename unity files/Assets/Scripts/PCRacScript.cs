using UnityEngine;

public class PCRacScript : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    float x;
    float y;
    float z;

    private void Awake()
    {
        y = transform.position.y;
        z = transform.position.z;
    }
    private void Update()
    {
        x = ball.transform.position.x;
        transform.position = new Vector3(x, y, z);
    }
}
