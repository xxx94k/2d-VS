using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    //プレイヤーの動き
    [HideInInspector]
    public float lastHorizontalVector;

    [HideInInspector]
    public float lastVerticalVector;

    [HideInInspector]
    public Vector2 moveDir;

    [HideInInspector]
    public Vector2 lastMovedVector;

    //参照
    Rigidbody2D rb;
    public CharacterScriptableObject characterData;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f); // 移動を行わずにゲームを起動し、プレイヤーが動かない場合、発射武器には勢いがない
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0 )
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //最後の動き×
        }

        if(moveDir.y != 0 )
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //最後の動き y
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector); //移動中
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed,moveDir.y * characterData.MoveSpeed); 
    }
}
