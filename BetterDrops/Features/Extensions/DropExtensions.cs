namespace BetterDrops.Features.Extensions
{
    using System;
    using System.Collections.Generic;
    using Configs;
    using Features.Components;
    using PlayerRoles;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public static class DropExtensions
    {
        public static void SpawnDrops(this Team team, DropConfig config, uint numberOfDrops)
        {
            for(int i = 0; i < numberOfDrops; i++)
                team.SpawnDrop(config);
        }

        private static void SpawnDrop(this Team team, DropConfig config)
        {
            Vector3 spawnPosition = team == Team.OtherAlive ? (Random.Range(0, 2) == 1 ? Team.FoundationForces : Team.ChaosInsurgency).GetRandomSpawnPosition() : team.GetRandomSpawnPosition();
            SpawnDrop(spawnPosition, ParseColor(config.Color), GetRandomItem(config.PossibleItems, config.ItemsPerDrop));
        }

        public static void SpawnDrop(Vector3 position, Color color, IEnumerable<ItemType> items)
        {
            GameObject go = new GameObject("DROP")
            { transform = { position = position } };
            go.AddComponent<DropController>().Init(color, items);
        }
        
        private static Vector3 GetRandomSpawnPosition(this Team team)
        {
            switch (team)
            {
                case Team.ChaosInsurgency:
                    return new Vector3(Random.Range(35f, -16), 1000 + Random.Range(25f, 73f), Random.Range(-47, -38f));
                case Team.FoundationForces:
                    return new Vector3(Random.Range(110f, 139), 1000 + Random.Range(25f, 73f), Random.Range(-35, -50f));
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