namespace BetterDrops.Features
{
    using MEC;
    using Respawning;
    using System.Collections.Generic;
    using Configs;
    using Features.Extensions;
    using Random = UnityEngine.Random;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PlayerRoles;
    using PluginAPI.Core;

    public class EventHandler
    {
        private readonly HashSet<CoroutineHandle> _coroutines = new HashSet<CoroutineHandle>();


        [PluginEvent(ServerEventType.RoundRestart)]
        public void OnRestartingRound()
        {
            foreach (CoroutineHandle coroutine in _coroutines)
                Timing.KillCoroutines(coroutine);
            
            _coroutines.Clear();
        }

        [PluginEvent(ServerEventType.RoundStart)]
        public void OnStartingRound()
        {
            if (BetterDrops.Instance.Config.RandomDrops?.WaveSettings.IsEnabled == true && _coroutines.Count == 0)
                _coroutines.Add(Timing.RunCoroutine(RandomDropCoroutine(BetterDrops.Instance.Config.RandomDrops)));
        }

        [PluginEvent(ServerEventType.TeamRespawn)]
        public void OnRespawningTeam(SpawnableTeamType spawnableTeam, List<Player> players, int count)
        {
            Team team = (spawnableTeam == SpawnableTeamType.NineTailedFox ? Team.FoundationForces : Team.ChaosInsurgency);
            
            if(team == Team.FoundationForces && !BetterDrops.Instance.Config.MtfDropWave.IsEnabled || team == Team.ChaosInsurgency && !BetterDrops.Instance.Config.ChaosDropWave.IsEnabled)
                return;
            
            DropConfig cfg = team == Team.FoundationForces ? BetterDrops.Instance.Config.MtfDropWave : BetterDrops.Instance.Config.ChaosDropWave;
            team.SpawnDrops(cfg, cfg.NumberOfDrops);
        }

        private static IEnumerator<float> RandomDropCoroutine(RandomDropConfigs configs)
        {
            yield return Timing.WaitForSeconds(configs.FirstRandomDropOffset);

            for (;;)
            {
                Team team = Random.Range(0, 2) == 1 ? Team.FoundationForces : Team.ChaosInsurgency;
            
                team.SpawnDrops(configs.WaveSettings, configs.WaveSettings.NumberOfDrops);
                yield return Timing.WaitForSeconds(Random.Range(configs.MinRandomDropsInterval, configs.MaxRandomDropsInterval));
            }
        }
    }
}