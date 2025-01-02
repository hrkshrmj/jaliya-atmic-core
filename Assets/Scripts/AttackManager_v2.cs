using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager_v2 : MonoBehaviour
{
    public GameObject playerClone;
    private Animator anim;
    private StatusManager status;

    private float timeBtwAttack = 0.3f;

    [SerializeField] private Component cloneCursor;
    public Transform attackPos;
    public float attackRange;
    [SerializeField] private LayerMask whatIsEnemies;

    // Start is called before the first frame update
    private void OnEnable()
    {
        anim = playerClone.GetComponent<Animator>();
        status = playerClone.GetComponent<StatusManager>();
        anim.keepAnimatorStateOnDisable = false;
        anim.Play("Spawn");
    }

    // Update is called once per frame
    void Update()
    {     
        if (Input.GetKey(KeyCode.Space) && CloneManager.Singleton.currentSelectedClone == playerClone && GameManager.Singleton.isGameActive)
            {
                StartAttackAnim();
            }
                   
        if (Input.GetKeyDown(KeyCode.H) && CloneManager.Singleton.currentSelectedClone == playerClone && GameManager.Singleton.isGameActive)
        {
               status.DebugHarm(); //self-damage selected clone for debugging
        }

        if (CloneManager.Singleton.currentSelectedClone == playerClone)
        {
            if (playerClone.activeSelf)
            {
                cloneCursor.gameObject.SetActive(true);
            }
        }
        else cloneCursor.gameObject.SetActive(false);


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void StartAttackAnim()
    {
        anim.ResetTrigger("IDLE");
        anim.SetTrigger("ATTACK");   
    }

    public void SetAttackPosActive()
    {
        attackPos.gameObject.SetActive(true);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyBehavior>().TakeDamage(10);
            break;
        }
       // yield return new WaitForSeconds(timeBtwAttack);
        attackPos.gameObject.SetActive(false);
        anim.ResetTrigger("ATTACK");
        anim.SetTrigger("IDLE");
    }
}
