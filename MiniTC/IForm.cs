using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC
{
    public interface IForm
    {
        IPanel LeftPanel { get; }
        IPanel RightPanel { get; }
        event Action Copy;
        event Action Move;
        event Action Delete;

    }
}
