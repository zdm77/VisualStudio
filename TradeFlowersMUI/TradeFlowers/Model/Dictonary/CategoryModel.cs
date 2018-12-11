﻿namespace TradeFlowers.Model.Dictonary
{
    public class CategoryModel
    {
        private int _id;
        private string _name;
        private int _pid;
        private int _orderBY;
        public CategoryModel()
        {
            
        }

        public CategoryModel(int id, int pid, string name, int orderBY)
        {
            _id = id;
            _name = name;
            _pid = pid;
            _orderBY = orderBY;
        }

        public CategoryModel(int id, string name)
        {
            _id = id;
            _name = name;           
        }
        //    public int Id { get => _id; set => _id = value; }
        //    public string Name { get => _name; set => _name = value; }
        //    public int Pid { get => _pid; set => _pid = value; }
        //    public int OrderBY { get => _orderBY; set => _orderBY = value; }
        public int Id { get => _id; set => _id = value; }

        public int PId { get; set; }

        public string Name { get =>_name; set=>_name=value; }
    }
}