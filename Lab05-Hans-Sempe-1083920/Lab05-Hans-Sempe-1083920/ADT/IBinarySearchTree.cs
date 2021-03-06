using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace Lab05_Hans_Sempe_1083920.ADT
{
    interface IBinarySearchTree<K, V>
    {
        void InsertB(K key, V value);

        V SearchB(K key);

        V DeleteB(K key);

        V[] GetListB();

        void InOrderB(ITreeTraversal<V> traversal);

        void PreOrderB(ITreeTraversal<V> traversal);

        void PostOrderB(ITreeTraversal<V> traversal);

        bool IsEmptyB();

        int CountB();

    }
}
