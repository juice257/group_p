using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
=======
public class Log : Enemy {

>>>>>>> parent of 8ef578b2 (Part 20)
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform Origin;
    public Animator anim;
    // Start is called before the first frame update
<<<<<<< HEAD
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
=======
    void Start() {
>>>>>>> parent of 8ef578b2 (Part 20)
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
<<<<<<< HEAD
    void FixedUpdate() {
        CheckDistance();
    }

    void CheckDistance()
    { 
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
               target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
                
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
=======
    void Update()
    {
        CheckDistance();       
    }

    void CheckDistance() {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector3.MoveTowards(transform.position, 
            target.position, moveSpeed * Time.deltaTime);

>>>>>>> parent of 8ef578b2 (Part 20)
        }
    }
        private void SetAnimFloat(Vector2 setVector) {
            anim.SetFloat("moveX", setVector.x);
            anim.SetFloat("moveY", setVector.y);
        }
        private void changeAnim(Vector2 direction) {
            //Debug.Log(anim);
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0) {
                    SetAnimFloat(Vector2.left);
                } else if (direction.x < 0)
                {
                    SetAnimFloat(Vector2.right);
                }
            } else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
                if (direction.y > 0)
                {
                    SetAnimFloat(Vector2.up);
                } else if (direction.y < 0)
                {
                    SetAnimFloat(Vector2.down);
                }
            }
        }
        private void ChangeState(EnemyState newState) {
            if (currentState != newState)
            {
                currentState = newState;
            }
        }
    }