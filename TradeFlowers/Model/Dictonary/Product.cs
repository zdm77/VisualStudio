using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeFlowers.Model.Dictonary
{
    //
    // Сводка:
    //     Определяет, удовлетворяет ли какой-либо элемент последовательности условие.
    //
    // Параметры:
    //   source:
    //     System.Collections.Generic.IEnumerable`1 Элементы которой применяется предикат.
    //
    //   predicate:
    //     Функция для проверки каждого элемента на соответствие условию.
    //
    // Параметры типа:
    //   TSource:
    //     Тип элементов source.
    //
    // Возврат:
    //     true Если все элементы в исходной последовательности проходит проверку, определяемую
    //     указанным предикатом; в противном случае — false.
    //
    // Исключения:
    //   T:System.ArgumentNullException:
    //     Параметр source или predicate имеет значение null.
    class ProductModel
    {
        private int _id;
        private string _name;
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

    }
}
