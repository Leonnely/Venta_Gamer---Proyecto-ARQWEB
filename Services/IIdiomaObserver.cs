using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public interface IIdiomaObserver
    {
        void UpdateIdioma(Dictionary<string, string> textos);
    }
}
