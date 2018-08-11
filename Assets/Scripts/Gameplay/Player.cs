using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D playerBody;

    private float minX, maxX, lineY, playerWidth, playerHeight;

    private void Awake(){
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start(){
        //Bound constraint
       
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log("player size:" + playerWidth + ", " + playerHeight);
        minX = -bound.x; // -400
        maxX = 2*bound.y+ minX+0.3f;// + Screen.height; //80
        
        lineY = -bound.y + playerHeight / 2;//fixed
        
        //Debug.Log("bound: " + minX + ", " + maxX+", "+lineY);

    }

    private void FixedUpdate(){
        playerMouseMoving();
        //playerKeyBoardMoving();
    }
    // Update is called once per frame
    void Update(){
        Vector3 curPos = transform.position;
        //Debug.Log("mouse X: " + Input.mousePosition.x / Screen.width);
        if(Input.mousePosition.x/Screen.width > maxX-1.3f || Time.timeScale == 0)//pause 
            Cursor.visible = true;
        else
            Cursor.visible = false;

        if (curPos.x - playerWidth / 2 < minX) curPos.x = minX + playerWidth / 2;
        else if (curPos.x + playerWidth / 2 > maxX) curPos.x = maxX - playerWidth / 2;
        curPos.y = lineY;
        transform.position = curPos;
    }

    void playerKeyBoardMoving(){
        float playerSpeed = GameplayController.instance.playerSpeed;
        float xAxis = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerSpeed;
        float yAxis = lineY;
        playerBody.velocity = new Vector2(xAxis, yAxis);
    }

    void playerMouseMoving(){
        float playerSpeed = GameplayController.instance.playerSpeed;
        float xAxis = Input.GetAxis("Mouse X") * playerSpeed;
        float yAxis = lineY;
        playerBody.velocity = new Vector2(xAxis, yAxis);
    }
    

    void playerTouchMoving(){
        //for android
    }

    void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "Items"){
			Destroy(target.gameObject); //destroy items
            GameplayController.instance.increaseScore();
	    }
	}
}
