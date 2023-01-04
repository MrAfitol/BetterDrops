namespace BetterDrops.Features.Components
{
    using UnityEngine;

    public class DisappearController : MonoBehaviour
    {
        public Vector3 startPos;
        
        private void Start()
        {
            Rigidbody r = gameObject.AddComponent<Rigidbody>();

            Vector3 dir = transform.position - startPos;
            
            r.AddForce(dir * 10, ForceMode.Impulse);
        }
    }
}