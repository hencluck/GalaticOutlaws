using UnityEngine;
using System.Collections;
using Pathfinding;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class EnemyAI : MonoBehaviour {


    //what to chase
    public Transform Target;

    //how many times a second we will upadte our path
    public float updateRate = 2f;

    //caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //the caluclated path
    public Path path;

    //The AI Speed per second
    public float speed = 300f;
    public ForceMode2D fMode;


    public Transform player;
    public float playerDistance;

    [HideInInspector]
    public bool pathIsEnded = false;


    //Max Distance between AI and next waypoint
    public float nextWayPointDistance = 3;

    //the way point we are moving towards
    private int currentWayPoint = 0;

    private bool searchingForPlayer =  false;

    void Update()
    {
        playerDistance = Vector3.Distance(Target.position, transform.position);
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

       
        if (Target == null)
        {
           if (!searchingForPlayer)
           {
               searchingForPlayer = true;
               StartCoroutine(SearchForPlayer());
            }
            return;
        }
    

       
        
            seeker.StartPath(transform.position, Target.position, OnPathComplete);
        
       

        StartCoroutine(UpdatePath());
     
    }

    IEnumerator SearchForPlayer()
    {
            GameObject sResult = GameObject.FindGameObjectWithTag("Player");
            if (sResult == null)
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(SearchForPlayer());
            }
            else
            {
                Target = sResult.transform;
                searchingForPlayer = false;
                StartCoroutine(UpdatePath());
                yield return false;
            }   
    }

    IEnumerator UpdatePath()
    {
        if (Target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
           yield return false;
        }

      
        
            seeker.StartPath(transform.position, Target.position, OnPathComplete);
        

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());

    }


    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path. Did it have an error? " + p.error);
        if (!p.error)
        {
           path = p;
           currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (Target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }
        if (path == null)
        {
            return;
        }

         if(currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End of Path Reached");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //direction to the next wayPoint
        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //move towards target
        if (playerDistance < 15f)
        {
            rb.AddForce(dir, fMode);
        }


        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);

        if (dist < nextWayPointDistance)
        {
            currentWayPoint++;
            return;
        }


    }




}
