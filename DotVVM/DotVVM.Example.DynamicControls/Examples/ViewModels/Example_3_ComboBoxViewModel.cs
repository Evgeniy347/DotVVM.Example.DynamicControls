using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class Example_3_ComboBoxViewModel : SiteViewModel
    {
        public string LiteralText { get; set; }


        public static List<Fruit> FruitsStatic { get; set; } = new List<Fruit>()
        {
            new Fruit { ID = 0, Name = "Apple" },
            new Fruit { ID = 1, Name = "Banana" },
            new Fruit { ID = 2, Name = "Orange" }
        };

        public List<Fruit> Fruits { get; set; } = FruitsStatic;

        public string NewValue { get; set; }
        public int SelectedFruitId { get; set; } = 1;







        public string[] Groups { get; set; } = { "Vegetables", "Fruits" };
        public string[] Items { get; set; }
        public string SelectedGroup { get; set; }
        public string SelectedItem { get; set; }


        public void GroupSelectionChanged()
        {
            if (SelectedGroup == "Fruits")
            {
                Items = new string[] { "Apple", "Banana", "Orange" };
            }
            else if (SelectedGroup == "Vegetables")
            {
                Items = new string[] { "Broccolini", "Lettuce", "Cabbage" };
            }
            else
            {
                Items = new string[] { };
            }
        }

        public void Click1()
        {
            Fruit fruit = Fruits.FirstOrDefault(x => x.ID == SelectedFruitId);

            LiteralText = $"ID:{fruit.ID} Name:{fruit.Name}";
        }


        public void Click2()
        {
            LiteralText = $"Group:{SelectedGroup} Item:{SelectedItem}";
        }


        public void AddItem()
        {
            Fruit item = new Fruit()
            {
                Name = NewValue,
                ID = Fruits.Max(x => x.ID) + 1,
            };

            Fruits.Add(item);

            SelectedFruitId = item.ID;
        }
    }

    public class Fruit
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}

