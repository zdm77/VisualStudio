using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TradeFlowers.Model
{
    public class Record
    {
        public int TreeId { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }
        public string ParentName { get; set; }
    }
    class prod_category_tree: prod_category
    {
        public List<prod_category_tree> Children { get; set; }
        public prod_category_tree(string name, int id, int pid)
        {
            category_id = id;
            category_name = name;
            Children = new List<prod_category_tree>();
            paerent_category = pid;
          //  ParentName = pName;
        }
        public void Add(Record record)
        {
            Traverse().First(node => node.category_id == record.ParentId).Children.Add(new prod_category_tree(record.Name, record.TreeId, record.ParentId));
        }
        private IEnumerable<prod_category_tree> Traverse()
        {
            yield return this;
            foreach (prod_category_tree child in Children.SelectMany(node => node.Traverse()))
            {
                yield return child;
            }
        }
        public static prod_category_tree CreateTree(List<Record> records)
        {
            Record rootRecord = records.First(r => r.ParentId == 0);
            var root = new prod_category_tree(rootRecord.Name, rootRecord.TreeId, rootRecord.ParentId);
            foreach (Record record in records.Where(r => r.ParentId != 0))
            {
                root.Add(record);
            }
            return root;
        }
    }
}
