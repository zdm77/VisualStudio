using System.Collections.Generic;
using System.Linq;
using TradeFlowers.Model.Dictonary;

namespace TradeFlowers.Model
{
    internal class Node
    {
        // private int _pid;
        public Node(string name, int id)
        {
            Id = id;
            Name = name;
            Children = new List<Node>();
        }

        public string Name { get; set; }

        public List<Node> Children { get; set; }

        public int Id { get; set; }

        // public int PId { get; set; }

        // public List<Record> Records = new List<Record>();

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }

        public static Node CreateTree(List<CategoryModel> records)
        {
            CategoryModel rootRecord = records.First(r => r.PId == 0);
            var root = new Node(rootRecord.Name, rootRecord.Id);
            foreach (CategoryModel record in records.Where(r => r.PId != 0))
            {
                root.Add(record);
            }
            return root;
        }

        public void Add(CategoryModel record)
        {
            Traverse().First(node => node.Id == record.PId).Children.Add(new Node(record.Name, record.Id));
        }

        private IEnumerable<Node> Traverse()
        {
            yield return this;
            foreach (Node child in Children.SelectMany(node => node.Traverse()))
            {
                yield return child;
            }
        }
    }
}