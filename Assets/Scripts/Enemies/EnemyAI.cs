using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform enemyObj;
    private Animator _enemyAnim;

    public float speed = 30f;
    public float nextWaypointDistance = 4f;

    public Path path;
    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    private Seeker _seeker;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        _enemyAnim = enemyObj.gameObject.GetComponent<Animator>();
        _enemyAnim.SetFloat("Speed",0f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (_seeker.IsDone())
        {
            _seeker.StartPath(_rb.position, target.position, OnPathComplite);
        }
    }

    void OnPathComplite(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    
    void FixedUpdate()
    {
        if (path == null)
            return;
        
        

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        
        
        float patchDistance = Vector2.Distance(target.position, _rb.position);
        if (patchDistance >= 12f)
            return;

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        
        if (force.x >= 0f || force.x < 0f)
        {
            enemyObj.localPosition = new Vector3(force.x >= 0f ? -.2f : .2f,.1f,.1f);
            _enemyAnim.SetFloat("Speed",force.x >= 0f ? -.2f : .2f);
        }/* else if (force .y <= -0.1f)
        {
            enemyObj.localPosition = new Vector3(.1f,.1f,.1f);
            _enemyAnim.SetFloat("Speed",.1f);
        }*/
    }
}
