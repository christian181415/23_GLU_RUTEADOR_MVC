Imports System.Data.OleDb

Public Class ClassAccesos
    '//FUNCION PARA OBTENER LA CADENA DE CONXION A LA BASE DE DATOS QUE SE LE DETERMINE//
    '//SOLO SE MODIFICAN LAS VARIABLES PRIMARIAS PARA FORMAR LA CADENA DE CONSION COMPLETA.
    Dim TipoDB As String = "Access"
    Public Function ConexionString()
        '//VARIABLES PARA UNA CONEXION ACCESS O SQL
        Dim Source As String = "RutasDB.mdb"
        Dim Security As String = "True"
        Dim PasswordDB As String = "LuinDB*"
        '//VARIABLES PARA UNA CONEXION SQL
        Dim Servidor As String = ""
        Dim Usuario As String = ""


        Dim Proveedor, CadenaConexion As String
        '//VALIDACION DE CONEXION ACCESS CON O SIN CONTRASEÑA
        If TipoDB = "Access" Then
            Proveedor = "Microsoft.ACE.OLEDB.12.0"
            If Security = "False" Then
                CadenaConexion = "Provider =" & Proveedor & "; Data Source =|DataDirectory|\Assets\DB\" & Source & ";Persist Security Info =" & Security
            ElseIf Security = "True" Then
                CadenaConexion = "Provider =" & Proveedor & "; Data Source =|DataDirectory|\Assets\DB\" & Source & ";Jet OLEDB:Database Password =" & PasswordDB
            Else
                MsgBox("Error en los datos de su cadena de conexión.")
                CadenaConexion = Nothing
            End If
            Return CadenaConexion
            '//VALIDACION DE CONEXION SQL CON O SIN CONTRASEÑA
        ElseIf TipoDB = "SQLServer" Then
            Proveedor = "System.Data.ProviderName"
            If Security = "False" Then
                CadenaConexion = "ProviderName=" & Proveedor & ";Data Source=" & Servidor & ";Initial Catalog=" & Source & "Integrated Security=" & Security & ";"
            ElseIf Security = "True" Then
                CadenaConexion = "ProviderName=" & Proveedor & ";Data Source=" & Servidor & ";Initial Catalog=" & Source & ";Integrated Security=" & Security & ";User=" & Usuario & ";Pwd=" & PasswordDB
            Else
                MsgBox("Error en los datos de su cadena de conexión.")
                CadenaConexion = Nothing
            End If
            Return CadenaConexion
        Else
            MsgBox("Su base de datos no corresponde a las registradas por el sistema." & Chr(10) & "Favor de revisar.", MsgBoxStyle.Critical, "ERROR | Corporativo LUIN")
        End If
    End Function


    '//FUNCION PARA SELECCIONAR TODA LA INFORMACION EXISTENTE DE UNA TABLA DE BASE DE DATOS//
    '//ESTA FUNCION NO SE DEBE MODIFICAR YA QUE ES UNA ESTRUCTURA Y SE MANDA A OTRA CLASE DONDE
    '//SE PASAN TODOS LOS COMPONENTES NECESARIOS PARA LA CONSULTA A LA BASE DE DATOS.
    Public Function SELECT_DATAREADER(Consulta As String) As OleDbDataReader
        If TipoDB = "Access" Then
            Dim ConexionDB As New OleDbConnection(ConexionString)
            Dim DTReader As OleDbDataReader = Nothing
            Dim Comando As OleDbCommand = Nothing
            Try
                Comando = New OleDbCommand(Consulta, ConexionDB)
                ConexionDB.Open()
                DTReader = Comando.ExecuteReader
                ConexionDB.Close()
                ConexionDB.Dispose()
                Return DTReader
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | SELECT_DATAREADER")
            End Try
        End If
    End Function

    'Public Function SELECT_DATASET_PARAMS(Consulta As String) As DataSet
    '    If TipoDB = "Access" Then
    '        Dim ConexionDB As New OleDbConnection(ConexionString)
    '        Dim DTSet As DataSet = Nothing
    '        Dim DTAdapter As OleDbDataAdapter = Nothing
    '        Dim Comando As OleDbCommand = Nothing
    '        If ConexionDB Is Nothing Then
    '            DTSet = Nothing
    '            MsgBox("Sin conexion a la base de datos", MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | SELECT_DATASET_PARAMS")
    '        Else
    '            Try
    '                Comando = New OleDbCommand(Consulta, ConexionDB)
    '                DTAdapter = New OleDbDataAdapter()
    '                DTSet = New DataSet
    '                DTAdapter.SelectCommand = Comando
    '                Try
    '                    ConexionDB.Open()
    '                    DTAdapter.Fill(DTSet)
    '                    ConexionDB.Close()
    '                    ConexionDB.Dispose()
    '                Catch ex As Exception
    '                    MsgBox("Error al cargar la información." & Chr(10) & ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | SELECT_DATASET_PARAMS")
    '                End Try
    '            Catch ex As Exception
    '                MsgBox("Error al procesar la información." & Chr(10) & ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | SELECT_DATASET_PARAMS")
    '            End Try
    '        End If
    '    End If
    'End Function

    Public Function SELECT_DATASET(Consulta As String) As DataSet
        If TipoDB = "Access" Then
            Dim ConexionDB As New OleDbConnection(ConexionString)
            Dim DTSet As DataSet = Nothing
            Dim DTAdapter As OleDbDataAdapter = Nothing
            Dim Comando As OleDbCommand = Nothing
            Try
                Comando = New OleDbCommand(Consulta, ConexionDB)
                DTAdapter = New OleDbDataAdapter()
                DTSet = New DataSet
                DTAdapter.SelectCommand = Comando
                ConexionDB.Open()
                DTAdapter.Fill(DTSet)
                ConexionDB.Close()
                ConexionDB.Dispose()
                Return DTSet
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | SELECT_DATASET")
            End Try
        End If
    End Function


    Public Function INSERTDB(Consulta As String, ByRef Mensaje As String)
        If TipoDB = "Access" Then
            Dim ConexionDB As New OleDbConnection(ConexionString)
            Dim Comando As OleDbCommand = Nothing
            If ConexionDB IsNot Nothing Then
                Try
                    Comando = New OleDbCommand(Consulta, ConexionDB)
                    Comando.ExecuteNonQuery()
                    MsgBox(Mensaje, MsgBoxStyle.Information, "Corporativo LUIN")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | INSERTDB")
                End Try
                ConexionDB.Close()
                ConexionDB.Dispose()
            Else
                MsgBox("No hay conexión con la base de datos.", MsgBoxStyle.Critical, "ERROR | Corporativo LUIN  | INSERTDB")
            End If
        End If
    End Function


    Public Function UPDATEDB(Consulta As String)
        If TipoDB = "Access" Then
            Dim ConexionDB As New OleDbConnection(ConexionString)
            Dim Comando As OleDbCommand = Nothing
            If ConexionDB IsNot Nothing Then
                Try
                    Comando = New OleDbCommand(Consulta, ConexionDB)
                    Comando.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | UPDATEDB")
                End Try
                ConexionDB.Close()
                ConexionDB.Dispose()
            Else
                MsgBox("No hay conexión con la base de datos.", MsgBoxStyle.Critical, "ERROR | Corporativo LUIN  | UPDATEDB")
            End If
        End If
    End Function


    Public Function DELETEDB(Consulta As String)
        If TipoDB = "Access" Then
            Dim ConexionDB As New OleDbConnection(ConexionString)
            Dim Comando As OleDbCommand = Nothing
            If ConexionDB IsNot Nothing Then
                Try
                    Comando = New OleDbCommand(Consulta, ConexionDB)
                    Comando.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR | Corporativo LUIN | DELETEDB")
                End Try
                ConexionDB.Close()
                ConexionDB.Dispose()
            Else
                MsgBox("No hay conexión con la base de datos.", MsgBoxStyle.Critical, "ERROR | Corporativo LUIN  | DELETEDB")
            End If
        End If
    End Function
End Class
