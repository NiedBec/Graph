using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex
    {
        public string FamilyName { get; set; }
        public int ID { get; set; }
        public Vertex(string FamilyName, int ID)
        {
            this.FamilyName = FamilyName;
            this.ID = ID;
        }

        
        public override string ToString()
        {
            return FamilyName.ToString();
        }
    }
}
