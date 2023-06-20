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
        //������
        systems.Add(new PlayerInputSystem()).
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerJumpInputSystem()).

                //������� � ������������
                Add(new GroundCheckSystem()).
                Add(new MovementSystem()).
                Add(new RotationSystem()).
                Add(new JumpSystem()).
                Add(new DoubleJumpSystem()).
                Add(new UnblockDoubleJumpSystem()).
                Add(new GravitySystem()).
                Add(new DashSystem()).

                //���� ��������� ����������(����� ��� ���������)
                Add(new CCDIKSystem()).


                //��������� ��� ����� �������


                //UI �������������� � ��������
                Add(new AreaEnterUISystem()).
                Add(new AreaExitUISystem()).

                Add(new AreaDragUiSystem()).
                Add(new AreaDropUISystem()).

                Add(new AreaClickUiSystem()).


                //��������� ������ ������
                Add(new ItemCreateSystem()).

                Add(new RandomInputSystem()).

                Add(new ItemDestroySystem()).

                //���� ��� ������ ������� �������� ItemComponent � ��������� �� ��� ItemsStatsDictionaryComponent � ����������� �� ���� ��������
                Add(new InitItemGenerationSystem()).
                   //ItemGeneration ������� �������� �� ItemsStatsDictionaryComponent ������ ����� �� ������� � ������ �� �� �������
                   Add(new ItemIncreaseGlobalDamageGenerationSystem()).

                   Add(new ItemFlatHealthGenerationSystem()).

                   Add(new ItemIncreasedMovementSpeedGenerationSystem()).
                //������� �� ���� ������ ������� �������� ItemComponent UndefinedComponent ��� �������������� ��������� ���� �� ��������
                Add(new EndItemGenerationSystem()).


                //������ �� ��� ������ ������� �������� AllStatsComponent StatsUpdateEvent ��� �������� ������������� ����
                Add(new InitStatsSystem()).


                //Merrige ������� �������� �� ���� ������� ����� ������������� ����, ��������� ��, � ���������� ����� ����� � ������ ������� �������� AllStatsComponent �������� �� ������
                Add(new FlatHealthMerrigeSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).
                Add(new PhysicalFlatDamageMerregeSystem()).
                Add(new GlobalIncreaseDamageMerrigeSystem()).
                Add(new FlatCritMerregeSystem()).
                Add(new CritMultiplierMerregeSystem()).


                //GetTotal ������� ��������� ���� �� �� ������ ������� �������� AllStatsComponent ����� � "�������" ������, � ���� ���� ��������� �� ���� TotalComponent ���� �����
                //��������� Total ������� ���� AllStatsComponent � TotalComponent � ��������� ��������� � TotalComponent
                Add(new GetTotalHealthSystem()).

                Add(new GetTotalMovementSpeedSystem()).
                Add(new IncreasedTotalMovementSpeedSystem()).

                //������� �� ���� ������ ������� �������� AllStatsComponent StatsUpdateEvent � AddNewStatEvent ��� �������������� ������������� ����
                Add(new EndStatsInitSystem()).


                //�������� ��������� ��� ����������� � ������ ������� �����
                Add(new RenderStatsSystem()).


                //���������� �����������
                Add(new MessegeBoxShowSystem()).
                //������������� ������� �� ������
                Add(new MessegeBoxPositionSystem()).
                //������ �����������
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

