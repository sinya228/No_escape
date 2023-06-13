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
        //Init должны иметь все системы которы инициализируют данные или нужны для получения доступа к объектам
        systems.Add(new PlayerInputSystem()).//Система передвижения Player
                Add(new KeybordInitSystem()).//Система инициализации клавиатуры
                Add(new CursorLockSystem()).//Система отображения и управленияя курсором
                Add(new PlayerMouseInputSystem()).//Система поворота на месте Player
                Add(new PlayerJumpInputSystem()).//Система прыжков Player
                Add(new EntityInitializeSystem()).//Система объектов
                Add(new GroundCheckSystem()).//Система проверки поверхностей
                Add(new MovementSystem()).//Система передвижения
                Add(new RotationSystem()).//Система определения положения (Возможно в init)
                Add(new JumpSystem()).//Система прыжка
                Add(new DoubleJumpSystem()).//Система двойного прыжка
                Add(new UnblockDoubleJumpSystem()).//Система разблокировки двойного прыжка(не уверен что это нужно)
                Add(new GravitySystem()).//Система гравитации
                Add(new DashSystem()).//Система скочка
                Add(new CCDIKSystem()).//Система "решатель"(Нужно уточнение)
                Add(new TriggerSkillSystem()).//Система активации скилов
                Add(new FlatDamageStatsUpdateSystem()).//Система подсчета Flat Damage
                Add(new RaycastSystem()).//Система лучей(для стрельбы)
                Add(new DamageSystem()).//Система урона
                Add(new DebugSystem());//Система отладочных сообщений

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

