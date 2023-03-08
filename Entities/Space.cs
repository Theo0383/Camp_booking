using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Space
    {
        private int spaceId;
        private string spaceVIP;

        public Space(int spaceId, string spaceVIP)
        {
            SpaceId = spaceId;
            SpaceVIP = spaceVIP;
        }
        public Space(string spaceVIP)
            :this(0, spaceVIP)
        {

        }

        public int SpaceId { get => spaceId; set => spaceId = value; }
        public string SpaceVIP { get => spaceVIP; set => spaceVIP = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
