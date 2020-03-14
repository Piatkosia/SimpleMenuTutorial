using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMenuTutorial
{
    public class Menu
    {
        private List<MenuItem> Items;

        private MenuItem SelectedItem
        {
            get
            {
                return Items.FirstOrDefault(x => x.IsSelected == true);
            }
        }

        private int SelectedIndex
        {
            get { return Items.IndexOf(SelectedItem); }
        }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void MoveNext()
        {
            if (SelectedItem != Items.Last())
            {
                var newIndex = SelectedIndex + 1;
                SelectedItem.IsSelected = false;
                Items[newIndex].IsSelected = true;
            }
        }
        public void MoveBack()
        {
            if (SelectedItem != Items.First())
            {
                var newIndex = SelectedIndex - 1;
                SelectedItem.IsSelected = false;
                Items[newIndex].IsSelected = true;
            }
        }

        public void Invoke(object parameter = null)
        {
            SelectedItem.Invoke(parameter);
        }

        public void Add(MenuItem menuItem)
        {
            Items.Add(menuItem);
            if (Items.Count == 1)
            {
                menuItem.IsSelected = true;
            }
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (var item in Items)
            {
                if (item.IsSelected) Console.WriteLine($"**{item.ItemName}**");
                else Console.WriteLine(item.ItemName);
            }
            Console.WriteLine();
        }
    }
}
