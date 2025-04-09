using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Toma componentes utiles para el Agent y los prepara en este script.
namespace AgentMVC
{
    public class AgentModel
    {
        public HpComponent HpComponent { get; private set; }
        public MovementComponent Movement { get; private set; }

        private Rigidbody _rb;

        private float _speed;

        public event Action<float, float> OnMovement = delegate { };


        public AgentModel(Agent agent)
        {
            _rb = agent.Rigidbody;

            _speed = agent.Speed;

            HpComponent = new HpComponent(agent.StartHp);
            Movement = new MovementComponent(agent);
        }

        public void Use()
        {
            //Movement.MovementUpdate();
        }
    }
}
