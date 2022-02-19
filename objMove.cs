using UnityEngine;

public class objMove : MonoBehaviour
{
    private bool vacham = false;

    public GameObject spawnPoint;
    private void Start()
    {
        gameObject.transform.position = spawnPoint.transform.position;
    }
    private void FixedUpdate()
    {
        // chỉ khi vacham == true thì tùy tag mà thực hiện di chuyển
        if (vacham && gameObject.tag == "10_trai")
        {
            gameObject.transform.Translate(new Vector3(0.15f, 0, 0));
        }
        else if (vacham && gameObject.tag == "10_phai")
        {
            gameObject.transform.Translate(new Vector3(-0.15f, 0, 0));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // nếu gặp tag là ball thì bật va chạm
        if(collision.tag == "ball")
        {
            vacham = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // chỉ cần rời thì vacham là false
        vacham = false;
        
    }

    public void ReSpawn()
    {
        gameObject.transform.position = spawnPoint.transform.position;
    }
}
