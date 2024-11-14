using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ׂĂ̔��˕��̓���̊�{�X�N���v�g [���˕��ł��镐��̃v���n�u�ɔz�u����܂�]
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;
        
        if(dirx < 0 && diry == 0) //��
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if(dirx == 0 && diry < 0) //��
        {
            scale.y = scale.y * -1;
            rotation.z = -360f;
        }
        else if(dirx == 0 && diry > 0) //��
        {
            scale.x = scale.x * -1;
            rotation.z = -0f;
        }
        else if(dir.x > 0 && dir.y > 0) //�E��
        {
            rotation.z = -45f;
        }
        else if (dir.x > 0 && dir.y < 0) // �E��
        {
            rotation.z = -135f;
        }
        else if(dir.x < 0 && dir.y > 0) // ����
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -135f;
        }
        else if(dir.x < 0 && dir.y < 0) //����
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -45f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); //�ϊ��ł��Ȃ����߁A�x�N�g����ݒ肷�邱�Ƃ͂ł��Ȃ�
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //Refference the script from the collided collider and deal damage using Takadamage()
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //����A�}���`�v���C�Ń_���[�W�����������ꍇ�ɔ����āAweapondata.damage�̑���Ɍ��݂̃_���[�W���g�p����悤�ɂ���B
            ReducePierce();
        }
    }

    void ReducePierce() //Destroy once the pierce reaches 0
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
