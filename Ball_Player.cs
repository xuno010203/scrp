using UnityEngine;

public class Ball_Player : MonoBehaviour
{
    public float speed = 5f;            // tốc chạy
    public float forceJump = 400f;      // lực nhảy

    public GameObject spawnPAwakeBall;
    public GameObject spawnPAwakeBox;
    public GameObject spawnPoint;       // SpawnPoint
    public GameObject box;              // Box cần tạo lại khi ReSpawn
    public AudioClip[] clips;           // Audio
    
    private bool chamBox = false;       // có đang chạm vào box không?
    private bool coDiem = false;        // codiem chua? Neu chua thì chơi lại
    private bool left = false, right = false;
    
    private Rigidbody2D rigid2D;
    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();

        left = false;
        right = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (left)
        {
            gameObject.transform.position += (Vector3.left * speed * Time.deltaTime);
        }else if (right)
        {
            gameObject.transform.position += (Vector3.right * speed * Time.deltaTime);
        }

        
        // đang dí move và chamBox == true ==> gửi mess về box
        if (left && chamBox == true)
        {
            // đang dí phím di chuyển thì gửi về box message đẩy đẩy đẩy
            GameObject.Find("Box").SendMessage("daydayday", -1);
        }else if (right && chamBox == true)
        {
            // đang dí phím di chuyển thì gửi về box message đẩy đẩy đẩy
            GameObject.Find("Box").SendMessage("daydayday", 1);
        }


    }

    // control 
    public void btnClickLeftOn()
    {
        left = true;
        right = false;
    }
    public void btnClickLeftOff()
    {
        left = false;
    }

    public void btnClickRightOn()
    {
        right = true;
        left = false;
    }

    public void btnClickRightOff()
    {
        right = false;
    }


    public void btnClickJump()
    {
        if (rigid2D.velocity == new Vector2(0, 0))
        {
            audioS.clip = clips[0];
            audioS.Play();
            rigid2D.AddForce(new Vector2(0, forceJump));
        }
    }
    

    // reSpawn
    public void ReSpawn(bool kt = false)
    {
        if (kt)
        {
            GameObject.FindWithTag("box").transform.position = spawnPAwakeBox.transform.position;
            gameObject.transform.position = spawnPAwakeBall.transform.position;
            coDiem = false;
            rigid2D.velocity = Vector2.zero;
        }
        else
        {
            if (coDiem)
            {
                box.transform.position = spawnPoint.transform.position;
            }

            // trả Ball_Player về spawnPoint
            rigid2D.velocity = Vector3.zero;
            gameObject.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 3, 0);
            GameObject.FindWithTag("10_trai").SendMessage("ReSpawn");
            
        }
        right = false;
        left = false;

    }


    public void boolCoDiem()
    {
        coDiem = true;
    }


    // chạm vào box và nằm trên vùng min max thì set true chamBox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        // va vào box nếu thỏa mãn điều kiện position.x nằm trong khoảng phạm vi ĐẦU của box thì chamBox == true
        if (collision.tag == "box" 
            && collision.transform.position.x - 2 < gameObject.transform.position.x  
            && gameObject.transform.position.x  < collision.transform.position.x + 2  )
        {
            
            chamBox = true;
        }
        // va vào titlemap tag "die"
        else if (collision.tag == "die")    
        {
            ReSpawn(); 
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // chạm vào nền thì play clip[1]
        if (collision.gameObject.tag == "nen")
        {
            audioS.clip = clips[1];
            audioS.Play();
        }
    }

    // chỉ cần rời box thì set false cho chamBox
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "box")
        {
            chamBox = false;
        }
    }
}
