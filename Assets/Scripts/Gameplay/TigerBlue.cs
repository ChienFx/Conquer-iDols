using UnityEngine;

public class TigerBlue : MonoBehaviour {
    private Rigidbody2D body;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        float speed = GameplayController.instance.itemSpeed;
        body.velocity = new Vector2(0f, -speed);
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "DestroyBox"){
			Destroy(gameObject);
            GameplayController.instance.showGameoverPanel();
		}
	}
}
