using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Lab05_Hans_Sempe_1083920.ADT
{
    interface ISelfBalancedTree<K, V>
    {
        void Insert(K key, V value);

        V Search(K key);

        V Delete(K key);

        V[] GetLisy();

        void Traversal(ITreeTraversal<V> traversal);

        bool IsEmpty();

        int Count();

    }
}
