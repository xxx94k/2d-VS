using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ׂĂ̕���̊�{�X�N���v�g
/// </summary>

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown;
    

    protected PlayerMovement pm;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration; //�J�n���Ɍ��݂̃N�[���_�E�����N�[���_�E�����Ԃɐݒ肵�܂�
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f) //�N�[���_�E����0�ɂȂ�����U������
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
