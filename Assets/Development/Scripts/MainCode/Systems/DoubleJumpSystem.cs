using Leopotam.Ecs;
using UnityEngine;



sealed partial class DoubleJumpSystem : IEcsRunSystem
{

    private readonly EcsFilter<GroungCheckComponent,JumpEvent> groundcheckFilter = null;


    public void Run()
    {

        foreach (var i in groundcheckFilter)
        {

            ref var groundcheckcomponent = ref groundcheckFilter.Get1(i);

            if (groundcheckcomponent.isGrounded) return;
          
            ref var entity = ref groundcheckFilter.GetEntity(i);
            entity.Get<DoubleJumpBlockEvent>();



        }

    }

}