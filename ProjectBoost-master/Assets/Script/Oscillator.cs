using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition; // Vị trí bắt đầu
    [SerializeField] Vector3 movementVector; // Vector di chuyển (x, y, z)
    float movementFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // Lấy vị trí bắt đầu khi bắt đầu thực hiện script
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  // continually growing over time
        
        const float tau = Mathf.PI * 2;  // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner
        

        Vector3 offset = movementVector * movementFactor; // Tính toán vector dịch chuyển
        transform.position = startingPosition + offset; // Di chuyển vật thể đến vị trí mới dựa trên vị trí bắt đầu và vector di chuyển
    }
}
