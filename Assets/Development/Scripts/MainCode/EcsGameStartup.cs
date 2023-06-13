using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Assets.Development.Entity;

public partial class EcsGameStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        systems.Init();
    }
    private void AddInjections()
    {

    }
    private void AddSystems()
    {

        systems.Add(new PlayerInputSystem()).
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerJumpInputSystem()).
                Add(new EntityInitializeSystem()).
                Add(new GroundCheckSystem()).
                Add(new MovementSystem()).
                Add(new RotationSystem()).
                Add(new JumpSystem()).
                Add(new DoubleJumpSystem()).
                Add(new UnblockDoubleJumpSystem()).
                Add(new GravitySystem()).
                Add(new DashSystem()).
                Add(new CCDIKSystem()).
                Add(new TriggerSkillSystem()).
                Add(new FlatDamageStatsUpdateSystem()).
                Add(new RaycastSystem()).
                Add(new DamageSystem()).
                Add(new DebugSystem());

    }
    private void AddOneFrames()
    {
        systems.OneFrame<JumpEvent>().
        OneFrame<SkillTriggerEvent>().
        OneFrame<StatsUpdateEvent>().
        //OneFrame<InitializeEntityRequestComponent>().
        OneFrame<HitEvent>();
    }
    private void Update()
    {
        systems.Run();
    }
    private void OnDestroy()
    {
        if (systems == null) return;
        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}

