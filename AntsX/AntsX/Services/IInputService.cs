using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntsX.Services
{
    public interface IInputService
    {
        bool MapScrollLeft{get;}
        bool MapScrollRight{get;}
        bool MapScrollUp{get;}
        bool MapScrollDown{get;}

    }
}
