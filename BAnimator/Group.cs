using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnimator
{
    public class Group
    {
        public string Name { get; set; }

        public bool Visible { get; set; }

        public Group()
        {
            Name = "Новая группа";
        }
    }
}
