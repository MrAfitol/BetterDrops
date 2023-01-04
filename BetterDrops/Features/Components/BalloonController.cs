namespace BetterDrops.Features.Components
{
    using UnityEngine;

    public class BalloonController : MonoBehaviour
    {
        private float _counter;

        private void Update()
        {
            transform.position += 5 * Time.deltaTime * Vector3.up;
            
            _counter += Time.deltaTime;

            if (_counter > 10)
                Destroy(gameObject);
        }
    }
}