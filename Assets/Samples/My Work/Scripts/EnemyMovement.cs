
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindGameObjectWithTag("BaseAttack");
        if(player != null)
        {
            playerTransform = player.transform;
        }

        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }


    void Update()
    {

    }
}
