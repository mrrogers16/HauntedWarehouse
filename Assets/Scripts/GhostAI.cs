using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAI : MonoBehaviour
{

    public Ghost followPlayer;
    public Player myPlayer;

    private void Update()
    {
        MoveTowardsFollowPlayer();
    }


    private void MoveTowardsFollowPlayer()
    {
        Vector3 direction = myPlayer.transform.position - followPlayer.transform.position;
        //direction.y = 0;
        direction.Normalize();
        followPlayer.Move(direction);
    }
}
