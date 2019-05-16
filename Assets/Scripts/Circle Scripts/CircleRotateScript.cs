using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotateScript : MonoBehaviour
{
      [SerializeField] private float rotationSpeed = 50f;
      private bool canRotate;
      private float rotationAngle;


      private void Awake()
      {
            canRotate = true;
      }

      void Update()
      {
            if (canRotate)
            {
                  RotateTheCircle();
            }
      }

      private void RotateTheCircle()
      {
            rotationAngle = transform.rotation.eulerAngles.z;
            rotationAngle += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
      }
}
