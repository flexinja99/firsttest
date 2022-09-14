using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed;

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // x �� �Է�
        float v = Input.GetAxis("Vertical"); // z �� �Է�

        Vector3 dir = new Vector3(h, 0, v).normalized; // ũ�Ⱑ 1�� ���⺤��
        Vector3 moveVec = dir * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(moveVec);

        float r = Input.GetAxis("Mouse X");
        Vector3 rotateVec = new Vector3(0, r, 0) * rotateSpeed * Time.fixedDeltaTime;
        transform.Rotate(rotateVec);
    }
}
