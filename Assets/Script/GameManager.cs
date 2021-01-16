using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI Textmesh;
    public Animator camAnim;
    void Start(){
        Data.Score = 0;
    }    
    void LateUpdate(){
        Textmesh.text = Data.Score.ToString();
    }
    public static bool GameOver(){
        return GameObject.FindGameObjectWithTag("Player") == null;
    }

    public void CamShake(){
        camAnim.SetTrigger("Shake");
    }




}