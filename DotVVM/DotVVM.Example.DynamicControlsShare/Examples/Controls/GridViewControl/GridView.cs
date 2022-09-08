#region сборка DotVVM.BusinessPack, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f
// C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.4.0.5-trial\lib\net472\DotVVM.BusinessPack.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DotVVM.BusinessPack.Controls.FilterOperators;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Compilation.Javascript;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Utils;
using DotVVM.Utils.HtmlElements;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{ 
    //
    // Сводка:
    //     Renders an HTML table with support for sorting, paging, filtering, grouping and
    //     other advanced features.
    [ControlMarkupOptions(AllowContent = false, DefaultContentProperty = "Columns")]
    public class GridView : ItemsControlBase<IBusinessPackDataSet>
    {
        public static readonly DotvvmProperty ColumnsProperty = DotvvmProperty.Register<List<GridViewColumn>, GridView>((GridView c) => c.Columns);

        public static readonly DotvvmProperty HeaderTemplateProperty = DotvvmProperty.Register<ITemplate, GridView>((GridView c) => c.HeaderTemplate);

        public static readonly DotvvmProperty FooterTemplateProperty = DotvvmProperty.Register<ITemplate, GridView>((GridView c) => c.FooterTemplate);

        public static readonly DotvvmProperty FilterPlacementProperty = DotvvmProperty.Register((GridView c) => c.FilterPlacement, GridViewFilterPlacement.Popup);

        public static readonly DotvvmProperty FilterInlineProperty = DotvvmProperty.Register((GridView c) => c.FilterInline, defaultValue: false);

        public static readonly DotvvmProperty StringOperatorsProperty = DotvvmProperty.Register<List<IStringOperator>, GridView>((GridView c) => c.StringOperators);

        public static readonly DotvvmProperty NumberOperatorsProperty = DotvvmProperty.Register<List<INumberOperator>, GridView>((GridView c) => c.NumberOperators);

        public static readonly DotvvmProperty DateTimeOperatorsProperty = DotvvmProperty.Register<List<IDateTimeOperator>, GridView>((GridView c) => c.DateTimeOperators);

        public static readonly DotvvmProperty BooleanOperatorsProperty = DotvvmProperty.Register<List<IBooleanOperator>, GridView>((GridView c) => c.BooleanOperators);

        public static readonly DotvvmProperty EnumOperatorsProperty = DotvvmProperty.Register<List<IEnumOperator>, GridView>((GridView c) => c.EnumOperators);

        public static readonly DotvvmProperty CollectionOperatorsProperty = DotvvmProperty.Register<List<ICollectionOperator>, GridView>((GridView c) => c.CollectionOperators);

        public static readonly DotvvmProperty RowDetailTemplateProperty = DotvvmProperty.Register<ITemplate, GridView>((GridView c) => c.RowDetailTemplate);

        public static readonly DotvvmProperty RowHasDetailBindingProperty = DotvvmProperty.Register<IValueBinding<bool?>, GridView>((GridView c) => c.RowHasDetailBinding);

        public static readonly DotvvmProperty ShowTableWhenNoDataProperty = DotvvmProperty.Register((GridView t) => t.ShowTableWhenNoData, defaultValue: false);

        public static readonly DotvvmProperty FixedHeaderRowProperty = DotvvmProperty.Register((GridView t) => t.FixedHeaderRow, defaultValue: false);

        public static readonly DotvvmProperty EmptyDataTemplateProperty = DotvvmProperty.Register<ITemplate, GridView>((GridView t) => t.EmptyDataTemplate);

        public static readonly DotvvmProperty RowDecoratorsProperty = DotvvmProperty.Register<List<Decorator>, GridView>((GridView c) => c.RowDecorators);

        public static readonly DotvvmProperty InlineEditModeProperty = DotvvmProperty.Register((GridView t) => t.InlineEditMode, GridViewInlineEditMode.Disabled);

        public static readonly DotvvmProperty EditRowDecoratorsProperty = DotvvmProperty.Register<List<Decorator>, GridView>((GridView c) => c.EditRowDecorators);

        public static readonly DotvvmProperty AllowInlineInsertProperty = DotvvmProperty.Register((GridView t) => t.AllowInlineInsert, defaultValue: false);

        public static readonly DotvvmProperty AllowReorderColumnsProperty = DotvvmProperty.Register((GridView c) => c.AllowReorderColumns, defaultValue: false);

        public static readonly DotvvmProperty AllowColumnResizingProperty = DotvvmProperty.Register((GridView c) => c.AllowColumnResizing, defaultValue: false);

        public static readonly DotvvmProperty InsertRowPlacementProperty = DotvvmProperty.Register((GridView t) => t.InsertRowPlacement, GridViewInsertRowPlacement.Top);

        public static readonly DotvvmProperty InsertRowDecoratorsProperty = DotvvmProperty.Register<List<Decorator>, GridView>((GridView c) => c.InsertRowDecorators);

        public static readonly DotvvmProperty UserSettingsProperty = DotvvmProperty.Register<GridViewUserSettings, GridView>((GridView c) => c.UserSettings);

        public static readonly DotvvmProperty UserSettingsChangedProperty = DotvvmProperty.Register<Command, GridView>((GridView c) => c.UserSettingsChanged);

        public static readonly DotvvmProperty FilterIconProperty = DotvvmProperty.Register<IconBase, GridView>((GridView t) => t.FilterIcon);

        public static readonly DotvvmProperty SortAscIconProperty = DotvvmProperty.Register<IconBase, GridView>((GridView t) => t.SortAscIcon);

        public static readonly DotvvmProperty SortDescIconProperty = DotvvmProperty.Register<IconBase, GridView>((GridView t) => t.SortDescIcon);

        //
        // Сводка:
        //     Gets or sets a list of columns describing how to render each row.
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        [MarkupOptions(Required = true, AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        [CollectionElementDataContextChange(1)]
        public List<GridViewColumn> Columns
        {
            get
            {
                return (List<GridViewColumn>)GetValue(ColumnsProperty);
            }
            set
            {
                SetValue(ColumnsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a template for the header displayed before the table.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public ITemplate HeaderTemplate
        {
            get
            {
                return (ITemplate)GetValue(HeaderTemplateProperty);
            }
            set
            {
                SetValue(HeaderTemplateProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a template for the footer displayed after the table.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public ITemplate FooterTemplate
        {
            get
            {
                return (ITemplate)GetValue(FooterTemplateProperty);
            }
            set
            {
                SetValue(FooterTemplateProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets where to render contents of the DotVVM.BusinessPack.Controls.GridViewColumn.FilterTemplate.
        //     The default value is DotVVM.BusinessPack.Controls.GridViewFilterPlacement.Popup.
        [MarkupOptions(AllowBinding = false)]
        public GridViewFilterPlacement FilterPlacement
        {
            get
            {
                return (GridViewFilterPlacement)DotvvmControlExtensions.GetValueOrDefault((DotvvmBindableObject)this, FilterPlacementProperty, true);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<GridViewFilterPlacement>(FilterPlacementProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether the filter content should be displayed in a single line.
        [MarkupOptions(AllowBinding = false)]
        public bool FilterInline
        {
            get
            {
                return (bool)DotvvmControlExtensions.GetValueOrDefault((DotvvmBindableObject)this, FilterInlineProperty, true);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(FilterInlineProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators available to compare strings.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<IStringOperator> StringOperators
        {
            get
            {
                return (List<IStringOperator>)GetValue(StringOperatorsProperty);
            }
            set
            {
                SetValue(StringOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators available to compare numbers.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<INumberOperator> NumberOperators
        {
            get
            {
                return (List<INumberOperator>)GetValue(NumberOperatorsProperty);
            }
            set
            {
                SetValue(NumberOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators available to compare dates.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<IDateTimeOperator> DateTimeOperators
        {
            get
            {
                return (List<IDateTimeOperator>)GetValue(DateTimeOperatorsProperty);
            }
            set
            {
                SetValue(DateTimeOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators available to compare booleans.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<IBooleanOperator> BooleanOperators
        {
            get
            {
                return (List<IBooleanOperator>)GetValue(BooleanOperatorsProperty);
            }
            set
            {
                SetValue(BooleanOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators to compare enums.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<IEnumOperator> EnumOperators
        {
            get
            {
                return (List<IEnumOperator>)GetValue(EnumOperatorsProperty);
            }
            set
            {
                SetValue(EnumOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a collection of operators to compare collections.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<ICollectionOperator> CollectionOperators
        {
            get
            {
                return (List<ICollectionOperator>)GetValue(CollectionOperatorsProperty);
            }
            set
            {
                SetValue(CollectionOperatorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a template used to render detail for each data item.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        [CollectionElementDataContextChange(1)]
        public ITemplate RowDetailTemplate
        {
            get
            {
                return (ITemplate)GetValue(RowDetailTemplateProperty);
            }
            set
            {
                SetValue(RowDetailTemplateProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets the binding indicating whether to display a detail for a specific
        //     data item.
        [CollectionElementDataContextChange(1)]
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        public IValueBinding<bool?> RowHasDetailBinding
        {
            get
            {
                return (IValueBinding<bool?>)GetValue(RowHasDetailBindingProperty);
            }
            set
            {
                SetValue(RowHasDetailBindingProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether to display the table when the data source is empty. The
        //     default value is false.
        [MarkupOptions(AllowBinding = false)]
        public bool ShowTableWhenNoData
        {
            get
            {
                return (bool)GetValue(ShowTableWhenNoDataProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(ShowTableWhenNoDataProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether the header row is freezed while user scrolls table's content.
        //     The default value is false.
        [MarkupOptions(AllowBinding = false)]
        public bool FixedHeaderRow
        {
            get
            {
                return (bool)GetValue(FixedHeaderRowProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(FixedHeaderRowProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a template displayed when the data source is empty.
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public ITemplate EmptyDataTemplate
        {
            get
            {
                return (ITemplate)GetValue(EmptyDataTemplateProperty);
            }
            set
            {
                SetValue(EmptyDataTemplateProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a list of decorators applied on each row not in edit mode.
        [CollectionElementDataContextChange(1)]
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public List<Decorator> RowDecorators
        {
            get
            {
                return (List<Decorator>)GetValue(RowDecoratorsProperty);
            }
            set
            {
                SetValue(RowDecoratorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether rows in the data source can be edited inline. The default
        //     value is DotVVM.BusinessPack.Controls.GridViewInlineEditMode.Disabled.
        [MarkupOptions(AllowBinding = false)]
        public GridViewInlineEditMode InlineEditMode
        {
            get
            {
                return (GridViewInlineEditMode)GetValue(InlineEditModeProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<GridViewInlineEditMode>(InlineEditModeProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a list of decorators applied on each row in edit mode.
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        [CollectionElementDataContextChange(1)]
        public List<Decorator> EditRowDecorators
        {
            get
            {
                return (List<Decorator>)GetValue(EditRowDecoratorsProperty);
            }
            set
            {
                SetValue(EditRowDecoratorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether new rows can be inserted into the data source. The default
        //     value is false.
        [MarkupOptions(AllowBinding = false)]
        public bool AllowInlineInsert
        {
            get
            {
                return (bool)GetValue(AllowInlineInsertProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(AllowInlineInsertProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether the user can reorder the columns.
        [MarkupOptions(AllowBinding = false)]
        public bool AllowReorderColumns
        {
            get
            {
                return (bool)GetValue(AllowReorderColumnsProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(AllowReorderColumnsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether the user can resize columns
        public bool AllowColumnResizing
        {
            get
            {
                return (bool)GetValue(AllowColumnResizingProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<bool>(AllowColumnResizingProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets whether the insert row should be rendered on top (after the header)
        //     or on bottom (before the footer). The default value is DotVVM.BusinessPack.Controls.GridViewInsertRowPlacement.Top.
        [MarkupOptions(AllowBinding = false)]
        public GridViewInsertRowPlacement InsertRowPlacement
        {
            get
            {
                return (GridViewInsertRowPlacement)GetValue(InsertRowPlacementProperty);
            }
            set
            {
                ((DotvvmBindableObject)this).SetValue<GridViewInsertRowPlacement>(InsertRowPlacementProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a list of decorators applied on the insert row.
        [CollectionElementDataContextChange(1)]
        [ControlPropertyBindingDataContextChange("DataSource", 0)]
        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public List<Decorator> InsertRowDecorators
        {
            get
            {
                return (List<Decorator>)GetValue(InsertRowDecoratorsProperty);
            }
            set
            {
                SetValue(InsertRowDecoratorsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets the current settings. It can be used to persist user's configuration
        //     like column visibility, order, width, etc.
        [MarkupOptions(AllowHardCodedValue = false)]
        public GridViewUserSettings UserSettings
        {
            get
            {
                return (GridViewUserSettings)GetValue(UserSettingsProperty);
            }
            set
            {
                SetValue(UserSettingsProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets a command that will be executed when the user changes the user settings.
        [MarkupOptions(AllowHardCodedValue = false)]
        public Command UserSettingsChanged
        {
            get
            {
                return (Command)GetValue(UserSettingsChangedProperty);
            }
            set
            {
                SetValue(UserSettingsChangedProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets the icon rendered inside the button used to open filter popup.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public IconBase FilterIcon
        {
            get
            {
                return (IconBase)GetValue(FilterIconProperty);
            }
            set
            {
                SetValue(FilterIconProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets the icon rendered inside the button used to change sorting from
        //     ascending to descending.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public IconBase SortAscIcon
        {
            get
            {
                return (IconBase)GetValue(SortAscIconProperty);
            }
            set
            {
                SetValue(SortAscIconProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets or sets the icon rendered inside the button used to change sorting from
        //     descending to ascending.
        [MarkupOptions(MappingMode = MappingMode.InnerElement)]
        public IconBase SortDescIcon
        {
            get
            {
                return (IconBase)GetValue(SortDescIconProperty);
            }
            set
            {
                SetValue(SortDescIconProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets whether the data source is empty.
        protected override bool IsDataSourceEmpty
        {
            get
            {
                IBusinessPackDataSet dataSource = DataSource;
                return dataSource != null && dataSource.Items.Count == 0 && DataSource?.RowInsertOptions.InsertedRow == null;
            }
        }

        //
        // Сводка:
        //     Gets wheter any filter is applied.
        protected virtual bool IsAnyFilterApplied
        {
            get
            {
                IBusinessPackDataSet dataSource = DataSource;
                return dataSource != null && dataSource.FilteringOptions?.FilterGroup?.Filters.Count > 0;
            }
        }

        //
        // Сводка:
        //     Gets whether footer is required to be rendered.
        protected virtual bool RenderFooter => FooterTemplate != null || Columns.Any((GridViewColumn c) => c.RenderFooter) || FilterPlacement == GridViewFilterPlacement.SeparateFooterRow;

        //
        // Сводка:
        //     Gets the number of columns to be rendered.
        protected virtual int ColumnsCount => Columns.Count;

        public GridView(BindingCompilationService bindingService)
            : base("div", bindingService)
        {
        }

        public override IEnumerable<DotvvmBindableObject> GetLogicalChildren()
        {
            IEnumerable<DotvvmBindableObject> enumerable = base.GetLogicalChildren().Concat(Columns);
            if (RowDecorators != null)
            {
                enumerable = enumerable.Concat(RowDecorators);
            }

            if (EditRowDecorators != null)
            {
                enumerable = enumerable.Concat(EditRowDecorators);
            }

            if (InsertRowDecorators != null)
            {
                enumerable = enumerable.Concat(InsertRowDecorators);
            }

            return enumerable;
        }

        protected override void OnInit(IDotvvmRequestContext context)
        {
            InitializeColumnNames();
            if (AllowReorderColumns)
            {
                context.ResourceManager.AddRequiredResource(BusinessPackResources.JQuerySortableScript);
            }

            base.OnInit(context);
        }

        protected override void OnLoad(IDotvvmRequestContext context)
        {
            InitializeUserSettings();
            if (FilterIcon == null)
            {
                IconBase iconBase2 = (FilterIcon = CreateFilterIcon());
            }

            if (SortAscIcon == null)
            {
                IconBase iconBase2 = (SortAscIcon = CreateSortAscIcon());
            }

            if (SortDescIcon == null)
            {
                IconBase iconBase2 = (SortDescIcon = CreateSortDescIcon());
            }

            if (context.IsPostBack)
            {
                PopulateChildren(useServerTemplate: true);
            }

            base.OnLoad(context);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            PopulateChildren(RenderOnServer || context.IsPostBack);
            base.OnPreRender(context);
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            HtmlWriterExtensions.AddCssClass(writer, BusinessPackCss.GridView);
            if (FixedHeaderRow)
            {
                HtmlWriterExtensions.AddCssClass(writer, BusinessPackCss.GridViewFixedHeader);
            }

            writer.AddControlKnockoutDataBind(ControlName, GetControlBinding());
            if (EmptyDataTemplate == null)
            {
                base.CssClasses.AddBinding(BusinessPackCss.StateDataEmpty, GetIsDataSourceEmptyBinding());
            }

            base.AddAttributesToRender(writer, context);
        }

        //
        // Сводка:
        //     Initializes the DotVVM.BusinessPack.Controls.GridView.UserSettings with current
        //     values when the property is bound to null.
        protected virtual void InitializeUserSettings()
        {
            if (base.DataContext == null)
            {
                return;
            }

            EnsureUniqueColumnNames();
            if (UserSettings == null)
            {
                GridViewUserSettings gridViewUserSettings = new GridViewUserSettings();
                int num = 0;
                foreach (GridViewColumn column in Columns)
                {
                    gridViewUserSettings.ColumnsSettings.Add(new GridViewColumnSettings
                    {
                        ColumnName = column.GetColumnName(num),
                        DisplayOrder = num,
                        DisplayText = column.HeaderText,
                        Visible = true
                    });
                    num++;
                }

                if (HasBinding(UserSettingsProperty))
                {
                    this.SetValueToSource(UserSettingsProperty, (object)gridViewUserSettings);
                }
                else
                {
                    UserSettings = gridViewUserSettings;
                }
            }
            else
            {
                ValidateAndCorrectExistingUserSettings();
            }
        }

        private void ValidateAndCorrectExistingUserSettings()
        {
            List<GridViewColumnSettings> list = UserSettings.ColumnsSettings?.OrderBy((GridViewColumnSettings c) => c.DisplayOrder).ToList() ?? new List<GridViewColumnSettings>();
            List<string> gridColumnNames = Columns.Select((GridViewColumn c, int i) => c.GetColumnName(i)).ToList();
            list.RemoveAll((GridViewColumnSettings c) => !gridColumnNames.Contains(c.ColumnName));
            int j;
            for (j = 0; j < gridColumnNames.Count; j++)
            {
                string columnName = gridColumnNames[j];
                int num = list.FindIndex((GridViewColumnSettings c) => c.ColumnName == columnName);
                if (num >= 0)
                {
                    continue;
                }

                int num2 = -1;
                if (j > 0)
                {
                    num2 = list.FindIndex((GridViewColumnSettings c) => c.ColumnName == gridColumnNames[j - 1]);
                }

                list.Insert(num2 + 1, new GridViewColumnSettings
                {
                    ColumnName = columnName,
                    DisplayOrder = 0,
                    Visible = true
                });
            }

            for (int k = 0; k < list.Count; k++)
            {
                list[k].DisplayOrder = k;
            }

            UserSettings.ColumnsSettings.Clear();
            list.ForEach(UserSettings.ColumnsSettings.Add);
        }

        //
        // Сводка:
        //     Performs the data-binding and builds controls inside the DotVVM.BusinessPack.Controls.GridView.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual void PopulateChildren(bool useServerTemplate)
        {
            base.Children.Clear();
            if (RowDetailTemplate != null)
            {
                base.Children.Add(CreateClientRowDetailTemplate());
            }

            if (useServerTemplate)
            {
                if (!IsDataSourceEmpty || IsAnyFilterApplied || ShowTableWhenNoData)
                {
                    base.Children.Add(CreateTable(useServerTemplate: true));
                    return;
                }

                HtmlGenericControl htmlGenericControl = CreateTable(useServerTemplate: true);
                ((DotvvmBindableObject)htmlGenericControl).SetValue<bool>(HtmlGenericControl.VisibleProperty, false);
                base.Children.Add(htmlGenericControl);
                if (EmptyDataTemplate != null)
                {
                    base.Children.Add(CreateEmptyContents());
                }

                return;
            }

            base.Children.Add(CreateClientInsertRowTemplate());
            base.Children.Add(CreateClientRowTemplate(isInEditMode: false));
            base.Children.Add(CreateClientRowTemplate(isInEditMode: true));
            if (ShowTableWhenNoData)
            {
                base.Children.Add(CreateTable(useServerTemplate: false));
                return;
            }

            HtmlGenericControl htmlGenericControl2 = CreateTable(useServerTemplate: false);
            htmlGenericControl2.SetJsValueBinding((HtmlGenericControl c) => c.Visible, "!$bp" + ControlName + ".isNotFilteredDataSourceEmpty");
            base.Children.Add(htmlGenericControl2);
            if (EmptyDataTemplate != null)
            {
                DotvvmControl dotvvmControl = CreateEmptyContents();
                dotvvmControl.SetJsValueBinding((DotvvmControl c) => c.IncludeInPage, "$bp" + ControlName + ".isNotFilteredDataSourceEmpty");
                base.Children.Add(dotvvmControl);
            }
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl representing the main <table>
        //     element.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual HtmlGenericControl CreateTable(bool useServerTemplate)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("table"); 
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.PrimitiveTable);
            htmlGenericControl.Children.Add(CreateColgroup());
            htmlGenericControl.Children.Add(CreateHeader());
            htmlGenericControl.Children.Add(CreateBody(useServerTemplate));
            if (RenderFooter)
            {
                htmlGenericControl.Children.Add(CreateFooter());
            }

            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <colgroup> element containing column definitions.
        protected virtual HtmlGenericControl CreateColgroup()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("colgroup");
            htmlGenericControl.Children.Add(Columns.Select(CreateCol));
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <col> element representing the column's definition.
        //
        // Параметры:
        //   column:
        //     The column to create the definition for.
        protected virtual HtmlGenericControl CreateCol(GridViewColumn column)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("col");
            column.BuildCol(htmlGenericControl);
            htmlGenericControl.Attributes.Set("data-column", (object)GetColumnName(column));
            AddWidthDataBinding(htmlGenericControl, column);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <thead> element representing the DotVVM.BusinessPack.Controls.GridView
        //     header.
        protected virtual HtmlGenericControl CreateHeader()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("thead");
            if (HeaderTemplate != null)
            {
                htmlGenericControl.Children.Add(CreateHeaderRow());
            }

            htmlGenericControl.Children.Add(CreateColumnHeaderRow());
            if (FilterPlacement == GridViewFilterPlacement.SeparateHeaderRow)
            {
                htmlGenericControl.Children.Add(CreateFilterRow("th"));
            }

            if (FixedHeaderRow)
            {
                DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewFixedHeaderRow);
            }

            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <tr> element representing the header rendered before table.
        protected virtual HtmlGenericControl CreateHeaderRow()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewHeaderRow);
            HtmlGenericControl htmlGenericControl2 = new HtmlGenericControl("th");
            htmlGenericControl2.Attributes.Set("colspan", (object)ColumnsCount.ToString());
            DotvvmControlCollectionExtensions.Add(htmlGenericControl2.Children, HeaderTemplate);
            htmlGenericControl.Children.Add(htmlGenericControl2);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <tr> element containing column headers.
        protected virtual HtmlGenericControl CreateColumnHeaderRow()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewColumnHeaderRow);
            htmlGenericControl.Children.Add(Columns.Select(CreateColumnHeaderCell));
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <th> element representing the column's header.
        //
        // Параметры:
        //   column:
        //     The column to create the header for.
        protected virtual HtmlGenericControl CreateColumnHeaderCell(GridViewColumn column)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("th");
            AddVisibleDataBinding(htmlGenericControl, column, isInBody: false);
            AddHeaderTextDataBinding(column);
            htmlGenericControl.Attributes.Add("class", DotvvmControlExtensions.GetValueRaw<GridViewColumn, string>(column, (Expression<Func<GridViewColumn, string>>)((GridViewColumn c) => c.HeaderCssClass), true));
            AddSortCssDataBinding(htmlGenericControl, column);
            htmlGenericControl.Attributes.Set("data-column", (object)GetColumnName(column));
            HtmlGenericControl htmlGenericControl2 = new HtmlGenericControl("div");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl2, BusinessPackCss.PrimitiveContents);
            column.BuildHeader(htmlGenericControl2);
            if (column.AllowFiltering)
            {
                if (FilterPlacement == GridViewFilterPlacement.Popup)
                {
                    htmlGenericControl2.Children.Add((DotvvmControl)(object)CreateFilterPopup(column));
                }
                else if (FilterPlacement == GridViewFilterPlacement.HeaderRow)
                {
                    column.BuildFilter(htmlGenericControl2);
                }
            }

            if (AllowColumnResizing)
            {
                HtmlGenericControl htmlGenericControl3 = new HtmlGenericControl("div");
                DotvvmBindableObjectHelper2.AddCssClasses<HtmlGenericControl>(htmlGenericControl3, new string[2]
                {
                    BusinessPackCss.GridViewColumnResizeGrip,
                    BusinessPackCss.PrimitiveGrip
                });
                htmlGenericControl2.Children.Add(htmlGenericControl3);
            }

            htmlGenericControl.Children.Add(htmlGenericControl2);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a DotVVM.BusinessPack.Controls.DropDownButton containing the column's
        //     filter.
        //
        // Параметры:
        //   column:
        //     The column to create the filter popup for.
        protected virtual DropDownButton CreateFilterPopup(GridViewColumn column)
        {
            DropDownButton dropDownButton = new DropDownButton(base.BindingService);
            dropDownButton.ContentTemplate = new DelegateTemplate((IServiceProvider _) => (DotvvmControl)(object)FilterIcon.Clone());
            dropDownButton.PopupTemplate = new DelegateTemplate(delegate (IServiceProvider _, DotvvmControl c)
            {
                column.BuildFilter(c);
            });
            return dropDownButton;
        }

        //
        // Сводка:
        //     Returns an icon rendered inside the button used to open filter popup.
        protected virtual IconBase CreateFilterIcon()
        {
            return new Icon(base.BindingService)
            {
                Icon = IconType.Filter
            };
        }

        //
        // Сводка:
        //     Returns a <tr> element containing column filters.
        //
        // Параметры:
        //   cellTagName:
        protected virtual HtmlGenericControl CreateFilterRow(string cellTagName)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewFilterRow);
            htmlGenericControl.Children.Add(Columns.Select((GridViewColumn column) => CreateFilterCell(column, cellTagName)));
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <th> element representing the column's filter.
        //
        // Параметры:
        //   column:
        //     The column to create the filter for.
        //
        //   cellTagName:
        protected virtual HtmlGenericControl CreateFilterCell(GridViewColumn column, string cellTagName)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl(cellTagName);
            AddVisibleDataBinding(htmlGenericControl, column, isInBody: false);
            htmlGenericControl.Attributes.Add("class", column.GetValueRaw(GridViewColumn.HeaderCssClassProperty));
            if (column.AllowFiltering)
            {
                column.BuildFilter(htmlGenericControl);
            }

            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns an DotVVM.Framework.Controls.DotvvmControl containing the DotVVM.BusinessPack.Controls.GridView
        //     body.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual DotvvmControl CreateBody(bool useServerTemplate)
        {
            PlaceHolder placeHolder = new PlaceHolder();
            bool flag = RenderInsertRow(useServerTemplate);
            if (flag && InsertRowPlacement == GridViewInsertRowPlacement.Top)
            {
                placeHolder.Children.Add(CreateInsertBody(useServerTemplate));
            }

            if (useServerTemplate)
            {
                if (!IsDataSourceEmpty)
                {
                    placeHolder.Children.Add(CreateRowRepeater(useServerTemplate: true));
                }
                else if (EmptyDataTemplate != null)
                {
                    placeHolder.Children.Add(CreateEmptyBody());
                }
            }
            else
            {
                placeHolder.Children.Add((DotvvmControl)(object)DotvvmControlExtensions.WrapWithKoComment((DotvvmControl)CreateRowRepeater(useServerTemplate: false), "if", "!$bp" + ControlName + ".isDataSourceEmpty"));
                if (EmptyDataTemplate != null)
                {
                    placeHolder.Children.Add((DotvvmControl)(object)DotvvmControlExtensions.WrapWithKoComment((DotvvmControl)CreateEmptyBody(), "if", "$bp" + ControlName + ".isDataSourceEmpty"));
                }
            }

            if (flag && InsertRowPlacement == GridViewInsertRowPlacement.Bottom)
            {
                placeHolder.Children.Add(CreateInsertBody(useServerTemplate));
            }

            return placeHolder;
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl representing the <tbody> element
        //     containing the insert row.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual DotvvmControl CreateInsertBody(bool useServerTemplate)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tbody");
            htmlGenericControl.DataContext = CreateInsertedRowValueBinding();
            htmlGenericControl.SetValue(Internal.PathFragmentProperty, GetPathFragmentExpression() + "/RowInsertOptions/InsertedRow");
            htmlGenericControl.SetValue(Internal.DataContextTypeProperty, GetDataSourceBinding().GetProperty<CollectionElementDataContextBindingProperty>().get_DataContext());
            htmlGenericControl.Children.Add(CreateInsertRow(useServerTemplate));
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a value binding that retrieves an inserted row from the data source.
        protected virtual IValueBinding CreateInsertedRowValueBinding()
        {
            return ValueBindingExpression.CreateBinding(base.BindingService.WithoutInitialization(), (object?[] _) => DataSource?.RowInsertOptions.InsertedRow, new ParametrizedCode("$bp" + ControlName + ".getInsertedRow()"));
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl representing a row used to
        //     insert new items to the data source.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual DotvvmControl CreateInsertRow(bool useServerTemplate)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            if (useServerTemplate)
            {
                htmlGenericControl.Children.Add(Columns.Select(CreateInsertCell));
            }
            else
            {
                DotvvmControlExtensions.AddKoTemplateDataBinding((IControlWithHtmlAttributes)htmlGenericControl, "InsertRowTemplate", (string)null);
            }

            return Decorator.ApplyDecorators((DotvvmControl)htmlGenericControl, (IEnumerable<Decorator>)(InsertRowDecorators ?? EditRowDecorators));
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl containing a client-side template
        //     used to render the insert row.
        protected virtual DotvvmControl CreateClientInsertRowTemplate()
        {
            //IL_0036: Unknown result type (might be due to invalid IL or missing references)
            //IL_003c: Expected O, but got Unknown
            ClientDataItemContainer clientDataItemContainer = new ClientDataItemContainer();
            clientDataItemContainer.SetValue(Internal.PathFragmentProperty, GetPathFragmentExpression() + "/RowInsertOptions/InsertedRow");
            clientDataItemContainer.SetDataContextTypeFromDataSource(GetDataSourceBinding());
            HtmlKoTemplate val = new HtmlKoTemplate("InsertRowTemplate");
            ((DotvvmControl)(object)val).Children.Add(Columns.Select(CreateInsertCell));
            clientDataItemContainer.Children.Add((DotvvmControl)(object)val);
            return clientDataItemContainer;
        }

        //
        // Сводка:
        //     Returns a <td> element representing a cell in the insert row.
        //
        // Параметры:
        //   column:
        //     The column to create the insert cell for.
        protected virtual HtmlGenericControl CreateInsertCell(GridViewColumn column)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("td");
            AddVisibleDataBinding(htmlGenericControl, column, isInBody: true);
            htmlGenericControl.Attributes.Add("class", column.GetValueRaw(GridViewColumn.InsertCssClassProperty));
            column.BuildInsertCell(htmlGenericControl, column);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.Repeater rendering <tbody> element containing
        //     rows.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual Repeater CreateRowRepeater(bool useServerTemplate)
        {
            //IL_009a: Unknown result type (might be due to invalid IL or missing references)
            //IL_00ae: Unknown result type (might be due to invalid IL or missing references)
            //IL_00b8: Expected O, but got Unknown
            Repeater repeater = new Repeater();
            repeater.WrapperTagName = "tbody";
            DotvvmBindableObjectHelper.SetProperty<Repeater, object>(repeater, (Expression<Func<Repeater, object>>)((Repeater c) => c.DataSource), (IBinding)GetDataSourceBinding());
            repeater.SetValue(Internal.UniqueIDProperty, GetValue(Internal.UniqueIDProperty)?.ToString() + "r1");
            repeater.ItemTemplate = (ITemplate)(useServerTemplate ? new DataItemTemplate((Action<DataItemContainer>)BuildServerItemTemplate) : new DataItemTemplate((Action<DataItemContainer>)BuildClientItemTemplate));
            return repeater;
        }

        //
        // Сводка:
        //     Builds template used to render items in the DotVVM.Framework.Controls.Repeater
        //     on server-side.
        protected virtual void BuildServerItemTemplate(DataItemContainer container)
        {
            object item = ((!container.DataItemIndex.HasValue) ? null : GetItems().ElementAt(container.DataItemIndex.Value));
            container.Children.Add(CreateRow(useServerTemplate: true, IsItemInEditMode(item)));
        }

        //
        // Сводка:
        //     Builds template used to render items in the DotVVM.Framework.Controls.Repeater
        //     on client-side.
        protected virtual void BuildClientItemTemplate(DataItemContainer container)
        {
            if (InlineEditMode == GridViewInlineEditMode.SingleRow)
            {
                container.Children.Add((DotvvmControl)(object)DotvvmControlExtensions.WrapWithKoComment(CreateRow(useServerTemplate: false, isInEditMode: true), "if", "$bp" + ControlName + ".isItemInEditMode($data)"));
                container.Children.Add((DotvvmControl)(object)DotvvmControlExtensions.WrapWithKoComment(CreateRow(useServerTemplate: false, isInEditMode: false), "if", "!$bp" + ControlName + ".isItemInEditMode($data)"));
            }
            else
            {
                container.Children.Add(CreateRow(useServerTemplate: false, isInEditMode: false));
            }
        }

        //
        // Сводка:
        //     Returns a <tbody> element rendered when the data source is empty.
        protected virtual HtmlGenericControl CreateEmptyBody()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tbody");
            HtmlGenericControl htmlGenericControl2 = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl2, BusinessPackCss.GridViewEmptyRow);
            HtmlGenericControl htmlGenericControl3 = new HtmlGenericControl("td");
            htmlGenericControl3.Attributes.Set("colspan", (object)ColumnsCount.ToString());
            htmlGenericControl3.Children.Add(CreateEmptyContents());
            htmlGenericControl2.Children.Add(htmlGenericControl3);
            htmlGenericControl.Children.Add(htmlGenericControl2);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl representing a row rendered
        //     for a data item.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        //
        //   isInEditMode:
        //     Indicates whether to render the row in edit mode.
        protected virtual DotvvmControl CreateRow(bool useServerTemplate, bool isInEditMode)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            if (useServerTemplate)
            {
                htmlGenericControl.Children.Add(Columns.Select((GridViewColumn c) => CreateCell(c, isInEditMode)));
            }
            else
            {
                DotvvmControlExtensions.AddKoTemplateDataBinding((IControlWithHtmlAttributes)htmlGenericControl, isInEditMode ? "EditRowTemplate" : "RowTemplate", (string)null);
            }

            return Decorator.ApplyDecorators((DotvvmControl)htmlGenericControl, (IEnumerable<Decorator>)(isInEditMode ? EditRowDecorators : RowDecorators));
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl containing a client-side template
        //     used to render rows.
        //
        // Параметры:
        //   isInEditMode:
        //     Indicates whether to render template for rows in edit mode.
        protected virtual DotvvmControl CreateClientRowTemplate(bool isInEditMode)
        {
            //IL_00c3: Unknown result type (might be due to invalid IL or missing references)
            //IL_00c9: Expected O, but got Unknown
            ClientDataItemContainer clientDataItemContainer = new ClientDataItemContainer();
            clientDataItemContainer.SetValue(Internal.PathFragmentProperty, GetPathFragmentExpression() + "/[$index]");
            clientDataItemContainer.SetValue(Internal.ClientIDFragmentProperty, GetValueRaw(Internal.CurrentIndexBindingProperty));
            clientDataItemContainer.SetDataContextTypeFromDataSource(GetDataSourceBinding());
            foreach (GridViewColumn column in Columns)
            {
                clientDataItemContainer.Children.Add(CreateCell(column, isInEditMode));
            }

            string value = GetValue(Internal.UniqueIDProperty)?.ToString() + "r1";
            HtmlKoTemplate val = new HtmlKoTemplate(isInEditMode ? "EditRowTemplate" : "RowTemplate");
            ((DotvvmBindableObject)(object)val).SetValue(Internal.UniqueIDProperty, (object?)value);
            ((DotvvmBindableObject)(object)val).SetValue<bool>(Internal.IsNamingContainerProperty, true);
            ((DotvvmControl)(object)val).Children.Add(clientDataItemContainer);
            return (DotvvmControl)(object)val;
        }

        //
        // Сводка:
        //     Returns a <td> element representing a cell in a table row.
        //
        // Параметры:
        //   column:
        //     The column to create the cell for.
        //
        //   isInEditMode:
        //     Indicates whether to render the cell in edit mode.
        protected virtual HtmlGenericControl CreateCell(GridViewColumn column, bool isInEditMode)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("td");
            AddVisibleDataBinding(htmlGenericControl, column, isInBody: true);
            if (isInEditMode && column.AllowEditing)
            {
                htmlGenericControl.Attributes.Add("class", column.GetValueRaw(GridViewColumn.EditCssClassProperty));
                column.BuildEditCell(htmlGenericControl, column);
            }
            else
            {
                htmlGenericControl.Attributes.Add("class", column.GetValueRaw(GridViewColumn.CssClassProperty));
                column.BuildCell(htmlGenericControl, column);
            }

            htmlGenericControl.SetValueRaw(BusinessPack.AllowAutoValidationProperty, column.GetValueRaw(BusinessPack.AllowAutoValidationProperty));
            AddTitleDataBinding(htmlGenericControl, column);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a DotVVM.Framework.Controls.DotvvmControl containing a client-side template
        //     used to render detail for each data item.
        protected virtual DotvvmControl CreateClientRowDetailTemplate()
        {
            //IL_004e: Unknown result type (might be due to invalid IL or missing references)
            //IL_0054: Expected O, but got Unknown
            ClientDataItemContainer clientDataItemContainer = new ClientDataItemContainer();
            clientDataItemContainer.SetValue(Internal.PathFragmentProperty, GetPathFragmentExpression() + "/[$index]");
            clientDataItemContainer.SetValue(Internal.ClientIDFragmentProperty, GetValueRaw(Internal.CurrentIndexBindingProperty));
            clientDataItemContainer.SetDataContextTypeFromDataSource(GetDataSourceBinding());
            HtmlKoTemplate val = new HtmlKoTemplate("RowDetailTemplate");
            DotvvmControlCollectionExtensions.Add(((DotvvmControl)(object)val).Children, RowDetailTemplate);
            clientDataItemContainer.Children.Add((DotvvmControl)(object)val);
            return clientDataItemContainer;
        }

        //
        // Сводка:
        //     Returns a <tfoot> element representing the DotVVM.BusinessPack.Controls.GridView
        //     footer.
        protected virtual HtmlGenericControl CreateFooter()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tfoot");
            if (Columns.Any((GridViewColumn c) => c.RenderFooter))
            {
                htmlGenericControl.Children.Add(CreateColumnFooterRow());
            }

            if (FooterTemplate != null)
            {
                htmlGenericControl.Children.Add(CreateFooterRow());
            }

            if (FilterPlacement == GridViewFilterPlacement.SeparateFooterRow)
            {
                htmlGenericControl.Children.Add(CreateFilterRow("td"));
            }

            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <tr> element containing column footers.
        protected virtual HtmlGenericControl CreateColumnFooterRow()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewColumnFooterRow);
            htmlGenericControl.Children.Add(Columns.Select(CreateColumnFooterCell));
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <td> element representing the column's footer.
        //
        // Параметры:
        //   column:
        //     The column to create the footer for.
        protected virtual HtmlGenericControl CreateColumnFooterCell(GridViewColumn column)
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("td");
            AddVisibleDataBinding(htmlGenericControl, column, isInBody: true);
            htmlGenericControl.Attributes.Add("class", column.GetValueRaw(GridViewColumn.FooterCssClassProperty));
            column.BuildFooter(htmlGenericControl);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns a <tr> element representing the footer rendered after table.
        protected virtual HtmlGenericControl CreateFooterRow()
        {
            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("tr");
            DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(htmlGenericControl, BusinessPackCss.GridViewFooterRow);
            HtmlGenericControl htmlGenericControl2 = new HtmlGenericControl("th");
            htmlGenericControl2.Attributes.Set("colspan", (object)ColumnsCount.ToString());
            DotvvmControlCollectionExtensions.Add(htmlGenericControl2.Children, FooterTemplate);
            htmlGenericControl.Children.Add(htmlGenericControl2);
            return htmlGenericControl;
        }

        //
        // Сводка:
        //     Returns contents rendered when the data source is empty.
        protected virtual DotvvmControl CreateEmptyContents()
        {
            PlaceHolder placeHolder = new PlaceHolder();
            DotvvmControlCollectionExtensions.Add(placeHolder.Children, EmptyDataTemplate);
            return placeHolder;
        }

        //
        // Сводка:
        //     Adds a visible data binding to the cell element to make it possible to change
        //     its visibility.
        //
        // Параметры:
        //   cell:
        //     The HTML element to add the binding to.
        //
        //   column:
        //     The column used to determine whether the cell is visible.
        //
        //   isInBody:
        //     Indicates whether the cell is in the body. Cells in the body require different
        //     data binding because they have different data context.
        protected virtual void AddVisibleDataBinding(HtmlGenericControl cell, GridViewColumn column, bool isInBody)
        {
            if (!isInBody)
            {
                IValueBinding valueBinding = column.GetValueBinding(GridViewColumn.VisibleProperty);
                bool initialVisibility = GetColumnSettings(column.ColumnName)?.Visible ?? ((bool?)DotvvmControlExtensions.GetValueOrDefault((DotvvmBindableObject)column, GridViewColumn.VisibleProperty, true)) ?? true;
                if (HasValueBinding(UserSettingsProperty))
                {
                    cell.SetJsValueBinding(HtmlGenericControl.VisibleProperty, "$bp" + ControlName + ".isColumnVisible(\"" + GetColumnName(column) + "\", " + (valueBinding?.GetKnockoutBindingExpression(column) ?? "true") + ")", () => initialVisibility);
                }
                else if (valueBinding != null)
                {
                    cell.SetBinding(HtmlGenericControl.VisibleProperty, valueBinding);
                }
                else
                {
                    cell.Visible = initialVisibility;
                }
            }
            else if (HasValueBinding(UserSettingsProperty) || column.HasValueBinding(GridViewColumn.VisibleProperty))
            {
                cell.SetJsValueBinding(HtmlGenericControl.VisibleProperty, "$bp" + ControlName + ".isCellVisible($element)", () => true);
            }
        }

        protected virtual void AddTitleDataBinding(HtmlGenericControl cell, GridViewColumn column)
        {
            DotvvmProperty titleProperty = GridViewColumn.TitleProperty;
            if (column.IsPropertySet(titleProperty))
            {
                cell.Attributes.Set("title", column.GetValueRaw(titleProperty));
            }
        }

        protected virtual void AddHeaderTextDataBinding(GridViewColumn column)
        {
            string columnName = GetColumnName(column);
            string text = column.GetValueBinding(GridViewColumn.HeaderTextProperty)?.GetKnockoutBindingExpression(column) ?? ("\"" + column.HeaderText + "\"");
            string bindingExpression = "$bp" + ControlName + ".getHeaderText(\"" + columnName + "\", " + text + ")";
            string serverSideValue = GetColumnSettings(columnName)?.DisplayText ?? ((string)DotvvmControlExtensions.GetValueOrDefault((DotvvmBindableObject)column, GridViewColumn.HeaderTextProperty, true));
            column.SetJsValueBinding(GridViewColumn.HeaderTextProperty, bindingExpression, () => serverSideValue);
        }

        protected virtual GridViewColumnSettings GetColumnSettings(string columnName)
        {
            return UserSettings?.ColumnsSettings?.SingleOrDefault((GridViewColumnSettings c) => c.ColumnName.Equals(columnName));
        }

        //
        // Сводка:
        //     Adds a width data binding to the element to make it possible to change its width.
        //
        // Параметры:
        //   element:
        //     The HTML element to add the binding to.
        //
        //   column:
        //     The column used to determine column width.
        protected virtual void AddWidthDataBinding(HtmlGenericControl element, GridViewColumn column)
        {
            string widthKnockoutExpression = column.GetWidthKnockoutExpression();
            if (HasValueBinding(UserSettingsProperty))
            {
                element.CssStyles.AddJsBinding("width", "$bp" + ControlName + ".getColumnWidth(\"" + GetColumnName(column) + "\", " + widthKnockoutExpression + ")");
            }
            else if (column.HasValueBinding(GridViewColumn.WidthProperty))
            {
                element.CssStyles.AddJsBinding("width", widthKnockoutExpression ?? "");
            }
            else if (column.Width != null)
            {
                element.CssStyles.Add(new KeyValuePair<string, object>("width", column.Width));
            }
        }

        //
        // Сводка:
        //     Adds a CSS class indicating ascending / descending sort order to the cell element
        //     when the data source is sorted by the given column.
        //
        // Параметры:
        //   cell:
        //     The HTML element to add the CSS class to.
        //
        //   column:
        //     The column defining the sort expression.
        protected virtual void AddSortCssDataBinding(HtmlGenericControl cell, GridViewColumn column)
        {
            if (DataSource != null)
            {
                string sortExpression = column.GetSortExpression();
                string sortAscHeaderCssClass = GetSortAscHeaderCssClass(column);
                string sortDescHeaderCssClass = GetSortDescHeaderCssClass(column);
                if (!RenderOnServer)
                {
                    cell.CssClasses.AddJsBinding(sortAscHeaderCssClass, "$bp" + ControlName + ".isDataSourceSortedBy('" + sortExpression + "', false)");
                    cell.CssClasses.AddJsBinding(sortDescHeaderCssClass, "$bp" + ControlName + ".isDataSourceSortedBy('" + sortExpression + "', true)");
                }

                if (DotvvmControlExtensions.CanGetValue((DotvvmBindableObject)this, ItemsControlBase<IBusinessPackDataSet>.DataSourceProperty) && DataSource.SortingOptions.SortExpression == sortExpression)
                {
                    DotvvmBindableObjectHelper2.AddCssClass<HtmlGenericControl>(cell, DataSource.SortingOptions.SortDescending ? sortDescHeaderCssClass : sortAscHeaderCssClass);
                }
            }
        }

        //
        // Сводка:
        //     Returns a CSS class used when the data source is sorted by the given column in
        //     ascending order.
        //
        // Параметры:
        //   column:
        //     The column to get the CSS class for.
        protected string GetSortAscHeaderCssClass(GridViewColumn column)
        {
            if (column.IsPropertySet(GridViewColumn.SortAscendingHeaderCssClassProperty))
            {
                return column.SortAscendingHeaderCssClass;
            }

            if (IsPropertySet(DotVVM.Framework.Controls.GridViewColumn.SortAscendingHeaderCssClassProperty))
            {
                return GetValue<string>(DotVVM.Framework.Controls.GridViewColumn.SortAscendingHeaderCssClassProperty);
            }

            return column.SortAscendingHeaderCssClass;
        }

        //
        // Сводка:
        //     Returns a CSS class used when the data source is sorted by the given column in
        //     descending order.
        //
        // Параметры:
        //   column:
        //     The column to get the CSS class for.
        protected string GetSortDescHeaderCssClass(GridViewColumn column)
        {
            if (column.IsPropertySet(GridViewColumn.SortDescendingHeaderCssClassProperty))
            {
                return column.SortDescendingHeaderCssClass;
            }

            if (IsPropertySet(DotVVM.Framework.Controls.GridViewColumn.SortDescendingHeaderCssClassProperty))
            {
                return GetValue<string>(DotVVM.Framework.Controls.GridViewColumn.SortDescendingHeaderCssClassProperty);
            }

            return column.SortDescendingHeaderCssClass;
        }

        //
        // Сводка:
        //     Returns an icon rendered inside the button used to change sorting from ascending
        //     to descending.
        protected virtual IconBase CreateSortAscIcon()
        {
            return new Icon(base.BindingService)
            {
                Icon = IconType.ChevronUp
            };
        }

        //
        // Сводка:
        //     Returns an icon rendered inside the button used to change sorting from descending
        //     to ascending.
        protected virtual IconBase CreateSortDescIcon()
        {
            return new Icon(base.BindingService)
            {
                Icon = IconType.ChevronDown
            };
        }

        //
        // Сводка:
        //     Returns whether the given item (row) is in edit mode.
        //
        // Параметры:
        //   item:
        //     The item to check whether it's in edit mode.
        protected virtual bool IsItemInEditMode(object item)
        {
            if (item == null)
            {
                return false;
            }

            if (InlineEditMode == GridViewInlineEditMode.Disabled)
            {
                return false;
            }

            object editRowId = DataSource.RowEditOptions.EditRowId;
            string primaryKeyPropertyName = DataSource.RowEditOptions.PrimaryKeyPropertyName;
            if (editRowId != null && !string.IsNullOrEmpty(primaryKeyPropertyName))
            {
                PropertyInfo property = item.GetType().GetProperty(primaryKeyPropertyName);
                object value = property.GetValue(item);
                return object.Equals(value, ReflectionUtils.ConvertValue(editRowId, property.PropertyType));
            }

            return false;
        }

        //
        // Сводка:
        //     Returns whether the insert row is required to be rendered.
        //
        // Параметры:
        //   useServerTemplate:
        //     Indicates whether rows are rendered on server-side.
        protected virtual bool RenderInsertRow(bool useServerTemplate)
        {
            bool flag = AllowInlineInsert;
            if (useServerTemplate)
            {
                flag = flag && DataSource?.RowInsertOptions.InsertedRow != null;
            }

            return flag;
        }

        //
        // Сводка:
        //     Returns a DotVVM.BusinessPack.Controls.ControlBinding containing values for control's
        //     binding.
        protected virtual ControlBinding GetControlBinding()
        {
            ControlBinding controlBinding = new ControlBinding();
            controlBinding.Add(this, ItemsControlBase<IBusinessPackDataSet>.DataSourceProperty, delegate
            {
            });
            controlBinding.Add(this, UserSettingsProperty, delegate
            {
            });
            controlBinding.Add(this, InlineEditModeProperty);
            controlBinding.Add(this, AllowReorderColumnsProperty);
            controlBinding.AddFunction(this, RowHasDetailBindingProperty);
            controlBinding.AddCommand(this, UserSettingsChangedProperty, useWindowSetTimeout: true);
            return controlBinding;
        }

        private string GetColumnName(GridViewColumn column)
        {
            return column.GetColumnName(Columns.IndexOf(column));
        }

        public string[] EnsureUniqueColumnNames()
        {
            string[] array = Columns.Select((GridViewColumn c, int i) => c.GetColumnName(i)).ToArray();
            HashSet<string> hashSet = new HashSet<string>();
            for (int j = 0; j < Columns.Count; j++)
            {
                string text = array[j];
                int num = 1;
                while (hashSet.Contains(text))
                {
                    text = array[j] + num;
                    num++;
                }

                hashSet.Add(text);
                if (num > 1)
                {
                    Columns[j].ColumnName = text;
                }

                array[j] = text;
            }

            return array;
        }

        private void InitializeColumnNames()
        {
            foreach (GridViewColumn column in Columns)
            {
                if (string.IsNullOrWhiteSpace(column.ColumnName))
                {
                    int columnIndex = Columns.IndexOf(column);
                    column.ColumnName = column.GetColumnName(columnIndex);
                }
            }
        }
    }
}
#if false // Журнал декомпиляции
Элементов в кэше: "148"
------------------
Разрешить: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll"
------------------
Разрешить: "DotVVM.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Framework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Framework.dll"
------------------
Разрешить: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Найдена одна сборка: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Внимание! Несовпадение версий. Ожидалось: "2.0.0.0", получено: "1.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Microsoft.Extensions.DependencyInjection.Abstractions.dll"
------------------
Разрешить: "Microsoft.Extensions.Options, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Найдена одна сборка: "Microsoft.Extensions.Options, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Внимание! Несовпадение версий. Ожидалось: "2.0.0.0", получено: "1.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Microsoft.Extensions.Options.dll"
------------------
Разрешить: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.dll"
------------------
Разрешить: "DotVVM.Utils.HtmlElements, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Не удалось найти по имени: "DotVVM.Utils.HtmlElements, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
------------------
Разрешить: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Core.dll"
------------------
Разрешить: "DotVVM.BusinessPack.Core, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Найдена одна сборка: "DotVVM.BusinessPack.Core, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.Core.4.0.5-trial\lib\net472\DotVVM.BusinessPack.Core.dll"
------------------
Разрешить: "System.Collections.Immutable, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Collections.Immutable, Version=1.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "5.0.0.0", получено: "1.2.2.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\System.Collections.Immutable.dll"
------------------
Разрешить: "DotVVM.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Core.dll"
------------------
Разрешить: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.Linq.dll"
------------------
Разрешить: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.dll"
------------------
Разрешить: "Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Найдена одна сборка: "Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Внимание! Несовпадение версий. Ожидалось: "10.0.0.0", получено: "11.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Newtonsoft.Json.dll"
------------------
Разрешить: "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Найдена одна сборка: "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\netstandard.dll"
------------------
Разрешить: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Data.dll"
------------------
Разрешить: "System.Diagnostics.Tracing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Diagnostics.Tracing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.IO.Compression, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.IO.Compression, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.IO.Compression.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.IO.Compression.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Web.dll"
------------------
Разрешить: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Не удалось найти по имени: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
#endif
