using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // kecepatan gerak

    void Update()
    {
        //Ambil input dari keyboard
        float horizontal = Input.GetAxis("Horizontal"); // A/D atau panah kiri-kanan
        float vertical = Input.GetAxis("Vertical"); // W/S atau panah atas-bawah

        //Buat arah gerak
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        //Gerakan Objek
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
