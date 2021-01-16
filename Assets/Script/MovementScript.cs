using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashTime = 3f;
    float CurDashtime = 0f;
    bool Slide = false;
    Vector2 dir;
    Vector2 Mousepos;
    Vector2 ScreenBounds;
    float PlayerHeight;
    float PlayerWidth;
    void Start(){
        CurDashtime = dashTime;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        PlayerHeight = transform.localScale.y/2;
        PlayerWidth = transform.localScale.x/2;

    }
    void Update()
    {

        if(Input.GetMouseButton(0) && !Slide){
            Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = (Mousepos - (Vector2)transform.position).normalized;
            Slide = true;
        }


        if(Slide){
            if(CurDashtime >= 0){
                transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
                CurDashtime -= Time.deltaTime;
            }
            else{
                Slide = false;
                CurDashtime = dashTime;
            }
        }
        Vector2 Ppos = this.transform.position;
        
        Ppos.x = Mathf.Clamp(Ppos.x,-ScreenBounds.x + PlayerWidth,ScreenBounds.x - PlayerHeight);
        Ppos.y = Mathf.Clamp(Ppos.y,-ScreenBounds.y + PlayerHeight,ScreenBounds.y - PlayerHeight);
        transform.position = Ppos;
    }
}