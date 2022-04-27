using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05_Hans_Sempe_1083920.ADT
{

    interface IMultipathTree<K, V>
    {
        void Insert(K key, V valor);
        V Search(K key);
        V Delete(K key);
        V[] GetList();

        bool IsEmpty();

        int Count();

    }

    public class MultiPathTree<K, V>
    {
        public K LLave { get; set; }

        public V Valor { get; set; }

        public TreeNode<K, V> origen;

        public MultiPathTree()
        {
            this.origen = null; 
        }

    }

}
