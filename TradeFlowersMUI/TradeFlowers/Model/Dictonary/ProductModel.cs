namespace TradeFlowers.Model.Dictonary
{
    internal class ProductModel
    {
        private int _id;
        private string _name;

        //private int _pid;
        public ProductModel(int Id, string name)
        {
            this._id = Id;
            this._name = name;
            //this._pid = pid;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }
}