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

        private TreeNode<K, V> origen;

        private CompareKeysDelegate<K> compare;

        public MultiPathTree()
        {
            this.origen = null; 
        }




        public virtual void Add(K llave, V item, CompareKeysDelegate<K> compare)
        {
            bool hoja = false;

            int min = 1;

            int max = 3;      

            this.origen = new TreeNode<K, V>(min, max, hoja, compare);

            origen.Insert(llave, item);

        }


        public List<V> GetList()
        {
            List<V> tempList = new List<V>();


            return tempList;
        }


    }

}
