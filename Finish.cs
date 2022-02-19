using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : VatCan
{
    
    // chạm vào mà là Ball_Player thì gọi về gameControl là game done rồi
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball_Player")
        {
            GameObject.Find("GameControl").SendMessage("Finish");
        }
    }
}
