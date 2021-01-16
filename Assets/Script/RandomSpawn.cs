using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    
    public GameObject EnemyPrefab;
    [Range(0,4)]
    public int pos;
    [Range(1f,10f)]
    public float x = 5f;
    [Range(1f,10f)]
    public float y = 2f;
    [Range(1f,10f)]
    public float SpawnDelay = 1f;
    [Range(1f,10f)]
    public float InstantiateSpeed = 1f;
    float CurDelay = 0f;
    float HalfHeightScreen;
    float HalfWidthScreen;


    void Awake()
    {
        HalfHeightScreen = Camera.main.orthographicSize;
        HalfWidthScreen = HalfHeightScreen * Camera.main.aspect;
        switch (pos)
        {
            case 1:
                transform.position = new Vector2(0, Camera.main.transform.position.y + HalfHeightScreen + (y / 2));
                break;
            case 2:
                transform.position = new Vector2(Camera.main.transform.position.x + HalfWidthScreen + (x / 2), 0);
                break;
            case 3:
                transform.position = new Vector2(0, Camera.main.transform.position.y - (HalfHeightScreen + (y / 2)));
                break;
            default:
                transform.position = new Vector2(Camera.main.transform.position.x - (HalfWidthScreen + (x / 2)), 0);
                break;
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 TopLeft = new Vector2(this.transform.position.x - (x/2),this.transform.position.y - (y/2));
        float randomX = Random.Range(0f,x);
        float randomY = Random.Range(0f,y);

        if(CurDelay <= 0f){
            Vector2 randpos = new Vector2(randomX,randomY);
            GameObject spawned = Instantiate(EnemyPrefab,TopLeft + randpos,Quaternion.identity);
            float RScale = Random.Range(0.3f,0.5f);
            spawned.transform.localScale = new Vector3(RScale,RScale,0f);
            spawned.GetComponent<EnemyScript>().MoveSpeed = InstantiateSpeed + (0.5f - spawned.transform.localScale.x);
            
            CurDelay = SpawnDelay;
        }
        else{
            CurDelay -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(this.transform.position,new Vector3(x,y,0f));
    }
}
