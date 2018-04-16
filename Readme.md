# MVC DataGrid - How to use DropDownBox as a column editor in edit mode


<p>This example illustrates how to define <a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDropDownBox/">dxDropDownBox</a> with an embedded <a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/">dxDataGrid</a> for editing data in MVC via an <a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/Configuration/columns/#editCellTemplate">EditCellTemplate</a>. Run the example and check the State column to see this approach in action.<br><br>For a client-side solution, please refer to the <a href="https://www.devexpress.com/Support/Center/p/T548916">dxDataGrid - How to use dxDropDownBox as a column editor in edit mode</a> example.<br><br>Click the "Show Implementation Details" link to see step-by-step instructions.</p>


<h3>Description</h3>

<p>Perform the following steps to complete this task:&nbsp;</p>
<p>1.&nbsp;Use&nbsp;<a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/Configuration/columns/#editCellTemplate">EditCellTemplate</a>&nbsp;to define MVC DropDownBox for a required column.<br>2.&nbsp;&nbsp;Implement the&nbsp;<a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDropDownBox/Configuration/#contentTemplate">Template</a>&nbsp;function to define MVC DataGrid&nbsp;and handle its&nbsp;<a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/Configuration/#onSelectionChanged">selectionChanged</a>&nbsp;event to pass selected keys to DropDownBox. In addition, handle the&nbsp;<a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDropDownBox/Configuration/#onValueChanged">dxDropDownBox.valueChanged</a>&nbsp;event&nbsp;to adjust the DataGrid selection<br>3. Use&nbsp;<a href="https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/Configuration/columns/#cellTemplate">CellTemplate</a>&nbsp;to covert an array of selected keys to a human-readable text.<br><br>For more information about MVC templates, please review the&nbsp;<a href="https://js.devexpress.com/Documentation/Guide/ASP.NET_MVC_Controls/Fundamentals/#Implementing_Templates">Implementing Templates</a>&nbsp;help topic.</p>

<br/>


