using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionMaterialManager.Command;
using ConstructionMaterialManager.Modle;

namespace ConstructionMaterialManager.ViewModle
{
    public  class MainWindowVM : INotifyPropertyChanged
	{
		//Categories
		public List<string>	 Categories { get; } = new List<string> { "Concrete", "Steel", "Paint", "Tiles", "General" };
        public List<string> Units { get; } = new List<string> { "Ton", "kg", "m³", "m²", "Liter", "Piece" };

		public MyCommand AddNewMaterialCommand { get; set; }




        private Material _addedMaterial = new Material();

        public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			
        }

        public Material AddedMaterial
		{
			get { return _addedMaterial; }
			set { _addedMaterial = value; }
		}

		public int NoOfMaterials
        {
			get { return AppData.Materials.Count() ; }
			
			set
			{
				OnPropertyChanged(nameof(NoOfMaterials));
            }
        }



		public MainWindowVM()
		{
			
            AddNewMaterialCommand = new MyCommand(
    execute: (param) => { AppData.Materials.Add(AddedMaterial); OnPropertyChanged(nameof(NoOfMaterials)); },
    canExecute: (param) => { return AddedMaterial != null && !string.IsNullOrWhiteSpace(AddedMaterial.Name) && AddedMaterial.UnitPrice > 0; }
);
        }




    }
}
