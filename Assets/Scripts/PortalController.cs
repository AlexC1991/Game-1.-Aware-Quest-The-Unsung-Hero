using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] private Material portalColorOne;
        [SerializeField] private Material portalColorTwo;

        private float _duration = 3;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            _renderer.material = portalColorOne;
        }

        private void Update()
        {
            float lerp = Mathf.PingPong(Time.time, _duration) / _duration;
            _renderer.material.Lerp(portalColorOne, portalColorTwo,lerp);
        }
    }
}
