Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsCMS
    Dim _clsDB As New clsDatabase

    Dim _strQueryBase As String = ""
    Dim _strQuery As String = ""

    Public Sub New()
        initialize()
    End Sub

    Private _menuID As String
    Private _menuParentID As String
    Private _menuName As String
    Private _menuPageURL As String
    Private _menuLevel As String
    Private _menuSortOrder As String
    Private _isPublic As String
    Private _isActive As String
    Private _lastUser As String

    Public Property menuID As String
        Get
            Return Me._menuID
        End Get
        Set(ByVal Value As String)
            Me._menuID = Value
        End Set
    End Property

    Public Property menuParentID As String
        Get
            Return Me._menuParentID
        End Get
        Set(ByVal Value As String)
            Me._menuParentID = Value
        End Set
    End Property

    Public Property menuName As String
        Get
            Return Me._menuName
        End Get
        Set(ByVal Value As String)
            Me._menuName = Value
        End Set
    End Property

    Public Property menuPageURL As String
        Get
            Return Me._menuPageURL
        End Get
        Set(ByVal Value As String)
            Me._menuPageURL = Value
        End Set
    End Property

    Public Property menuLevel As String
        Get
            Return Me._menuLevel
        End Get
        Set(ByVal Value As String)
            Me._menuLevel = Value
        End Set
    End Property

    Public Property menuSortOrder As String
        Get
            Return Me._menuSortOrder
        End Get
        Set(ByVal Value As String)
            Me._menuSortOrder = Value
        End Set
    End Property

    Public Property isPublic As String
        Get
            Return Me._isPublic
        End Get
        Set(ByVal Value As String)
            Me._isPublic = Value
        End Set
    End Property

    Public Property isActive As String
        Get
            Return Me._isActive
        End Get
        Set(ByVal Value As String)
            Me._isActive = Value
        End Set
    End Property

    Public Property lastUser As String
        Get
            Return Me._lastUser
        End Get
        Set(ByVal Value As String)
            Me._lastUser = Value
        End Set
    End Property

    Public Sub initialize()
        _menuParentID = 0
        _menuName = ""
        _menuPageURL = ""
        _menuLevel = 0
        _menuSortOrder = 0
        _isPublic = "N"
        _isActive = "N"
    End Sub

    Public Sub saveCMSMenu()

        If _menuID = "" Then

            With _clsDB.dbUtility
                .fieldItems = "parent_id,menu_name,page_url,menu_level,sort_order,is_public,is_active,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_cms_menu", "INSERT")
                .ADDPARAM_CMD_String("parent_id", _menuParentID)
                .ADDPARAM_CMD_String("menu_name", _menuName)
                .ADDPARAM_CMD_String("page_url", _menuPageURL)
                .ADDPARAM_CMD_String("menu_level", _menuLevel)
                .ADDPARAM_CMD_String("sort_order", _menuSortOrder)
                .ADDPARAM_CMD_String("is_public", _isPublic)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .executeUsingCommandFromSQL(True)
            End With
        Else
            With _clsDB.dbUtility
                .fieldItems = "parent_id,menu_name,page_url,menu_level,sort_order,is_public,is_active,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_cms_menu", "UPDATE", "menu_id")
                .ADDPARAM_CMD_String("parent_id", _menuParentID)
                .ADDPARAM_CMD_String("menu_name", _menuName)
                .ADDPARAM_CMD_String("page_url", _menuPageURL)
                .ADDPARAM_CMD_String("menu_level", _menuLevel)
                .ADDPARAM_CMD_String("sort_order", _menuSortOrder)
                .ADDPARAM_CMD_String("is_public", _isPublic)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .ADDPARAM_CMD_String("menu_id", _menuID)
                .executeUsingCommandFromSQL(True)
            End With
        End If

    End Sub


    Public Function browseSecureCMSMenuHeaderPermission(ByVal _strUserId As String, ByVal _strUserRoleId As String) As DataTable
        Dim _dtPermission As New DataTable


        _strQuery = "SELECT DISTINCT tbl_cms_menu.menu_id, tbl_cms_menu.menu_name, tbl_cms_menu.page_url, tbl_cms_menu.sort_order, tbl_cms_menu.menu_level " & _
                    "FROM tbl_user_access_permission INNER JOIN tbl_cms_menu ON tbl_user_access_permission.menu_id = tbl_cms_menu.menu_id " & _
                    "WHERE ((tbl_user_access_permission.user_id='' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "') OR tbl_user_access_permission.user_id='" & _strUserId & "') AND (tbl_user_access_permission.can_access='Y' AND tbl_cms_menu.parent_id='0' AND tbl_cms_menu.menu_level=1 AND tbl_cms_menu.is_public='N' AND tbl_cms_menu.is_active='Y') ORDER BY tbl_cms_menu.sort_order"

        _dtPermission = _clsDB.Fill_DataTable(_strQuery)

        Return _dtPermission

    End Function

    Public Function browseSecureCMSSubMenuPermission(ByVal _strUserId As String, ByVal _strUserRoleId As String, ByVal _strParentId As String) As DataTable
        Dim _dtPermission As New DataTable

        _strQuery = "SELECT DISTINCT tbl_cms_menu.menu_id, tbl_cms_menu.menu_name, tbl_cms_menu.page_url, tbl_cms_menu.sort_order, tbl_cms_menu.menu_level " & _
                    "FROM tbl_user_access_permission INNER JOIN tbl_cms_menu ON tbl_user_access_permission.menu_id = tbl_cms_menu.menu_id " & _
                    "WHERE ((tbl_user_access_permission.user_id='' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "') OR tbl_user_access_permission.user_id='" & _strUserId & "') AND (tbl_user_access_permission.can_access='Y' AND tbl_cms_menu.parent_id='" & _strParentId & "' AND tbl_cms_menu.menu_level=2 AND tbl_cms_menu.is_public='N' AND tbl_cms_menu.is_active='Y') ORDER BY tbl_cms_menu.sort_order"

        _dtPermission = _clsDB.Fill_DataTable(_strQuery)

        Return _dtPermission
    End Function

    Public Function fnModuleMenu_BrowseMenu(ByVal _strUserId As String, ByVal _strUserRoleId As String, ByVal _strParentId As String, ByVal _intLevel As Integer, ByVal _intIsPublic As Integer, Optional ByVal _intPageMenu As String = "0") As DataTable
        Dim _dtRoles As New DataTable


        _strQuery = "SELECT DISTINCT tbl_system_modules.system_module_desc FROM tbl_cms_menu INNER JOIN tbl_system_modules ON tbl_cms_menu.hrmis_module = tbl_system_modules.system_module_desc INNER JOIN tbl_user_access_permission ON tbl_cms_menu.menu_id = tbl_user_access_permission.menu_id " & _
                    "WHERE ((user_id='' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "') OR (tbl_user_access_permission.user_id='" & _strUserId & "' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "')) and tbl_user_access_permission.can_access='True' and (tbl_cms_menu.parent_id='" & _strParentId & "' and tbl_cms_menu.menu_level=" & _intLevel.ToString() & " and tbl_cms_menu.ispublic='False' and tbl_cms_menu.ispublish='True')"


        _dtRoles = _clsDB.Fill_DataTable(_strQuery)


        Return _dtRoles
    End Function

    Public Function browseParentCMSMenuAdmin() As DataTable
        Dim _strQuery As String = ""
        _strQuery = "SELECT tbl_cms_menu.menu_id,tbl_cms_menu.menu_name,tbl_cms_menu.page_url " & _
                    "FROM tbl_cms_menu WHERE is_public='N' AND is_active='Y' AND tbl_cms_menu.parent_id ='0' AND menu_id <> 1 " & _
                    "ORDER BY tbl_cms_menu.sort_order"

        Return _clsDB.Fill_DataTable(_strQuery)
    End Function


    Public Sub getCMSMenu(ByVal thisMenuID As String)
        Dim dt As New DataTable

        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_cms_menu WHERE menu_id=" & thisMenuID)

        If dt.Rows.Count > 0 Then
            _menuParentID = dt.Rows(0)("parent_id")
            _menuName = dt.Rows(0)("menu_name") & ""
            _menuPageURL = dt.Rows(0)("page_url") & ""
            _menuLevel = dt.Rows(0)("menu_level")
            _menuSortOrder = dt.Rows(0)("sort_order") & ""
            _isPublic = dt.Rows(0)("is_public") & ""
            _isActive = dt.Rows(0)("is_active") & ""
        Else
            initialize()
        End If
    End Sub


    Public Function browseCMSMenu(ByVal _strmenuid As String, ByVal _strparent_id As String, ByVal _strSearch As String) As DataTable
        _strQueryBase = "SELECT tbl_cms_menu.menu_id, tbl_cms_menu.menu_name, tbl_cms_menu.sort_order, tbl_cms_menu.is_public, tbl_cms_menu.is_active " & _
                        "FROM tbl_cms_menu "
        _strQuery = _strQueryBase & " WHERE tbl_cms_menu.parent_id=" & _strparent_id
        If _strmenuid <> "" Then
            _strQuery = _strQueryBase & " WHERE tbl_cms_menu.menu_id=" & _strmenuid
        Else
            If _strSearch <> "" Then
                _strQuery = _strQueryBase & " WHERE tbl_cms_menu.menu_name LIKE '%" & _strSearch & "%'"
            End If
        End If

        Return _clsDB.Fill_DataTable(_strQuery & " ORDER BY tbl_cms_menu.is_public, tbl_cms_menu.sort_order")
    End Function


    Public Function browseParentCMSMenu() As DataTable
        Dim _strQuery As String = ""
        _strQuery = "SELECT tbl_cms_menu.menu_id,tbl_cms_menu.menu_name,tbl_cms_menu.page_url " & _
                    "FROM tbl_cms_menu WHERE is_public='N' AND is_active='Y' AND tbl_cms_menu.parent_id ='0' " & _
                    " ORDER BY tbl_cms_menu.sort_order"

        Return _clsDB.Fill_DataTable(_strQuery)
    End Function

    Public Function browseChildCMSMenu(ByVal _strparent As String) As DataTable
        Dim _strQuery As String = ""
        _strQuery = "SELECT tbl_cms_menu.menu_id,tbl_cms_menu.menu_name,tbl_cms_menu.page_url " & _
                    "FROM tbl_cms_menu WHERE is_public='N' AND is_active='Y' AND tbl_cms_menu.parent_id =" & _strparent & _
                    " ORDER BY tbl_cms_menu.sort_order"


        Return _clsDB.Fill_DataTable(_strQuery)
    End Function


    Public Function browseSecureCMSMenuHeaderPermissionByModule(ByVal _strUserId As String, ByVal _strUserRoleId As String, _Module As String) As DataTable
        Dim _dtPermission As New DataTable


        _strQuery = "SELECT DISTINCT tbl_cms_menu.menu_id, tbl_cms_menu.menu_name, tbl_cms_menu.page_url, tbl_cms_menu.sort_order, tbl_cms_menu.menu_level, menu_icon " & _
                    "FROM tbl_user_access_permission INNER JOIN tbl_cms_menu ON tbl_user_access_permission.menu_id = tbl_cms_menu.menu_id " & _
                    "WHERE ((tbl_user_access_permission.user_id='' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "') OR tbl_user_access_permission.user_id='" & _strUserId & "') AND (tbl_user_access_permission.can_access='Y' AND tbl_cms_menu.parent_id='0' AND tbl_cms_menu.menu_level=1 AND tbl_cms_menu.is_public='N' AND tbl_cms_menu.is_active = 'Y' AND tbl_cms_menu.module='" & _Module & "') ORDER BY tbl_cms_menu.sort_order"

        _dtPermission = _clsDB.Fill_DataTable(_strQuery)

        Return _dtPermission

    End Function


    Public Function browseSecureCMSMenuHeaderPermissionHome(ByVal _strUserId As String, ByVal _strUserRoleId As String, _Module As String) As DataTable
        Dim _dtPermission As New DataTable


        _strQuery = "SELECT tbl_cms_menu.menu_id " & _
                    "FROM tbl_user_access_permission INNER JOIN tbl_cms_menu ON tbl_user_access_permission.menu_id = tbl_cms_menu.menu_id " & _
                    "WHERE ((tbl_user_access_permission.user_id='' AND tbl_user_access_permission.user_role_id='" & _strUserRoleId & "') OR tbl_user_access_permission.user_id='" & _strUserId & "') AND (tbl_user_access_permission.can_access='Y' AND tbl_cms_menu.parent_id='0' AND tbl_cms_menu.menu_level=1 AND tbl_cms_menu.is_public='N' AND tbl_cms_menu.is_active = 'Y' AND tbl_cms_menu.module='" & _Module & "' AND tbl_cms_menu.menu_id = '60')"

        _dtPermission = _clsDB.Fill_DataTable(_strQuery)

        Return _dtPermission

    End Function


End Class
