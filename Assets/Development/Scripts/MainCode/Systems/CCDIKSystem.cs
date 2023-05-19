using Leopotam.Ecs;
using UnityEngine;

sealed class CCDIKSystem : IEcsRunSystem
{
    private readonly EcsFilter<CCDIKSolverComponent> CCDIKFilter = null;


    public void Run()
    {
     
        foreach (var i in CCDIKFilter)
        {
            ref var IKsolvercomponent = ref CCDIKFilter.Get1(i);

            ref var endeffector = ref IKsolvercomponent.IKEndEffector;
            ref var target = ref IKsolvercomponent.IKTarget;
            


            ref var components = ref IKsolvercomponent.IKComponents;

            var n = IKsolvercomponent.IKComponents.Count;

           
            for (int j = n - 1; j >= 0; j--)
            {
                var haslimit =  components[j].HasLimits;
                var axis = components[j].HingeAxisRotation;


                Vector3 ArmDist = endeffector.position - components[j].JointTansform.position;

                Vector3 TarDist = target.position - components[j].JointTansform.position;


                components[j].JointTansform.rotation = Quaternion.FromToRotation(ArmDist, TarDist) * components[j].JointTansform.rotation;


                Vector3 curHingeAxis = components[j].JointTansform.rotation * axis;

                Vector3 hingeAxis = components[j].JointTansform.parent.rotation * axis;

                components[j].JointTansform.rotation = Quaternion.FromToRotation(curHingeAxis, hingeAxis) * components[j].JointTansform.rotation;


                if (haslimit)
                {
                    components[j].JointTansform.localRotation = RotLimit(components[j].JointTansform, axis, components[j].RotationAngleLimit);
                }

            }

        }

    }


    private Quaternion RotLimit(Transform joint, Vector3 Axis,Vector2 AxisLimit)
    {
        Vector3 JointAngle = joint.transform.localRotation.eulerAngles;

        if (Axis.x != 0)
        {
            JointAngle.x = AngleCalc(JointAngle.x, AxisLimit);
        }
        if (Axis.y != 0)
        {
            JointAngle.y = AngleCalc(JointAngle.y, AxisLimit);
        }
        if (Axis.z != 0)
        {
            JointAngle.z = AngleCalc(JointAngle.z, AxisLimit);
        }

        return Quaternion.Euler(JointAngle);

    }


    private float AngleCalc(float JointAngle, Vector2 AxisLimit) 
    {
        
        if (JointAngle > 180)
        {
            JointAngle = JointAngle - 360;
        }
        JointAngle = Mathf.Clamp(JointAngle, AxisLimit.x, AxisLimit.y);
        
        return JointAngle;
    }
    


}
