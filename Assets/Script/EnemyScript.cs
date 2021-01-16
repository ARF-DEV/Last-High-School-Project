using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float MoveSpeed;
    GameObject Player;
    private GameManager GManager; 
    void Start()
    {
        if(!GameManager.GameOver()){
            Player = GameObject.FindGameObjectWithTag("Player");
            GManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
            Player.GetComponent<IndicatorManager>().SpawnIndicator(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.GameOver()){
            Vector2 Playerpos = Player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position,Playerpos,MoveSpeed * Time.deltaTime);
            
        }
        Debug.Log(GameManager.GameOver());
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            GManager.CamShake();
            Data.Score += 1;
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "Player"){
            Destroy(col.gameObject);
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
