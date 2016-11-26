using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public struct Card
    {
        public Card(Suite suite, Face face)
        {
            this.suite = suite.ToString();
            this.face = face.ToString();
            faceValue = (int)face;
        }

        private string suite, face;
        private int faceValue;

        public string Suite { get { return suite; } }

        public string Face { get { return face; } }

        public int FaceValue { get { return faceValue; } }

        public string FaceOfSuite { get { return (face + " of " + suite); } }
    }
}
