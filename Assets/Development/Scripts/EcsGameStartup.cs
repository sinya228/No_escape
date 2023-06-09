using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Assets.Development.Scripts.AI;

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

                //������ �� ��� ������ ���� AllStatsComponent UpdateComponent ��� �������� ������������� ����
                Add(new InitStatsSystem()).

                Add(new FlatHealthMerrigeSystem()).

                //������� ��� ��
                Add(new TotalHealthCalcSystem()).

                Add(new FlatMovementSpeedMerregeSystem()).
                Add(new IncreasedMovementSpeedMerregeSystem()).

                //������� ��� �������� ������������
                Add(new TotalMovementSpeedCalcSystem()).

                Add(new PhysicalFlatDamageMerregeSystem()).
                Add(new GlobalIncreaseDamageMerrigeSystem()).
                Add(new CritMultiplierMerregeSystem()).
                Add(new FlatCritMerregeSystem()).

                //������� ���� ���������� ����
                Add(new TotalPhysicalDamageCalcSystem()).

                //������� �� ���� ������ ���� AllStatsComponent UpdateComponent ��� �������������� ���������� ����
                Add(new EndStatsUpdateSystem()).

                //������ �� ��� ������ ���� UiDrawComponent UpdateComponent ��� �������� ������������� ����
                Add(new InitUIDrawSystem()).

                Add(new RandomInputSystem()).

               
               
                Add(new UIDrawMessegeBoxSystem()).

                Add(new RenderMessegeSystem()).

                //������� ������������ AI
                Add(new GroundMovementAISystem()).

                //������� ������������� ����������
                Add(new KeybordInitSystem()).
                //������� ����������� ����
                Add(new CursorLockSystem());








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

