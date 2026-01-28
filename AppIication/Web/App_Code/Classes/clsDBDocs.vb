Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsDBDocs
    Public dbUtility As New clsDimboMySQL.clsMYSQLDatabase
    Public Sub New()

        If ConfigurationManager.AppSettings("conType").ToString = "local" Then
            dbUtility.Initialize_DB_MYSQL_WEB(ConfigurationManager.ConnectionStrings("sqlDBDOCS").ConnectionString)
        Else
            dbUtility.Initialize_DB_MYSQL_WEB("Server=172.16.1.104;Initial Catalog='db_scid_docs';Persist Security Info=no;User Name='noel';Password='noel';default command timeout=360;Port=3607;Allow Zero Datetime=true;AllowUserVariables=True")
            'dbUtility.Initialize_DB_MYSQL_WEB("Server=localhost;Initial Catalog='db_scid_docs';Persist Security Info=no;User Name='root';Password='ictlgucdo';default command timeout=360;Port=3306;Allow Zero Datetime=true;AllowUserVariables=True")
        End If

    End Sub
    Public Function Fill_DataTable(ByVal select_str As String, Optional ByVal table_name As String = "tbl_list") As DataTable
        Dim dtFill_DDL As New DataTable
        dbUtility.fillDataTable(dtFill_DDL, select_str, table_name)
        Return dtFill_DDL
    End Function

    Public Function Get_DB_Item(ByVal sql_str As String) As Object
        Return dbUtility.getItemFromSQLText(sql_str)
    End Function
    Public Sub Delete_Record(ByVal sql_str As String)
        dbUtility.sqlString = sql_str
        dbUtility.executeUsingCommandFromSQL(True)
    End Sub

    Public Sub populateDDLB(ByRef this_ddlb As DropDownList, ByVal this_displayvalue As String, ByVal this_datavalue As String, ByVal this_table As String, ByVal this_order As String, Optional ByVal this_parameter As String = "", Optional ByVal _firstItem As String = "..Select..", Optional ByVal _firstItemValue As String = "0")
        Dim dt As New DataTable
        Dim sql_str As String = ""

        If this_datavalue = this_displayvalue Then
            sql_str = "SELECT " & this_datavalue & " FROM " & this_table
        Else
            sql_str = "SELECT " & this_datavalue & "," & this_displayvalue & " FROM " & this_table
        End If

        If this_parameter <> "" Then
            sql_str = sql_str & this_parameter & " ORDER BY " & this_order
        Else
            sql_str = sql_str & " ORDER BY " & this_order
        End If

        dt = Fill_DataTable(sql_str)

        With this_ddlb
            .DataSource = dt
            .DataTextField = this_displayvalue
            .DataValueField = this_datavalue
            .DataBind()
            .Items.Insert(0, New ListItem(_firstItem, _firstItemValue))
        End With
    End Sub

    Public Sub Populate_DDLB_SQL(ByRef this_ddlb As DropDownList, ByVal this_displayvalue As String, ByVal this_datavalue As String, ByVal _sqlstr As String, Optional ByVal _firstItem As String = "... Please select ...", Optional ByVal _firstItemValue As String = "0")
        Dim dt As New DataTable

        dt = Fill_DataTable(_sqlstr)

        With this_ddlb
            .DataSource = dt
            .DataTextField = this_displayvalue
            .DataValueField = this_datavalue
            .DataBind()
            .Items.Insert(0, New ListItem(_firstItem, _firstItemValue))
        End With
    End Sub

    Public Function stringToBoolean(_yn As String) As Boolean
        If _yn = "Y" Then Return True

        Return False
    End Function

    Sub populateDDLB(p1 As String, p2 As String, p3 As String, p4 As String, p5 As String, p6 As String)
        ' Throw New NotImplementedException
    End Sub

End Class
