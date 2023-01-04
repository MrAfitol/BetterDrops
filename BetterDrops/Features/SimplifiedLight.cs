namespace BetterDrops.Features
{
    using AdminToys;
    using Mirror;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class SimplifiedLight
    {
        /// <summary>
        /// A light position 
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// A light rotation 
        /// </summary>
        public Vector3 Rotation;

        /// <summary>
        /// A light scale 
        /// </summary>
        public Vector3 Scale;

        /// <summary>
        /// A light color 
        /// </summary>
        public Color PrimitiveColor;

        /// <summary>
        /// A light range
        /// </summary>
        public float Range;

        /// <summary>
        /// A light parent
        /// </summary>
        public Transform Parent;

        /// <summary>
        /// A light source
        /// </summary>
        public LightSourceToy Source;

        private LightSourceToy ToyPrefab
        {
            get
            {
                if (Source == null)
                {
                    foreach (var gameObject in NetworkClient.prefabs.Values)
                        if (gameObject.TryGetComponent<LightSourceToy>(out var component))
                            Source = component;
                }

                return Source;
            }
        }

        /// <summary>
        /// Create primitive object
        /// </summary>
        /// <param name="type">The primitive type</param>
        /// <param name="position">The primitive position</param>
        /// <param name="rotation">The primitive rotation</param>
        /// <param name="scale">The primitive scale</param>
        /// <param name="color">The primitive color</param>
        /// <param name="parent">The primitive parent</param>
        /// <param name="alpha">The primitive transparency</param>
        public SimplifiedLight(Vector3 position, Vector3 rotation, Vector3 scale, Color color, float range, Transform parent = null)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;
            this.PrimitiveColor = color;
            this.Range = range;
            this.Parent = parent;
        }

        /// <summary>
        /// Spawn primitive
        /// </summary>
        /// <returns>Returns the created primitive</returns>
        public LightSourceToy Spawn()
        {
            var toy = Object.Instantiate(ToyPrefab);

            if (Parent != null) toy.transform.parent = Parent;

            toy.transform.localPosition = Position;
            toy.transform.localEulerAngles = Rotation;
            toy.transform.localScale = Scale;

            toy.NetworkScale = Scale;
            toy.NetworkLightColor = PrimitiveColor;
            toy.NetworkLightRange = Range;
            toy.NetworkMovementSmoothing = 60;

            NetworkServer.Spawn(toy.gameObject);

            return toy;
        }
    }
}
