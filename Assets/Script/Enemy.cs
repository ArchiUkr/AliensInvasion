using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject enemyExplosion;
    [SerializeField] GameObject hitFVX;
    [SerializeField] int scorePerHit = 15;

   

    [SerializeField] int hitPoints;

    ScoardBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        parentGameObject = GameObject.FindGameObjectWithTag("Spawn");
        scoreBoard = FindObjectOfType<ScoardBoard>();
        AddRigidBody();

    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
      
        ProcessHit();
        ProcessKill();
    
}

    private void ProcessKill()
    {
        if(hitPoints < 1) { 
        GameObject fx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
            scoreBoard.IncreaseScore(scorePerHit);
        }
}

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitFVX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
       
      
    }

    
}
