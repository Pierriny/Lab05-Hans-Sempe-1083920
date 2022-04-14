using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05_Hans_Sempe_1083920.TreeStructures
{
    public class TreeNode<K, V>
    {

        public TreeNode(K key, V valor)
        {
            this.Key = key;
            this.value = valor;
            this.Izquierda = null;
            this.Derecha = null;
            this.Centro = null;
            this.Padre = null;
            this.Padre2 = null;
        }

        public V value { get; set; }
        public K Key { get; set; }
        public TreeNode<K, V> Izquierda { get; set; }
        public TreeNode<K, V> Centro { get; set; }
        public TreeNode<K, V> Derecha { get; set; }
        public TreeNode<K, V> Padre { get; set; }
        public TreeNode<K, V> Padre2 { get; set; }
        
    }
}
