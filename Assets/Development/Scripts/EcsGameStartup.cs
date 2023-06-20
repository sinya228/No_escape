using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Leopotam.Ecs.Ui.Systems;



public partial class EcsGameStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    [SerializeField] EcsUiEmitter _uiEmitter;

    [SerializeField] private AllItemsStatsSO Stats;
    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        systems.InjectUi(_uiEmitter);

        systems.Init();
    }
    private void AddInjections()
    {
        systems.Inject(Stats);
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

                //сссд инверсна€ кинематика(нужно дл€ анимвации)
                Add(new CCDIKSystem()).


                //использую как дебаг систему


                //UI взаимодействи€ с кнопками
                Add(new AreaEnterUISystem()).
                Add(new AreaExitUISystem()).

                Add(new AreaDragUiSystem()).
                Add(new AreaDropUISystem()).

                Add(new AreaClickUiSystem()).


                //√енераци€ шмотки игрока
                Add(new ItemCreateSystem()).

                Add(new RandomInputSystem()).

                Add(new ItemDestroySystem()).

                //ищет все ентити которые содержат ItemComponent и добавл€ет на них ItemsStatsDictionaryComponent в зависимости от базы предмета
                Add(new InitItemGenerationSystem()).
                   //ItemGeneration системы выбирают из ItemsStatsDictionaryComponent нужную стату по индексу и вешают их на предмет
                   Add(new ItemIncreaseGlobalDamageGenerationSystem()).

                   Add(new ItemFlatHealthGenerationSystem()).

                   Add(new ItemIncreasedMovementSpeedGenerationSystem()).
                //убирает со всех ентити которые содержат ItemComponent UndefinedComponent что останавлтивает генерацию стат на предмете
                Add(new EndItemGenerationSystem()).


                //вешает на все ентити которые содержат AllStatsComponent StatsUpdateEvent что тригерит инициализацию стат
                Add(new InitStatsSystem()).


                //Merrige системы собирают со всех обектов статы определенного типа, суммируют их, и записывают новую стату в ентити котора€ содержит AllStatsComponent провер€€ ее индекс
                Add(new FlatHealthMerrigeSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).
                Add(new PhysicalFlatDamageMerregeSystem()).
                Add(new GlobalIncreaseDamageMerrigeSystem()).
                Add(new FlatCritMerregeSystem()).
                Add(new CritMultiplierMerregeSystem()).


                //GetTotal системы провер€ют есть ли на ентити котора€ содержит AllStatsComponent обект с "плоской" статой, и если есть добавл€ет на него TotalComponent этой статы
                //остальные Total системы ищут AllStatsComponent и TotalComponent и произво€т опперации с TotalComponent
                Add(new GetTotalHealthSystem()).

                Add(new GetTotalMovementSpeedSystem()).
                Add(new IncreasedTotalMovementSpeedSystem()).

                //убирает со всех ентити которые содержат AllStatsComponent StatsUpdateEvent и AddNewStatEvent что останавлтивает инициализацию стат
                Add(new EndStatsInitSystem()).


                //—обирает сообщение дл€ прив€заного к шмотке месседж бокса
                Add(new RenderStatsSystem()).


                //показывает месседжбокс
                Add(new MessegeBoxShowSystem()).
                //устанавливает позицию на экране
                Add(new MessegeBoxPositionSystem()).
                //пр€чет месседжбокс
                Add(new MessegeBoxHideSystem()).
                
                Add(new StatBasetSpeedSystem());

    }
    private void AddOneFrames()
    {
        systems.OneFrame<JumpEvent>().
            OneFrame<ItemAddEvent>().
            OneFrame<ItemUndefineEvent>().
            OneFrame<ItemDestroyEvent>();
          
                        
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

