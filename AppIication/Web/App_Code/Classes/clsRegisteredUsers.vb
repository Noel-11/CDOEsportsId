Imports Microsoft.VisualBasic
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class clsRegisteredUsers
    Private connectionString As String = "Server=localhost;Database=db_cdoesid;User Id=root;Password=ictlgucdo;Port=3306;Allow Zero Datetime=true;AllowUserVariables=True;CharSet=utf8"

    ''' <summary>
    ''' Get barangays for dropdown (minimal data)
    ''' </summary>
    Public Function GetAllBarangays() As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT id, barangay FROM tbl_ref_barangay ORDER BY barangay ASC"

                Using adapter As New MySqlDataAdapter(sql, connection)
                    adapter.Fill(dt)
                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw New Exception("Error loading barangays: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Insert new registered user and return its ID
    ''' </summary>
    Public Function InsertRegisteredUser(ByVal fullName As String, ByVal sex As String, ByVal age As Integer,
                                        ByVal birthday As Date, ByVal contactNumber As String,
                                        ByVal barangayId As String, ByVal modeOfValidation As String,
                                        ByVal isLicensedPlayer As Boolean, ByVal referralChannel As String) As Integer
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim sql As String = "INSERT INTO tbl_registered_users " &
                                   "(full_name, sex, age, birthday, contact_number, barangay_id, " &
                                   "mode_of_validation, is_licensed_player, referral_channel) " &
                                   "VALUES (@fullName, @sex, @age, @birthday, @contactNumber, @barangayId, " &
                                   "@modeOfValidation, @isLicensedPlayer, @referralChannel); " &
                                   "SELECT LAST_INSERT_ID();"

                Using command As New MySqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@fullName", fullName)
                    command.Parameters.AddWithValue("@sex", sex)
                    command.Parameters.AddWithValue("@age", age)
                    command.Parameters.AddWithValue("@birthday", birthday.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), DBNull.Value, contactNumber))
                    command.Parameters.AddWithValue("@barangayId", barangayId)
                    command.Parameters.AddWithValue("@modeOfValidation", If(String.IsNullOrEmpty(modeOfValidation), DBNull.Value, modeOfValidation))
                    command.Parameters.AddWithValue("@isLicensedPlayer", isLicensedPlayer)
                    command.Parameters.AddWithValue("@referralChannel", If(String.IsNullOrEmpty(referralChannel), DBNull.Value, referralChannel))

                    Return CInt(command.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error inserting user: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Get user with barangay details (only columns actually used)
    ''' </summary>
    Public Function GetUserWithBarangay(ByVal userId As Integer) As DataRow
        Dim dt As New DataTable()

        Try
            Using connection As New MySqlConnection(connectionString)
                ' Only select columns that are actually displayed
                Dim sql As String = "SELECT u.id, u.full_name, u.sex, u.age, u.birthday, " &
                                   "u.contact_number, u.mode_of_validation, u.is_licensed_player, " &
                                   "u.referral_channel, b.barangay, b.barangay_captain " &
                                   "FROM tbl_registered_users u " &
                                   "INNER JOIN tbl_ref_barangay b ON u.barangay_id = b.id " &
                                   "WHERE u.id = @userId"

                Using adapter As New MySqlDataAdapter(sql, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId)
                    adapter.Fill(dt)
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If

            Return Nothing

        Catch ex As Exception
            Throw New Exception("Error getting user: " & ex.Message)
        End Try
    End Function

End Class