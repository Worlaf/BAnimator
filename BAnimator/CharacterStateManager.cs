using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnimator
{
    public class CharacterStateManager
    {
        protected Dictionary<string, CharacterState> dictionary = new Dictionary<string, CharacterState>();
        protected List<CharacterState> list = new List<CharacterState>();

        public CharacterState this[string state]
        {
            get { return dictionary[state]; }
        }

        public CharacterState this[int i]
        {
            get { return list[i]; }
        }

        public int Count { get { return list.Count; } }

        public void AddState(CharacterState state)
        {
            if (dictionary.ContainsKey(state.Name) || dictionary.ContainsValue(state))
                return;
            list.Add(state);
            dictionary.Add(state.Name, state);
        }

        public void RemoveState(CharacterState state)
        {
            dictionary.Remove(state.Name);
            list.Remove(state);
        }

        public bool StateExists(CharacterState state)
        {
            return list.IndexOf(state) >= 0;

        }

        public bool CheckCharacterStateValues(List<CharacterStateValue> csv)
        {
            if (csv == null)
                return false;
            int i;
            for (i = 0; i < csv.Count; i++)
            {
                if (!dictionary.ContainsKey(csv[i].StateName))
                    continue;
                if (dictionary[csv[i].StateName].State == csv[i].StateValue)
                    return true;
            }
            return false;
        }
    }
}
