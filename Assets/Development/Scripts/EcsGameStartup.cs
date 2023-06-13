using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;



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
        //инпуты
        systems.Add(new PlayerInputSystem()).
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerJumpInputSystem()).

                //приколы с перемещением
                Add(new GroundCheckSystem()).
                Add(new MovementSystem()).
                Add(new RotationSystem()).
                Add(new JumpSystem()).
                Add(new DoubleJumpSystem()).
                Add(new UnblockDoubleJumpSystem()).
                Add(new GravitySystem()).
                Add(new DashSystem()).

                //сссд инверсная кинематика(нужно для анимвации)
                Add(new CCDIKSystem()).

                //вешает на все ентити типа AllStatsComponent UpdateComponent что тригерит инициализацию стат
                Add(new InitStatsSystem()).

                Add(new FlatHealthMerrigeSystem()).

                //считает все хп
                Add(new TotalHealthCalcSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).

                //считает всю скорость передвижения
                Add(new TotalMovementSpeedCalcSystem()).

                Add(new PhysicalFlatDamageMerregeSystem()).
                Add(new GlobalIncreaseDamageMerrigeSystem()).
                Add(new CritMultiplierMerregeSystem()).
                Add(new FlatCritMerregeSystem()).

                //считает весь физический урон
                Add(new TotalPhysicalDamageCalcSystem()).

                //убирает со всех ентити типа AllStatsComponent UpdateComponent что останавлтивает обновление стат
                Add(new EndStatsUpdateSystem()).

                //вешает на все ентити типа UiDrawComponent UpdateComponent что тригерит инициализацию стат
                Add(new InitUIDrawSystem()).

                Add(new RandomInputSystem()).

               
               
                Add(new UIDrawMessegeBoxSystem()).

                Add(new RenderMessegeSystem());








    }
    private void AddOneFrames()
    {
        systems.OneFrame<JumpEvent>();
     


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

