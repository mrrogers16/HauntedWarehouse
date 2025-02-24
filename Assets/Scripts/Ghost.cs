using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public float gravity = -9.8f;
    public float jumpSpeed = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
        if (direction == Vector3.zero)
        {
            return;
        }
        transform.LookAt(transform.position + direction);
    }
}
