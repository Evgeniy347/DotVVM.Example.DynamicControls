using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using WSSC.V4.SYS.DotVVMReference.Examples.Controls;
using WSSC.V4.SYS.DotVVMReference.Examples.Data;
using WSSC.V4.SYS.DotVVMReference.Examples.Model;
using WSSC.V4.SYS.DotVVMReference.Extensions;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
{
    public class Example_7_DinamicGridView : SiteViewModel
    {
        private readonly BindingCompilationService bindingCompilationService;

        public Example_7_DinamicGridView(BindingCompilationService bindingCompilationService)
        {
            this.bindingCompilationService = bindingCompilationService;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public Category SelectedCategory { get; set; }

        //public BusinessPackDataSet<DataEntry> Data { get; set; } = new BusinessPackDataSet<DataEntry>();
        public GridViewDataSet<DataEntry> Data { get; set; } = new GridViewDataSet<DataEntry>();

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                InitializeData();
                RefreshData();
            }

            return base.PreRender();
        }

        private void RefreshData()
        {
            AddDynamicColumns();

            if (SelectedCategory.Id == 1)
            {
                Data.Items = new List<DataEntry>()
                {
                    new DataEntry() { Id = 1, Name = "Dog", PopulationSize = 50000000, MaxAge = 15 },
                    new DataEntry() { Id = 2, Name = "Elephant", PopulationSize = 100000, MaxAge = 80 }
                }
                .ToList();
            }
            else if (SelectedCategory.Id == 2)
            {
                Data.Items = new List<DataEntry>()
                {
                    new DataEntry() { Id = 1, Name = "BMW 5", EngineHorsePower = 300, ManufacturedYear = 2010, MaxSpeed = 260 },
                    new DataEntry() { Id = 2, Name = "Citroen C5", EngineHorsePower = 120, ManufacturedYear = 2009, MaxSpeed = 220 },
                    new DataEntry() { Id = 3, Name = "Alfa Romeo Giulia", EngineHorsePower = 180, ManufacturedYear = 2013, MaxSpeed = 250 }
                }
                .ToList();
            }
        }

        private void AddDynamicColumns()
        {
            bool isAllComulm = this.Context.HttpContext.Request.GetValueString("Columns") == "All";

            if (SelectedCategory.Id == 1)
            {
                if (isAllComulm || SelectedCategory.SelectedColumnNames.Contains(nameof(DataEntry.PopulationSize)))
                {
                    AddDynamicColumn<int>(nameof(DataEntry.PopulationSize));
                }
                if (isAllComulm || SelectedCategory.SelectedColumnNames.Contains(nameof(DataEntry.MaxAge)))
                {
                    AddDynamicColumn<int>(nameof(DataEntry.MaxAge));
                }
            }
            else if (SelectedCategory.Id == 2)
            {
                if (isAllComulm || SelectedCategory.SelectedColumnNames.Contains(nameof(DataEntry.EngineHorsePower)))
                {
                    AddDynamicColumn<int>(nameof(DataEntry.EngineHorsePower));
                }
                if (isAllComulm || SelectedCategory.SelectedColumnNames.Contains(nameof(DataEntry.ManufacturedYear)))
                {
                    AddDynamicColumn<int>(nameof(DataEntry.ManufacturedYear));
                }
                if (isAllComulm || SelectedCategory.SelectedColumnNames.Contains(nameof(DataEntry.MaxSpeed)))
                {
                    AddDynamicColumn<int>(nameof(DataEntry.MaxSpeed));
                }
            }
        }

        private void AddDynamicColumn<TType>(string propertyName)
        {
            var column = SelectedCategory.AllColumns.Single(c => c.PropertyName == propertyName);

            // get GridView
            //var gridView = (DotVVM.BusinessPack.Controls.GridView)Context.View.FindControlByClientId("GridView");
            var gridView = (GridView)Context.View.FindControlByClientId("GridView"); 

            // create the binding
            var dataContextStack = gridView.Columns[0].GetDataContextType();
            var param = Expression.Parameter(typeof(object[])); 
            var expression = Expression.Lambda<Func<object[], TType>>(Expression.Property(Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(0)), typeof(DataEntry)), propertyName), param);
            var binding = ValueBindingExpression.CreateBinding(bindingCompilationService, expression, dataContextStack);

            // create the column
            //var gridViewTextColumn = new DotVVM.BusinessPack.Controls.GridViewTextColumn(bindingCompilationService)
            var gridViewTextColumn = new GridViewTextColumn()
            {
                HeaderText = column.Name,
                //ColumnName = column.PropertyName,
                SortExpression = column.PropertyName
            };
            //gridViewTextColumn.SetBinding(DotVVM.BusinessPack.Controls.GridViewTextColumn.ValueProperty, binding);
            gridViewTextColumn.SetBinding(GridViewTextColumn.ValueBindingProperty, binding);
            gridView.Columns.Add(gridViewTextColumn);

            // add user settings
            //gridView.UserSettings.ColumnsSettings.Add(new GridViewColumnSettings
            //{
            //    ColumnName = column.PropertyName,
            //    DisplayOrder = gridView.Columns.Count - 1,
            //    DisplayText = column.Name,
            //    Visible = true
            //});
        }

        private void InitializeData()
        {
            Categories.Add(new Category()
            {
                Id = 1,
                Name = "Animals",
                AllColumns =
                {
                    new CategoryColumn()
                    {
                        PropertyName = nameof(DataEntry.PopulationSize),
                        Name = "Population"
                    },
                    new CategoryColumn()
                    {
                        PropertyName = nameof(DataEntry.MaxAge),
                        Name = "Max Age"
                    }
                }
            });
            Categories.Add(new Category()
            {
                Id = 2,
                Name = "Vehicles",
                AllColumns =
                {
                    new CategoryColumn()
                    {
                        PropertyName = nameof(DataEntry.EngineHorsePower),
                        Name = "HP"
                    },
                    new CategoryColumn()
                    {
                        PropertyName = nameof(DataEntry.MaxSpeed),
                        Name = "Max Speed"
                    },
                    new CategoryColumn()
                    {
                        PropertyName = nameof(DataEntry.ManufacturedYear),
                        Name = "Manufactured Year"
                    }
                }
            });

            int catID = this.Context.HttpContext.Request.GetValueInt("CategoryID");

            SelectedCategory = Categories.FirstOrDefault(x => x.Id == catID) ??
                Categories.First();
        }

        public void Refresh()
        {
            RefreshData();
        }

        //public void Export()
        //{
        //    RefreshData();

        //    var gridView = (DotVVM.BusinessPack.Controls.GridView)Context.View.FindControlByClientId("GridView");
        //    var export = new DotVVM.BusinessPack.Export.Excel.GridViewExportExcel<DataEntry>(bindingCompilationService);
        //    var result = export.Export(gridView, Data);
        //    Context.ReturnFile(result, "export.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        //}
    }

    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<CategoryColumn> AllColumns { get; set; } = new List<CategoryColumn>();

        public List<string> SelectedColumnNames { get; set; } = new List<string>();
    }

    public class CategoryColumn
    {

        public string Name { get; set; }

        public string PropertyName { get; set; }

    }

    public class DataEntry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // animal
        public int PopulationSize { get; set; }

        public int MaxAge { get; set; }


        // vehicle
        public int MaxSpeed { get; set; }

        public int EngineHorsePower { get; set; }

        public int ManufacturedYear { get; set; }
    }
}

