using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public float moveSpeed = 3f; // Kecepatan gerakan karakter
    public Vector3 startPosition;
    public Vector3 endPosition;

    private bool isMoving = false;
    private Vector3 targetPosition;

    public void MoveCharacter()
    {
        isMoving = true;
        targetPosition = endPosition;
    }

    void Update()
    {
        if (isMoving)
        {
            // Gerakan karakter
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Jika sudah mencapai posisi tujuan, hentikan gerakan
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
