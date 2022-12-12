using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float camDistance = -7.32f;

    public bool doFollowPlayer;
    public float followSpeed;
    public Transform player;
    Vector2 camPos;

    public bool allowParalaxa;
    public float paralaxaSpeed;
    Vector2 paralaxaPos;
    // Update is called once per frame

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        setValues();
        Vector3 _desiredPos3D = new Vector3(camPos.x, camPos.y, camDistance);
        transform.position = new Vector3(Vector2.Lerp(transform.position, camPos, followSpeed * Time.deltaTime).x, Vector2.Lerp(transform.position, camPos, followSpeed * Time.deltaTime).y, Mathf.Lerp(transform.position.z, camDistance, followSpeed * Time.deltaTime));
    }
    void setValues()
    {
        Vector2 _playerPos = player.position;
        if (allowParalaxa)
        {
            Vector2 _desiredParalaxa = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            paralaxaPos = Vector2.Lerp(paralaxaPos, _desiredParalaxa, paralaxaSpeed * Time.deltaTime);
        }
        else
        {
            paralaxaPos = Vector2.zero;
        }

        camPos = _playerPos + paralaxaPos;
    }
}
