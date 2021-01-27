using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _audioPithMin;
    [SerializeField] float _audioPithMax;

    public void StartExplosion(float x, float y)
    {
        gameObject.SetActive(true);

        if (_transform != null)
        {            
            _transform.position = new Vector3(x, y, 0f);
            _transform.Rotate(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} no _transform!");
        }
        if (_spriteRenderer != null)
        {
            _spriteRenderer.flipX = Random.Range(0, 2) == 0;
            _spriteRenderer.flipY = Random.Range(0, 2) == 0;
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} no _spriteRenderer!");
        }
        if (_audioSource != null)
        {
            _audioSource.pitch = Random.Range(_audioPithMin, _audioPithMax);
            _audioSource.Play();
        }
        else
        {
            Debug.LogError($"{transform.name}:{GetType().Name} no _audioSource!");
        }
    }

    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }
}
