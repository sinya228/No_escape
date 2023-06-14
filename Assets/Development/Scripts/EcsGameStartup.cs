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

                Add(new RandomInputSystem()).
                //вешает на все ентити которые содержат AllStatsComponent StatsUpdateEvent и AddNewStatEvent что тригерит инициализацию стат
                Add(new InitStatsSystem()).

                //Merrige системы собирают со всех обектов статы определенного типа, суммируют их, и записывают новую стату в ентити которая содержит AllStatsComponent проверяя ее индекс

                Add(new FlatHealthMerrigeSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).
              

                //GetTotal системы проверяют есть ли на ентити которая содержит AllStatsComponent обект с "плоской" статой, и если есть добавляет на него TotalComponent этой статы
                //остальные Total системы с препиской тотал ищут AllStatsComponent и TotalComponent и произвоят опперации с TotalComponent
                Add(new GetTotalHealthSystem()).
                
                Add(new GetTotalMovementSpeedSystem()).              
                Add(new IncreasedTotalMovementSpeedSystem()).

                //убирает со всех ентити которые содержат AllStatsComponent StatsUpdateEvent и AddNewStatEvent что останавлтивает инициализацию стат
                Add(new EndStatsInitSystem()).



           
                Add(new InitUIDrawSystem()).

                Add(new RenderStatsUISystem()).

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

