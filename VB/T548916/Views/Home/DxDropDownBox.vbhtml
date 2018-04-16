<script>
    function gridBox_valueChanged(args, setValueMethod) {
        var $dataGrid = $("#dDBoxDataGrid");

        if ($dataGrid.length) {
            var dataGrid = $dataGrid.dxDataGrid("instance");
            dataGrid.selectRows(args.value, false);
        }
        setValueMethod(args.value);
    }
    function onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option("value", keys);
    }
    function onCloseBtnClick(args, dropDownBoxInstance) {
        dropDownBoxInstance.close();
    }
</script>
@Code
    Html.DevExtreme().DropDownBox() _
            .Width("100%") _
                    .Value(New JS("data.StateID")) _
                    .ValueExpr("ID") _
                    .DisplayExpr("Name") _
                    .DataSource(Function(d)
                                    Return d.WebApi().Controller("Data").LoadAction("GetStates").Key("ID")
                                End Function) _
            .Placeholder("Select a value...") _
            .ShowClearButton(True) _
            .OnValueChanged("function(args) {{ gridBox_valueChanged(args, setValue); }}") _
            .DropDownOptions(Sub(op)
                                 op.Width(500)
                                 op.MinHeight(300)
                             End Sub) _
            .ContentTemplate(Sub()
        @<text>

                                @(Html.DevExtreme().DataGrid() _
                                  .ID("dDBoxDataGrid") _
                                  .Selection(Sub(selection)
                                                 selection.Mode(SelectionMode.Multiple)
                                             End Sub) _
                                  .SearchPanel(Sub(s)
                                                   s.Visible(True)
                                               End Sub) _
                                  .Height("90%") _
                                  .ShowBorders(True) _
                                  .ShowRowLines(True) _
                                  .Scrolling(Sub(s)
                                                 s.Mode(GridScrollingMode.Virtual)
                                             End Sub) _
                                  .DataSource(Function(d)
                                                  Return d.WebApi().Controller("Data").LoadAction("GetStates").Key("ID")
                                              End Function) _
                                  .Columns(Sub(columns)
                                               columns.Add().DataField("ID")
                                               columns.Add().DataField("Name")
                                           End Sub) _
                                 .SelectedRowKeys(New JS("component.option('value')")) _
                                 .OnSelectionChanged("function(args) {{ onSelectionChanged(args, component); }}")
                                )
                                @(Html.DevExtreme().Button() _
          .ElementAttr(New With {.style = "margin-top:10px;float:right"}) _
          .Text("Close") _
          .OnClick("function(args) {{ onCloseBtnClick(args, component); }}"))
            </text>
                                     End Sub).Render()
End Code
