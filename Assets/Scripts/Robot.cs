using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private string robotType; //the type of robots

    public int health;  //how much damage this robot can take before dying
    public int range;   //the distance the gun can fire
    public float fireRate;  //how fast if can fire

    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;

    private Transform player;
    private float timeLastFired;

    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }

        transform.LookAt(player);

        agent.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) < range && Time.time -timeLastFired >fireRate)
        {
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        Debug.Log("Fire");
    }
}
