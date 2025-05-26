namespace BetterDrops.Features.Extensions
{
    using Configs;
    using Features.Components;
    using LabApi.Features.Wrappers;
    using PlayerRoles;
    using SCP1162;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using PrimitiveObjectToy = AdminToys.PrimitiveObjectToy;
    using Random = UnityEngine.Random;

    public static class DropExtensions
    {
        public static void SpawnDrops(this Team team, DropConfig config, uint numberOfDrops)
        {
            for (int i = 0; i < numberOfDrops; i++)
                team.SpawnDrop(config);

            if (!string.IsNullOrEmpty(config.Cassie))
            {
                if (team == Team.ChaosInsurgency) Cassie.Message(config.Cassie, false, config.CassieBell);
                else Cassie.Message(config.Cassie, false, config.CassieBell);
            }
        }

        private static void SpawnDrop(this Team team, DropConfig config)
        {
            Vector3 spawnPosition = team == Team.OtherAlive ? (Random.Range(0, 2) == 1 ? Team.FoundationForces : Team.ChaosInsurgency).GetRandomSpawnPosition() : team.GetRandomSpawnPosition();
            SpawnDrop(spawnPosition, ParseColor(config.Color), GetRandomItem(config.PossibleItems, config.ItemsPerDrop), config.RandomAttachments);
        }

        public static void SpawnDrop(Vector3 position, Color color, IEnumerable<ItemType> items, bool randomAttachments)
        {
            PrimitiveObjectToy primitiveObjectToy = new SimplifiedToy(PrimitiveType.Cube, position, Vector3.one, Vector3.one, Color.white, null, 0f).Spawn();
            primitiveObjectToy.NetworkPrimitiveFlags = AdminToys.PrimitiveFlags.None;
            primitiveObjectToy.gameObject.AddComponent<DropController>().Init(color, items, randomAttachments);
        }

        private static Vector3 GetRandomSpawnPosition(this Team team)
        {
            switch (team)
            {
                case Team.ChaosInsurgency:
                    return new Vector3(Random.Range(35f, -16), 300 + Random.Range(25f, 60f), Random.Range(-47, -38f));
                case Team.FoundationForces:
                    return new Vector3(Random.Range(110f, 139), 300 + Random.Range(25f, 60f), Random.Range(-35, -50f));
                default:
                    throw new IndexOutOfRangeException("Index out of range. Only MTF and CHI can get a random spawn position.");
            }
        }

        private static Color ParseColor(string color) => ColorUtility.TryParseHtmlString(color, out Color c) ? c : Random.ColorHSV();

        private static IEnumerable<ItemType> GetRandomItem(IReadOnlyList<ItemType> items, uint amount)
        {
            List<ItemType> ret = new List<ItemType>();

            for (int i = 0; i < amount; i++)
            {
                ret.Add(items[Random.Range(0, items.Count)]);
            }

            return ret;
        }
    }
}