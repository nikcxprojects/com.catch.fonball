using System;
using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Rigidbody { get; set; }

    public static Action<bool> OnBallGaught { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(nameof(Movement));
    }

    private void OnEnable()
    {
        Ball.OnPressed += OnBallPressdEventHandler;
    }

    private void OnDestroy()
    {
        Ball.OnPressed -= OnBallPressdEventHandler;
    }

    private void OnBallPressdEventHandler(Transform target)
    {
        StopCoroutine(nameof(Movement));

        Invoke(nameof(ResetMe), 1.5f);
    }

    private IEnumerator Movement()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.6f);

            float x = Random.Range(-1.0f, 1.0f);
            float y = Rigidbody.position.y;

            Vector2 target = new Vector2(x, y);
            while(Rigidbody.position != target)
            {
                Vector2 _position = Vector2.MoveTowards(Rigidbody.position, target, 3.0f * Time.deltaTime);
                Rigidbody.MovePosition(_position);
         
                yield return null;
            }

            yield return null;
        }
    }

    private void ResetMe()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(0, 0);
        Rigidbody.Sleep();

        StartCoroutine(nameof(Movement));
    }
}
