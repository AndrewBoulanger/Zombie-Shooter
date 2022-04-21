using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SaveableMO
{
    [SerializeField] int Waves = 3;
    int currentWave = 0;
    [SerializeField] int EnemiesPerWave = 20;
    
    List<SlimeComponent> activeSlimes = new List<SlimeComponent>();

    [SerializeField] SlimeSpawner spawner;

    public delegate void OnWaveDelegate(int wave);
    public static event OnWaveDelegate OnWaveCompleted;

    // Start is called before the first frame update
    void Start()
    {
        if(currentWave == 0)
            advanceWave();
    }

    public void removeSlime(SlimeComponent slime)
    {
        activeSlimes.Remove(slime);
        if(activeSlimes.Count <= 0)
            advanceWave();
    }

    void advanceWave()
    {
        if(currentWave++ <= Waves)
        {
            for(int i = 0; i< EnemiesPerWave; i++)
            {
               activeSlimes.Add(spawner.Spawn());
            }
            OnWaveCompleted?.Invoke(currentWave);
        }
        else
            PlayerEvents.Invoke_OnPlayerWin();
    }

    protected override void SaveData()
    {
        PersistantSaveInfo.saveObject(new SlimeData(activeSlimes, currentWave), "SlimeData");
    }

    protected override void LoadData()
    {
        SlimeData save = null;
        PersistantSaveInfo.loadObject<SlimeData>("SlimeData", ref save);
        if(save != null)
        {
            for(int i = 0; i < save.locs.Count; i++)
            {
                SlimeComponent newSlime = spawner.Spawn(save.locs[i], save.rots[i]);
                newSlime.GetComponent<HealthComponent>().CurrentHealth = save.healths[i];
                activeSlimes.Add(newSlime);
            }
            currentWave = save.wave;
            OnWaveCompleted?.Invoke(currentWave);
        }
    }

    public override void OnEnable()
    {
        SlimeComponent.OnSlimeDeath += removeSlime;
        base.OnEnable();
    }

    public override void OnDisable()
    {
        
        SlimeComponent.OnSlimeDeath -= removeSlime;
        base.OnDisable();
    }
}

public class SlimeData
{
   public List<Vector3> locs;
   public List<Quaternion> rots;
   public List<float> healths;
    public int wave;

    public SlimeData(List<SlimeComponent> slimes, int _wave)
    {
        wave = _wave;
        foreach(SlimeComponent s in slimes)
        {
            locs.Add(s.transform.position);
            rots.Add(s.transform.rotation);
            healths.Add(s.GetComponent<HealthComponent>().CurrentHealth);
        }
    }


}