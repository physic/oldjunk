using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    public interface Phase
    {
        //possibly phase is not actually going to be a game-driving thing, it might just be game state that is 
        //a member, updated by the driver as all the other game state is updated. driver can handle messages and 
        //make/execute transactions.
    }
}
