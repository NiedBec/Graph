using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Circles
    {
        List<Circle> circles = new List<Circle>();
        public int circlesCount => circles.Count;
        public void AddCircle(Circle circle)
        {
            circles.Add(circle);
        }
    }
}
