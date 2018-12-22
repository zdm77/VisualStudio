using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TradeFlowers.Model.Dictonary
{
    public class Record
    {
        public int TreeId { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }
        public string ParentName { get; set; }
    }

    public class CategoryModel : IDataErrorInfo
    {
    
        public CategoryModel()
        {

        }

        public CategoryModel(string name, int id, int pid, string pName)
        {
            Id = id;
            Name = name;
            Children = new List<CategoryModel>();
            PId = pid;
            ParentName = pName;
        }

        public string Name { get; set; }

        public List<CategoryModel> Children { get; set; }

        public int Id { get; set; }
        public int PId { get; set; }
        public string ParentName { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }

        public void Add(Record record)
        {
            Traverse().First(node => node.Id == record.ParentId).Children.Add(new CategoryModel(record.Name, record.TreeId, record.ParentId, record.ParentName));
        }

        private IEnumerable<CategoryModel> Traverse()
        {
            yield return this;
            foreach (CategoryModel child in Children.SelectMany(node => node.Traverse()))
            {
                yield return child;
            }
        }

        public string Error => throw new System.NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name == "" || Name is null)
                        {
                            error = "!";
                        }
                        else
                        {
                            error = "";
                        }
                        break;
                }
                return error;
            }
        }
        public static CategoryModel CreateTree(List<Record> records)
        {
            Record rootRecord = records.First(r => r.ParentId == 0);
            var root = new CategoryModel(rootRecord.Name, rootRecord.TreeId, rootRecord.ParentId, rootRecord.ParentName);
            foreach (Record record in records.Where(r => r.ParentId != 0))
            {
                root.Add(record);
            }
            return root;
        }
    }
}