using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
   [SerializeField] private float health;
    private StatusManager instance;
    //-----------------------------------//
    public GameObject playerClone;
    private Animator anim;

    private void OnEnable()
    {
        anim = playerClone.GetComponent<Animator>();
        anim.SetTrigger("SPAWN");

       // instance = gameObject.AddComponent<StatusManager>();
        health = 30;
    }

    void Update()
    {
        if (health == 0 && GameManager.Singleton.isGameActive) 
        {
            anim.ResetTrigger("IDLE");
            anim.SetTrigger("DIE");
            return;
        }


        if (!GameManager.Singleton.isGameActive)
        {
            anim.SetTrigger("DIE");
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Contact");
        if (col.gameObject.CompareTag("Enemy"))
        {
            anim.ResetTrigger("IDLE");
            anim.SetTrigger("HURT");
            health -= 10;
            return;
        }
    }

    public void DebugHarm()
    {
        anim.ResetTrigger("IDLE");
        anim.SetTrigger("HURT");
        health -= 10;
        Debug.Log(health);
    }

    public void KillObject()
    {
        gameObject.SetActive(false);
        if (GameManager.Singleton.isGameActive)
        {
           GameManager.Singleton.CountLife();
            return;
        }
    } 

}
