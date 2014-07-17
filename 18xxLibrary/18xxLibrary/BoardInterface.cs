using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    interface BoardInterface
    {
        Board GetBoard1830();
    }
}
/*so, the game will progress through phases, subphases etc.
  we have the game phase-- 1830 or 1817 or whatever. inside that we will have
  phases such as initial auction, stock round, operating round, and any additional
  upkeep or in-between phases that are necessary. within these phases are sub-phases
  like an individual player's turn in the stock round. A subphase returns to its
  calling/parent phase when it finishes, the parent phase then calls the next phase.*/