using System;
using System.Timers;
using Stores;
using UniRx;
using UnityEngine;
using Zenject;

namespace Games.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject wavePrefab;
        [SerializeField]
        GameObject bigWavePrefab;

        [SerializeField]
        float waveSpawnSpanSeconds;
        [SerializeField]
        float bigWaveSpawnCheckSpanSeconds;
        [SerializeField]
        float bigWaveSpawnRate;

        [Inject]
        StateStore stateStore;

        void Start()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(waveSpawnSpanSeconds))
                .Select(_ => wavePrefab)
                .Subscribe(SpawnWave)
                .AddTo(this);

            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(bigWaveSpawnCheckSpanSeconds))
                .WithLatestFrom(stateStore.State, (_, state) => state)
                .Where(s => s == State.Playing)
                .Where(_ => UnityEngine.Random.value < bigWaveSpawnRate)
                .Select(_ => bigWavePrefab)
                .Subscribe(SpawnWave)
                .AddTo(this);

        }

        void SpawnWave(GameObject prefab)
        {
            var obj = Instantiate(prefab, transform);
            obj.transform.position = transform.position;
        }
    }
}
