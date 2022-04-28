using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Lab05_Hans_Sempe_1083920.ADT
{
    public interface ITreeTraversal<V>
    {
        void Walk(V value);
    }

}
