using UnityEngine;

public class Coint : VatCan
{

    [SerializeField] private Sprite sprite;

    SpriteRenderer SRender;
    private bool xuong = false;

    private void Start()
    {
        SRender = GetComponent<SpriteRenderer>();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Box" && xuong == false)
        {
            // nếu coint gặp Box thì chuyển sprite thành xương 
            // khi này thì Ball_Player mới có thể nhặt
            xuong = true;
            SRender.sprite = sprite;
        }
        else if (collision.name == "Ball_Player" && xuong == true)
        {
            // nếu bị Ball_Player nhặt được thì gọi GameControl cộng điểm (AddCoint)
            GameObject.Find("GameControl").SendMessage("AddCoint");
            
            // reset lại SpawnPointPlayer 
            GameObject.Find("SpawnPointPlayer").SendMessage("ResetSpawnPoint", gameObject.transform.position);
            
            // xóa coint
            Destroy(gameObject);
        }

    }


}
