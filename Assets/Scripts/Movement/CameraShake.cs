using System;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrenght;
    [SerializeField] private Vector3 _rotationStrenght;
    [SerializeField] private float posStrenght;
    [SerializeField] private float rotStrenght;


    private static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShaker;
    private void OnDisable() => Shake -= CameraShaker;

    private void CameraShaker()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(posStrenght, _positionStrenght);
        _camera.DOShakeRotation(rotStrenght, _rotationStrenght);
    }

}
