using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Animator anim;
    private MovementManager movement;
    private GameObject armPunch;
    private Collider2D armPunchCollider;
    private Collider2D bodyCollider;

    [SerializeField] private int enemyLane;

    [SerializeField] private float raycastY;

    public int health = 20;
    RaycastHit2D playerHit;
    RaycastHit2D enemyHit;
    [SerializeField] private float raycastDist;
    private float raycastStartX;
    private Vector3 raycastDir;
    
                 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<MovementManager>();
        armPunchCollider = GetComponent<Collider2D>();

        enemyLane = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        raycastStartX = gameObject.transform.position.x - 0.3f;
        raycastDir = Vector3.left;

        if (this.health == 0)
        {
            Destroy(this.gameObject);
            GameManager.Singleton.UpdateScore(1);
        }

        if (GameManager.Singleton.isGameActive == false) // Instantly destroys all Enemy instances on GameOver
        {
            Destroy(this.gameObject);
        }

        playerHit = Physics2D.Raycast(new Vector2(raycastStartX, gameObject.transform.position.y), raycastDir, raycastDist); // Initialize raycast2Dhit
        enemyHit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y), raycastDir, raycastDist);
        Debug.DrawRay(new Vector2(raycastStartX, gameObject.transform.position.y), raycastDir, Color.red);
        Debug.DrawRay(new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y), raycastDir, Color.blue);

        if (playerHit && playerHit.collider.gameObject.CompareTag("Player") && playerHit.collider.gameObject.layer == enemyLane)
            {
               movement.StopMovement();
               Debug.Log("Player Detected");
               StartAttack();
            }
        else if (playerHit && playerHit.collider.gameObject.CompareTag("WombTree"))
        {
            Destroy(this.gameObject);
            GameManager.Singleton.UpdateScore(-1);
        }
        else if (enemyHit && enemyHit.collider.gameObject.CompareTag("Enemy") && enemyHit.collider.gameObject.layer == enemyLane)
            {
              Debug.Log("Enemy Detected");
              movement.StopMovement();
            }
        else movement.StartMovement();
        
    }
    void StartAttack()
    {
        movement.CancelInvoke();
        anim.SetBool("IsStabbing", true);
       // armPunchCollider.enabled = true;
    }

    public void TakeDamage(int damageAmount)
    { 
        health -= damageAmount;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(new Vector2(raycastStartX, gameObject.transform.position.y), raycastDir);
    }

}
