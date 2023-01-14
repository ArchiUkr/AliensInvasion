using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem explosionParticle;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " collided with" + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" {this.name } **Triggered by ** {other.gameObject.name} ");
        StartCrashSequence();

       
    }

    void StartCrashSequence()
    {

        explosionParticle.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", reloadDelay);

    }

    void ReloadLevel()
    {
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndexScene);
    }
}
