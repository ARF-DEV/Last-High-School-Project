using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null){
            Vector2 dir = Target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90;
            Debug.Log(angle);
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    GameObject[] GetOutSideScreen(){
        GameObject[] AllEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> OutFrame = new List<GameObject>();
        foreach(GameObject i in AllEnemy){
            if(!InFrame(i.transform)){
                OutFrame.Add(i);
            }
        }
        return OutFrame.ToArray();
    }
    public void IndicatorActive(GameObject Target){
        Vector2 dir = Target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90;
            Debug.Log(angle);
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
    public void SetTarget(GameObject _Target){
        Target = _Target;
    }
    public GameObject GetTarget(){
        return Target;
    }
    

    bool InFrame(Transform pos){
        Vector2 ScreenBound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

        return pos.position.x > -ScreenBound.x && pos.position.x < ScreenBound.x && pos.position.y > -ScreenBound.y && pos.position.y < ScreenBound.y;
    }
}
