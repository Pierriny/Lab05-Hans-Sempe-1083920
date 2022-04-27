using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05_Hans_Sempe_1083920.ADT
{
    public class TreeNode<K, V>
    {

        List<K> keys { get; set; }
        List<V> Values { get; set; }
        List<TreeNode<K, V>> hijos { get; set; }
        TreeNode<K, V> padre { get; set; }
        int minimumDegree { get; set; }
        int maximunDegre { get; set; }
        int currentKeysSize { get; set; }
        bool isLeaf { get; set; }

        CompareKeysDelegate<K> KeysComparator;

        // min 1 y max 3 para un arbol 2
        public TreeNode(int _minimumDegree, int _maximunDegree, bool _isLeaf, CompareKeysDelegate<K> _KeyComparator)
        {
            _minimumDegree = 1;

            _maximunDegree = 3;     

            this.keys = new List<K>();

            this.Values = new List<V>();

            this.hijos = new List<TreeNode<K, V>>();

            this.padre = null;

            this.minimumDegree = _minimumDegree;

            this.maximunDegre = _maximunDegree;

            currentKeysSize = 0;

            this.isLeaf = _isLeaf;

            KeysComparator = _KeyComparator;

        }

        public V Search(K _key, TreeNode<K, V> actual)
        {
            throw new NotImplementedException();
        }

        public void Insert(K _key, V _value)
        {
            if (currentKeysSize < (maximunDegre - 1))
            { // Split is not necessary
                if (isLeaf)
                {
                    int i = 0;
                    bool indexIsFound = false;
                    while ((i < keys.Count) || (!indexIsFound))
                    {
                        if (KeysComparator(_key, keys[i]) == 0)
                        {
                            return;
                        }

                        indexIsFound = KeysComparator(_key, keys[i]) < 0;
                        i++;
                    }

                    //index is found then insert
                    keys.Insert(i, _key);
                    Values.Insert(i, _value);
                    currentKeysSize++;

                }
                else //necessary to handle the references to children
                {
                    int i = 0;
                    bool indexIsFound = false;
                    while ((i < keys.Count) || (!indexIsFound))
                    {

                        if (KeysComparator(_key, keys[1]) == 0)
                        {
                            return;
                        }

                        indexIsFound = KeysComparator(_key, keys[i]) < 0;
                        i++;
                    }

                    if (indexIsFound)
                    {
                        hijos[i].Insert(_key, _value);
                    }
                    else
                    {
                        hijos[keys.Count].Insert(_key, _value);
                    }
                }
            }
            else
            {// split is necessary
                int i = 0;
                bool indexIsFound = false;
                while ((i < keys.Count) || (!indexIsFound))
                {

                    if (KeysComparator(_key, keys[i]) == 0)
                    {
                        return;
                    }

                    indexIsFound = KeysComparator(_key, keys[i]) < 0;
                    i++;
                }

                //Index is found then insert
                keys.Insert(i, _key);
                Values.Insert(i, _value);
                currentKeysSize++;
                Split(this);
            }
        }

        private void Split(TreeNode<K, V> actual) //when arrive to this the actual node should have maximum number of keys
        {
            if (padre != null) //It is intermediate node or a leaf
            {

            }
            else //It is the root
            {
                if (isLeaf) //if is the root but also a leaf
                {
                    //Check which index will be promoted to parent
                    int index = maximunDegre / 2;

                    //Create Two new nodes
                    TreeNode<K, V> left = new TreeNode<K, V>(minimumDegree, maximunDegre, true, KeysComparator);
                    TreeNode<K, V> right = new TreeNode<K, V>(minimumDegree, maximunDegre, true, KeysComparator);
                    //Since this is the root then is the root going to mark is a leaft as false
                    isLeaf = false;

                    //Assign left childs and remove from the new parent
                    int deletedKeysCount = 0;
                    for (int i = 0; i < index; i++)
                    {
                        left.Insert(keys[i], Values[i]);
                        left.currentKeysSize++;
                        deletedKeysCount++;
                    }

                    while (deletedKeysCount > 0)
                    {
                        keys.RemoveAt(0);
                        Values.RemoveAt(0);
                        deletedKeysCount--;
                    }

                    //Assign the right childs and remove from the new parent
                    for (int i = 1; i < keys.Count; i++)
                    {
                        right.Insert(keys[i], Values[i]);
                        right.currentKeysSize++;
                        deletedKeysCount++;
                    }

                    while (deletedKeysCount > 0)
                    {
                        keys.RemoveAt(1);
                        Values.RemoveAt(1);
                        deletedKeysCount--;
                    }

                    //promote to parent
                    hijos.Insert(0, left);
                    hijos.Insert(1, right);
                    left.padre = this;
                    right.padre = this;
                    currentKeysSize = 1;

                    //Since this is the root, no necessary to continue bottom tu up operations

                }
                else //Is the root but has children
                {

                    //Check which index will be promoted to parent
                    int index = maximunDegre / 2;

                    //Create Two new nodes
                    TreeNode<K, V> left = new TreeNode<K, V>(minimumDegree, maximunDegre, false, KeysComparator);
                    TreeNode<K, V> right = new TreeNode<K, V>(minimumDegree, maximunDegre, false, KeysComparator);
                    //Since this is the root then is the root going to mark is a leaft as false
                    isLeaf = false;

                    //Assign left childs and remove from the new parent
                    int deletedKeysCount = 0;
                    for (int i = 0; i < index; i++)
                    {
                        left.keys.Add(keys[i]);
                        left.Values.Add(Values[i]);
                        left.hijos.Add(this.hijos[i]);
                        left.currentKeysSize++;
                        deletedKeysCount++;
                    }
                    left.hijos.Add(hijos[index]);

                    while (deletedKeysCount > 0)
                    {
                        keys.RemoveAt(0);
                        Values.RemoveAt(0);
                        hijos.RemoveAt(0);
                        deletedKeysCount--;
                    }
                    hijos.RemoveAt(0);

                    //Assign the right childs and remove from the new parent
                    for (int i = 1; i < keys.Count; i++)
                    {
                        right.keys.Add(keys[i]);
                        right.Values.Add(Values[i]);
                        right.hijos.Add(this.hijos[i - 1]);
                        right.currentKeysSize++;
                        deletedKeysCount++;
                    }
                    right.hijos.Add(hijos[hijos.Count - 1]);

                    while (deletedKeysCount > 0)
                    {
                        keys.RemoveAt(1);
                        Values.RemoveAt(1);
                        deletedKeysCount--;
                    }
                    hijos.RemoveAt(0);

                    //promote to parent
                    hijos.Add(left);
                    hijos.Add(right);
                    left.padre = this;
                    right.padre = this;
                    currentKeysSize = 1;

                    //Since this is the root, no necessary to continue bottom tu up operations
                }
            }
        }







    }
}
