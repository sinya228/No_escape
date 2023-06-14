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

                Add(new RandomInputSystem()).
                //������ �� ��� ������ ������� �������� AllStatsComponent StatsUpdateEvent � AddNewStatEvent ��� �������� ������������� ����
                Add(new InitStatsSystem()).

                //Merrige ������� �������� �� ���� ������� ����� ������������� ����, ��������� ��, � ���������� ����� ����� � ������ ������� �������� AllStatsComponent �������� �� ������

                Add(new FlatHealthMerrigeSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).
              

                //GetTotal ������� ��������� ���� �� �� ������ ������� �������� AllStatsComponent ����� � "�������" ������, � ���� ���� ��������� �� ���� TotalComponent ���� �����
                //��������� Total ������� � ��������� ����� ���� AllStatsComponent � TotalComponent � ��������� ��������� � TotalComponent
                Add(new GetTotalHealthSystem()).
                
                Add(new GetTotalMovementSpeedSystem()).              
                Add(new IncreasedTotalMovementSpeedSystem()).

                //������� �� ���� ������ ������� �������� AllStatsComponent StatsUpdateEvent � AddNewStatEvent ��� �������������� ������������� ����
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

