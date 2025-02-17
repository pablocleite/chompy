using Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : PlayerBehavior
{
    [SerializeField]
    private PlayerBehavior playerObject;
    
    private Transform[] pills;
    
    private NavMeshAgent _navMeshAgent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            return;
        }

        Vector3 destination = Vector3.zero;

        if (this.Size <= playerObject.Size)
        {
            // Method below is expensive and could benefit from different approaches, like
            // Become aware of all pills in the field and receive notification when a pill is consumed
            // Recalculating the route only when needed. Also enemy should not be able to "see" the entire board
            // as its like it's cheating so a max distance radius should be applied and it should chase food instead
            var nearestPill = FindNearestPill();
            destination = nearestPill?.transform.position ?? Vector3.zero;
        }
        
        if (destination == Vector3.zero)
        {
            destination = playerObject.transform.position;
        }
        
        _navMeshAgent.SetDestination(destination);
    }
    
    private GameObject FindNearestPill()
    {
        var pills = GameObject.FindGameObjectsWithTag("Pill");
        
        if (pills.Length == 0) { return null; }
        
        GameObject nearest = null;
        var minDistance = Mathf.Infinity;
        var currentPos = transform.position;

        foreach (GameObject pill in pills)
        {
            var dist = Vector3.Distance(currentPos, pill.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = pill;
            }
        }

        return nearest;
    }
}
