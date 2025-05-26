namespace BetterDrops.Features
{
    using Configs;
    using Features.Extensions;
    using LabApi.Events.Arguments.ServerEvents;
    using MEC;
    using PlayerRoles;
    using System.Collections.Generic;
    using Random = UnityEngine.Random;

    public class EventsHandler
    {
        private readonly HashSet<CoroutineHandle> _coroutines = new HashSet<CoroutineHandle>();

        public void OnRoundRestarted()
        {
            foreach (CoroutineHandle coroutine in _coroutines)
                Timing.KillCoroutines(coroutine);
            _coroutines.Clear();
        }

        public void OnRoundStarted()
        {
            if (BetterDrops.Instance.Config.RandomDrops?.WaveSettings.IsEnabled == true && _coroutines.Count == 0)
                _coroutines.Add(Timing.RunCoroutine(RandomDropCoroutine(BetterDrops.Instance.Config.RandomDrops)));
        }

        public void OnRespawningTeam(WaveRespawningEventArgs ev)
        {
            Team team = (ev.Wave.Faction == Faction.FoundationStaff ? Team.FoundationForces : Team.ChaosInsurgency);

            if (team == Team.FoundationForces && !BetterDrops.Instance.Config.MtfDropWave.IsEnabled || team == Team.ChaosInsurgency && !BetterDrops.Instance.Config.ChaosDropWave.IsEnabled)
                return;

            DropConfig cfg = team == Team.FoundationForces ? BetterDrops.Instance.Config.MtfDropWave : BetterDrops.Instance.Config.ChaosDropWave;
            team.SpawnDrops(cfg, cfg.NumberOfDrops);
        }

        private static IEnumerator<float> RandomDropCoroutine(RandomDropConfigs configs)
        {
            yield return Timing.WaitForSeconds(configs.FirstRandomDropOffset);

            for (; ; )
            {
                Team team = Random.Range(0, 2) == 1 ? Team.FoundationForces : Team.ChaosInsurgency;

                team.SpawnDrops(configs.WaveSettings, configs.WaveSettings.NumberOfDrops);
                yield return Timing.WaitForSeconds(Random.Range(configs.MinRandomDropsInterval, configs.MaxRandomDropsInterval));
            }
        }
    }
}