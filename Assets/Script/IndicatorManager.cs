using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    
    public GameObject Enemy_Indicator;
    
    // void LateUpdate()
    // {   
        
        
    //     if(Enemyind.Count != 0){
    //         for(int i = 0;i<Enemyind.Count;i++){
    //             if(Enemyind[i] == null){
    //                 Enemyind.Remove(Enemyind[i]);
    //             }
    //         }
    //     }      
    //     if(Targets.Any() && Targets.Count >= EnemyCount ){
    //         for(int i = 0 ;i < Targets.Count - Enemyind.Count;i++){
    //             GameObject indicator = Instantiate(Enemy_Indicator,transform.position,Quaternion.identity);
    //             indicator.transform.SetParent(this.transform);
    //             Enemyind.Insert(i,indicator.GetComponent<EnemyIndicator>());
    //         }
            
            
    //            for(int i = 0;i<Enemyind.Count;i++){
    //                if(!TargetSetted(Enemyind[i])){
    //                    Enemyind[i].SetTarget(Targets[i]);
    //                }
    //            }
            
    //     }else{
    //         Targets = GameObject.FindGameObjectsWithTag("Enemy").ToList();
    //         EnemyCount = Targets.Count;
    //     }//Bad Code Spawn Indicator When Enemy Spawn
    // }

    public void SpawnIndicator(GameObject Target){
        GameObject indicator = Instantiate(Enemy_Indicator,transform.position,Quaternion.identity);
        indicator.transform.SetParent(this.transform);
        indicator.GetComponent<EnemyIndicator>().SetTarget(Target);
    }
    bool TargetSetted(EnemyIndicator ind){
        return ind.GetTarget() != null;

    }
}
