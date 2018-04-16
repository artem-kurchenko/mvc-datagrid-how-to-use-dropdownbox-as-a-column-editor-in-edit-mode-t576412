
@Code
    ViewBag.Title = "Index"
End Code

<h2>DataGrid with DropDownBox</h2>
<script>
    function customizeDisplayText(cell, info) {
        var rowData = info.row.data;
        if (!rowData)
            return;
        var texts = [];
        if (rowData.StateID && rowData.StateID.length) {
            for (var i = 0; i < rowData.StateID.length; i++) {
                var value = rowData.StateID[i];
                var displayText = info.column.lookup.calculateCellValue(value);
                if (displayText)
                    texts.push(displayText);
            }
        }
        cell.append(texts.toString());
    };
    function onValueChanged(args) {
        var grid = $("#gridContainer").dxDataGrid("instance");
        if (!grid.hasEditData())
            grid.option("editing.mode", args.value);
        else
            DevExpress.ui.notify("Finish editing first");
    }
</script>
@Code

    Html.DevExtreme().DataGrid() _
            .ID("gridContainer") _
    .Editing(Sub(e)
                 e.Mode(GridEditMode.Cell) _
                 .AllowUpdating(True) _
                 .AllowAdding(True) _
                 .AllowDeleting(True)
             End Sub) _
    .Columns(Sub(columns)
        columns.Add().DataField("Prefix").Caption("Title").Width(55)
        columns.Add().DataField("FirstName")
        columns.Add().DataField("LastName")
        columns.Add().DataField("Position").Width(170)
        columns.Add().DataField("StateID").Caption("State").AllowFiltering(False) _
                                    .CellTemplate(New JS("customizeDisplayText")) _
                                    .Lookup(Sub(lookup)
                                                lookup.DisplayExpr("Name").ValueExpr("ID") _
                            .DataSource(Function(d)
                                            Return d.WebApi().Controller("Data").LoadAction("GetStates").Key("ID")
                                        End Function) _
                            .DataSourceOptions(Function(op)
                                                   Return op.PageSize(10).Paginate(True)
                                               End Function)
                                            End Sub) _
.EditCellTemplate(Sub()
        @<text>
            @Html.Partial("DxDropDownBox")
        </text>
                           End Sub)
                 columns.Add().DataField("BirthDate").DataType(GridColumnDataType.Date)
             End Sub) _
.DataSource(Function(d)
                Return d.WebApi().Controller("Data").Key("ID")
            End Function).Render()
End Code










<div class="options">
    <div class="caption">Options</div>
    <div class="edit-mode option">
        <span>Change Edit Mode</span>
        @(Html.DevExtreme().SelectBox() _
            .DataSource({"row", "form", "popup", "cell"}) _
            .Value("cell") _
            .OnValueChanged("onValueChanged")
        )
    </div>
</div>