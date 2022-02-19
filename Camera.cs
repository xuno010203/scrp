using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform lookAt;

    // tạo 1 ô có độ dài x và y
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    // Tạo nên ô chữ nhật có độ dài 2 cạnh x, y
    // lookAt phải ở trong ô chữ nhật này
    // lookAt mà đi ra khỏi ô này thì move theo
    void LateUpdate()
    {
        Vector3 move = Vector3.zero;
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
                move.x = deltaX - boundX;
            else
                move.x = deltaX + boundX;
        }

        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
                move.y = deltaY - boundY;
            else
                move.y = deltaY + boundY;
        }
        transform.position += new Vector3(move.x, move.y, 0);
    }
}
