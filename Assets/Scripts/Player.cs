using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{

    CharacterController characterController;

    [Header("Movement")]
    public float speed = 2f;
    public float gravity = -12f;
    public float jumpSpeed = 10f;

    [Header("Inventory")]
    public int treasuresCollected = 0;

    [Header("Audio")]
    public AudioSource pickupAudioSource;
    public AudioClip pickupSound;
    public AudioClip winSound;

    [Header("Environment")]
    public LayerMask jumpLayers;
    public Transform groundCheckTransform;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        ApplyGravityToCC();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Treasure"))
        {
            CollectTreasure(other.gameObject);
        }
        if (other.CompareTag("Ghost"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void CollectTreasure(GameObject treasure)
    {
        treasuresCollected++;

        pickupAudioSource.clip = pickupSound;
        pickupAudioSource.Play();

        Destroy(treasure);
        Debug.Log("Treasure collected! Total: " + treasuresCollected);

        if (treasuresCollected == 3)
        {
            StartCoroutine(WinRestart());
        }
    }

    private IEnumerator WinRestart()
    {
        yield return new WaitForSeconds(1f);
        pickupAudioSource.Stop();
        pickupAudioSource.clip = winSound;
        pickupAudioSource.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    Vector3 gravityVelocity = Vector3.zero;

    void ApplyGravityToCC()
    {
        if (characterController.isGrounded && gravityVelocity.y < 0)
        { //TODO use a spherecast instead!
            gravityVelocity = Vector3.zero;
            return;
        }
        gravityVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
    }
    public void MoveWithCC(Vector3 direction)
    {
        characterController.Move(direction * speed * Time.deltaTime);
        transform.LookAt(transform.position + direction);
    }

    // public void MoveWithRB(Vector3 direction)
    // {
    //     GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

    //     transform.LookAt(transform.position + direction);
    // }
    // public bool CreatureOnGround()
    // {
    //     return Physics.OverlapSphere(groundCheckTransform.position, 0.5f, jumpLayers).Length > 0;
    // }
    // public void Move(Vector3 direction)
    // {
    //     transform.position += direction * speed * Time.deltaTime;
    //     if (direction == Vector3.zero)
    //     {
    //         return;
    //     }
    //     transform.LookAt(transform.position + direction);
    // }



}
