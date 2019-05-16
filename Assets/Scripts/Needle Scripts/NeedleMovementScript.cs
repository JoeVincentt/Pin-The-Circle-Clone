using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovementScript : MonoBehaviour
{
      [SerializeField] private GameObject needleBody;

      private bool canFireNeedle;
      private bool touchedTheCircle;
      private float forceY = 5f;
      private Rigidbody2D myRigidBody2D;

      private void Awake()
      {
            Initialize();
      }

      private void Initialize()
      {
            needleBody.SetActive(false);
            myRigidBody2D = GetComponent<Rigidbody2D>();
      }

      private void Update()
      {
            if (canFireNeedle)
            {
                  myRigidBody2D.velocity = new Vector2(0, forceY);
            }
      }

      public void FireTheNeedle()
      {
            needleBody.SetActive(true);
            myRigidBody2D.isKinematic = false;
            canFireNeedle = true;
      }

      private void OnTriggerEnter2D(Collider2D target)
      {
            if (touchedTheCircle) { return; }

            if (target.tag == "Circle")
            {
                  canFireNeedle = false;
                  touchedTheCircle = true;

                  myRigidBody2D.simulated = false;
                  gameObject.transform.SetParent(target.transform);

                  if (ScoreScript.instance != null)
                  {
                        ScoreScript.instance.SetScore();
                  }

                  //   if (GameManager.instance != null)
                  //   {
                  //         GameManager.instance.InstantiateNeedle();
                  //   }
            }
      }
}
