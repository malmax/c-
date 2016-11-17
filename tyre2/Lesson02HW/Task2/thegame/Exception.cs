using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thegame
{
    class GameObjectException:Exception
    {
        public GameObjectException(string message = "Не правильно задан размеры игрового объекта") :base(message)
        {
            
        }
    }
}
