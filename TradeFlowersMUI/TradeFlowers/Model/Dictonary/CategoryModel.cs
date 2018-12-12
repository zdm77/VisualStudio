using System;
using System.ComponentModel;

namespace TradeFlowers.Model.Dictonary
{
    public class CategoryModel : IDataErrorInfo
    {
        private int _id;
        private string _name;
        private int _pid;
        private int _orderBY;
        private string _pidName;
        public CategoryModel()
        {

        }
        
        public CategoryModel(int id, int pid, string name, int orderBY, string pidName)
        {
            _id = id;
            _name = name;
            _pid = pid;
            _orderBY = orderBY;
            _pidName = pidName;
        }

        public CategoryModel(int id, int pid, string name, string pidName)
        {
            _id = id;
            _name = name;
            _pid = pid;
            _pidName = pidName;
        }
        //    public int Id { get => _id; set => _id = value; }
        //    public string Name { get => _name; set => _name = value; }
        //    public int Pid { get => _pid; set => _pid = value; }
        //    public int OrderBY { get => _orderBY; set => _orderBY = value; }
        public int Id { get => _id; set => _id = value; }
        public string PidName { get => _pidName; set => _pidName = value; }

        public int PId { get => _pid; set => _pid = value; }

        public string Name { get => _name; set => _name = value; }

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
    }
}