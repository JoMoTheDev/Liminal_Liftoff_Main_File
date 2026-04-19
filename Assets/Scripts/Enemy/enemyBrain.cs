using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBrain : MonoBehaviour
{
    public Transform playerPos;
    public float moveSpeed;
    private float dist;

    private bool canChase = false;

    private Rigidbody rb;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update(){
        GetDistance();
        gameObject.transform.LookAt(playerPos);
        rb.AddRelativeForce(Vector3.forward * moveSpeed);
    }

    void FixedUpdate(){
        if(canChase){
            ChasePlayer();
        }
    }

    void GetDistance(){
        dist = Vector3.Distance(playerPos.position, transform.position);
    }

    void ChasePlayer(){
        rb.AddRelativeForce(Vector3.forward * moveSpeed);
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
    }

    IEnumerator Tick(){
        yield return new WaitForSeconds(0.1f);
    }
}
