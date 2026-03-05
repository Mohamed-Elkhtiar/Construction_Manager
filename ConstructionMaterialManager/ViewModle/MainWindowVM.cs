using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionMaterialManager.Command;
using ConstructionMaterialManager.Modle;

namespace ConstructionMaterialManager.ViewModle
{
    public class MainWindowVM 
    {
		//Categories
		public List<string> Categories { get; } = new List<string> { "Concrete", "Steel", "Paint", "Tiles", "General" };
        public List<string> Units { get; } = new List<string> { "Ton", "kg", "m³", "m²", "Liter", "Piece" };

		public MyCommand AddNewMaterialCommand { get; set; }




        private Material _addedMaterial = new Material();

		public Material AddedMaterial
		{
			get { return _addedMaterial; }
			set { _addedMaterial = value; }
		}

		private ObservableCollection<Material> _Materials;

		public ObservableCollection<Material> Materials
		{
			get { return _Materials; }
			set { _Materials = value; }
		}
		

		public int NoOfMaterials
        {
			get { return Materials.Count() ; }
			
		}



		public MainWindowVM()
		{
			Materials = new ObservableCollection<Material>
			{
				new Material { Name = "Cement", Category = "Building Material", Unit = "Bag", UnitPrice = 5.00m },
				new Material { Name = "Steel", Category = "Building Material", Unit = "Ton", UnitPrice = 500.00m },
				new Material { Name = "Bricks", Category = "Building Material", Unit = "Piece", UnitPrice = 0.50m }
			};

            AddNewMaterialCommand = new MyCommand(
    execute: (param) => { this.Materials.Add(AddedMaterial); },
    canExecute: (param) => { return AddedMaterial != null && !string.IsNullOrWhiteSpace(AddedMaterial.Name) && AddedMaterial.UnitPrice > 0; }
);
        }




    }
}
