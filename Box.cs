using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D rigid2D;
    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }


    // nhận mess
    public void daydayday(int x)
    {
        // nếu Ball_Player đang move thì mới gọi về này
        // nếu Ball_Player đang move và chạm vào box nhưng mà velocity của box không thấy tăng giảm ==> KẸT
        // KẸT => xích ra đầu ngược lại với biến x được truyền vào
        if (rigid2D.velocity == new Vector2(0, 0))
        {
            gameObject.transform.position += new Vector3(-x * Time.deltaTime * 5, 0, 0);
        }
    }
    
}
