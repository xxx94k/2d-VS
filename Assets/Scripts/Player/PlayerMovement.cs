using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    //�v���C���[�̓���
    [HideInInspector]
    public float lastHorizontalVector;

    [HideInInspector]
    public float lastVerticalVector;

    [HideInInspector]
    public Vector2 moveDir;

    [HideInInspector]
    public Vector2 lastMovedVector;

    //�Q��
    Rigidbody2D rb;
    public CharacterScriptableObject characterData;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f); // �ړ����s�킸�ɃQ�[�����N�����A�v���C���[�������Ȃ��ꍇ�A���˕���ɂ͐������Ȃ�
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
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //�Ō�̓����~
        }

        if(moveDir.y != 0 )
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //�Ō�̓��� y
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector); //�ړ���
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed,moveDir.y * characterData.MoveSpeed); 
    }
}
