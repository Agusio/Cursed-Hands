using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//No tiene ninguna funcion, sera preparado mas adelante
namespace AgentMVC
{
    public class AgentView
    {
        private Image _hpBarImage;

        private Animator _animator;
        private Material _material;

        public AgentView(Agent agent)
        {
            _hpBarImage = agent.HpBarImage;
            _animator = agent.Animator;
            _material = agent.Renderer.material;
        }

        public void MovementAnimation(float xValue, float yValue)
        {
            //animator do stuff
        }

        public void UpdateHpBar(float amount)
        {
            //hp info
        }

        public void DeadMaterial()
        {
            _material.color = Color.red;
        }
    }
}
