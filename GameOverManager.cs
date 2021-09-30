using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour{
    public PlayerHealth playerHealth;
	public Text warningText;
    public float restartDelay = 5f;   
	public float enemyDistance;
    Animator anim;                          
    float restartTimer;                    
    void Awake(){
        anim = GetComponent<Animator>();
    }
    void Update(){
        if (playerHealth.currentHealth <= 0){
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
	public void ShowWarning(){
		warningText.text = string.Format("! {0} m",Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}