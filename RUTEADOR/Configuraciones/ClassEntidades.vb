Imports System.Data.OleDb

Public Class ClassEntidades
    Dim NewProcessDB As New ClassAccesos

#Region "//--------------------CLIENTES"
    '//--------------------CREAR CLIENTES
    Public Function CrearCliente(Nombre As String, Domicilio As String)
        Dim Consulta As String = "INSERT INTO Clientes(Nombre, Domicilio, Status) " &
                                "VALUES('" & Nombre & "', '" & Domicilio & "', True)"
        Dim Mensaje As String = "CLIENTE REGISTRADO."
        NewProcessDB.INSERTDB(Consulta, Mensaje)
    End Function
    '//--------------------MOSTRAR CLIENTES
    Public Function MostrarClientes() As DataTable
        Dim Datos As DataSet = Nothing
        Dim Resultado As DataTable = Nothing
        Dim Consulta As String = "SELECT Nombre FROM (Clientes " &
                                "INNER JOIN Rutas On Clientes.IdCliente = Rutas.Cliente_ID) " &
                                "INNER JOIN InfoRutas On Rutas.IdRuta = InfoRutas.Ruta_ID " &
                                "WHERE Status = True " &
                                "GROUP BY Nombre;"
        Datos = NewProcessDB.SELECT_DATASET(Consulta)
        If Datos IsNot Nothing Then
            Resultado = Datos.Tables(0)
            Return Resultado
        End If
    End Function
    '//--------------------MODIFICAR CLIENTES
    '//--------------------ELIMINAR CLIENTES
#End Region



#Region "//--------------------CHOFERES"
    '//--------------------CREAR CHOFERES
    Public Function CrearChofer(Nombre As String, Telefono As String)
        Dim Consulta As String = "INSERT INTO Choferes(Nombre, Telefono, Status) 
                                VALUES('" & Nombre & "', '" & Telefono & "', True)"
        Dim Mensaje As String = "CHOFER REGISTRADO."
        NewProcessDB.INSERTDB(Consulta, Mensaje)
    End Function
    '//--------------------MOSTRAR CHOFERES
    Public Function MostrarChoferes()
        Dim Datos As DataSet = Nothing
        Dim Resultado As DataTable = Nothing
        Dim Consulta As String = "SELECT * FROM Choferes WHERE Status = True"
        Datos = NewProcessDB.SELECT_DATASET(Consulta)
        If Datos IsNot Nothing Then
            Resultado = Datos.Tables(0)
            Return Resultado
        End If
    End Function
    '//--------------------MODIFICAR CHOFERES
    '//--------------------ELIMINAR CHOFERES
#End Region



#Region "//--------------------UNIDADES"
    '//--------------------CREAR UNIDADES
    '//--------------------MOSTRAR UNIDADES
    Public Function MostrarUnidades(Cliente As String)
        Dim Datos As DataSet = Nothing
        Dim Resultado As DataTable = Nothing
        Dim Consulta As String = "SELECT Vehiculo FROM Unidades " &
                                "INNER JOIN ((Clientes " &
                                "INNER JOIN Rutas ON Clientes.IdCliente = Rutas.Cliente_ID) " &
                                "INNER JOIN InfoRutas ON Rutas.IdRuta = InfoRutas.Ruta_ID) ON Unidades.IdUnidad = InfoRutas.Unidad_ID " &
                                "WHERE Nombre = '" & Cliente & "' " &
                                "GROUP BY Vehiculo;"
        Datos = NewProcessDB.SELECT_DATASET(Consulta)
        If Datos IsNot Nothing Then
            Resultado = Datos.Tables(0)
            Return Resultado
        End If
    End Function
    '//--------------------MODIFICAR UNIDADES
    '//--------------------ELIMINAR UNIDADES
#End Region



#Region "//--------------------CASETAS"
    '//--------------------CREAR CASETAS
    '//--------------------MOSTRAR CASETAS
    '//--------------------MODIFICAR CASETAS
    '//--------------------ELIMINAR CASETAS
#End Region


#Region "//--------------------RUTAS"
    '//--------------------CREAR RUTAS
    '//--------------------MOSTRAR RUTAS
    '//--------------------MODIFICAR RUTAS
    '//--------------------ELIMINAR RUTAS
#End Region
End Class
