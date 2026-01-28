Imports System.Data
Partial Class Secured_SystemAdministration_SystemUsers
    Inherits cPageInit_Secured_BS
    Dim _dtGVAdmin As New DataTable
    Dim _dtGVClient As New DataTable

    Dim _dbUtil As New clsDimboMySQL.clsMYSQLDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.Remove("PWDID")
        If Not Page.IsPostBack Then
            fillGridViewAdmin()
            fillGridViewClient()
        End If

    End Sub

    Protected Sub fillGridViewAdmin()

        '   _dtGV = CType(Application("userList"), Dictionary(Of String, String)).ToList

        Dim _userList As New Dictionary(Of String, String())

        _userList = CType(Application("userList"), Dictionary(Of String, String()))

        With _dbUtil

            .addColumnDataTable(_dtGVAdmin, "No.", "STRING")
            .addColumnDataTable(_dtGVAdmin, "Date/Time", "STRING")
            .addColumnDataTable(_dtGVAdmin, "User ID", "STRING")
            .addColumnDataTable(_dtGVAdmin, "User Name", "STRING")
            .addColumnDataTable(_dtGVAdmin, "IP Address", "STRING")

        End With

        Dim count As Integer = 0
        For Each item As KeyValuePair(Of String, String()) In _userList
            count += 1
            _dtGVAdmin.Rows.Add(count, item.Value(2), item.Value(0), item.Value(1), item.Value(3))
        Next

        Dim dt As New DataTable
        Dim dtView As New DataView(_dtGVAdmin)

        dtView.Sort = "Date/Time DESC"

        _gvAdmin.DataSource = dtView.ToTable
        _gvAdmin.DataBind()

        '_gv.Columns(2).Visible = False
        '_gv.Columns(3).Visible = False

        lblAdminCount.Text = _userList.Count

    End Sub


    Protected Sub fillGridViewClient()

        '   _dtGV = CType(Application("userList"), Dictionary(Of String, String)).ToList

        Dim _clientList As New Dictionary(Of String, String())

        _clientList = CType(Application("clientList"), Dictionary(Of String, String()))

        With _dbUtil

            .addColumnDataTable(_dtGVClient, "No.", "STRING")
            .addColumnDataTable(_dtGVClient, "Date/Time", "STRING")
            .addColumnDataTable(_dtGVClient, "Reference No.", "STRING")
            .addColumnDataTable(_dtGVClient, "Name", "STRING")
            .addColumnDataTable(_dtGVClient, "IP Address", "STRING")

        End With

        Dim count As Integer = 0
        For Each item As KeyValuePair(Of String, String()) In _clientList
            count += 1
            _dtGVClient.Rows.Add(count, item.Value(2), item.Value(0), item.Value(1), item.Value(3))
        Next

        Dim dt As New DataTable
        Dim dtView As New DataView(_dtGVClient)

        dtView.Sort = "Date/Time DESC"

        _gvClient.DataSource = dtView.ToTable
        _gvClient.DataBind()

        '_gv.Columns(2).Visible = False
        '_gv.Columns(3).Visible = False

        lblClientCount.Text = _clientList.Count

    End Sub
End Class
