
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{

    public GameObject playerObject;
    public Transform cameraTransform;
    public float gravity = -9.8f;


    void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Player player = playerObject.GetComponent<Player>();

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;

        Vector3 finalMovement = Vector3.zero;


        if (Input.GetKey(KeyCode.W))
        {
            finalMovement += cameraForward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            finalMovement -= cameraForward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            finalMovement -= cameraRight;
        }
        if (Input.GetKey(KeyCode.D))
        {
            finalMovement += cameraRight;
        }

        finalMovement.Normalize();
        player.MoveWithCC(finalMovement);

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     player.Jump();
        // }

    }
}