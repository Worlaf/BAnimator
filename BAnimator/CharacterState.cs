using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnimator
{
    /// <summary>
    /// Класс, отвечающий за состояния персонажа
    /// Система состояний позволяет использовать разные изображения
    /// например для разных эмоций
    /// </summary>
    public class CharacterState
    {
        public string Name { get; protected set; }
        public int Priority { get; set; }
        public List<string> States { get; set; }
        protected string state = "default";
        public string State { get { return state; } set { if (States.Contains(value))state = value; } }

        public CharacterState(string name, int priority = 0)
        {
            Name = name;
            Priority = priority;
            States = new List<string>();
        }
    }


}
