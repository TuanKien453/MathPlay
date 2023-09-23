using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    public GetInput input;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
      input.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
            input.Show();
            playerHealth.takeDamage(10f);
            Debug.Log("PlayerCollisedEnermy");

        }
        
    }
    void PuzzleEvent()
    {
        Time.timeScale = 0;
    }
}
