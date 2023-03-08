using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        private int reserveId;
        private DateTime reserveStart;
        private DateTime reserveEnd;
        private int spaceId_FK;

        public Reservation(int reserveId, DateTime reserveStart, DateTime reserveEnd, int spaceId_FK)
        {
            ReserveId = reserveId;
            ReserveStart = reserveStart;
            ReserveEnd = reserveEnd;
            SpaceId_FK = spaceId_FK;
        }
        public Reservation(DateTime reserveStart, DateTime reserveEnd, int spaceId_FK)
            :this(0, reserveStart, reserveEnd, spaceId_FK)
        {

        }

        public int ReserveId { get => reserveId; set => reserveId = value; }
        public DateTime ReserveStart { get => reserveStart; set => reserveStart = value; }
        public DateTime ReserveEnd { get => reserveEnd; set => reserveEnd = value; }
        public int SpaceId_FK { get => spaceId_FK; set => spaceId_FK = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
