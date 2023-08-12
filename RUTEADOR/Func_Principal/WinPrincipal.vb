Public Class WinPrincipal
    Dim Funcion As New ClassEntidades
    Dim Btn, CBox, Consulta As New ClassAsignaciones

    Private Sub WinPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '//MOSTRAR LA INFORMACION DE DB INICIAL
        CBoxCliente.SelectedIndex = -1
        CBox.Block(CBoxChofer, "SELECCIONE UN CLIENTE")
        CBox.Block(CBoxUnidad, "SELECCIONE UN CLIENTE")
        PRuta.Enabled = False
        PActions2.Enabled = False
        '//CONFIGURAR LOS BOTONES
        Btn.Primary(BtnLimpiar, "LIMPIAR")
        Btn.Secondary(BtnSalir, "SALIR")
        Btn.Primary(BtnMCatalogo, "Modificar")
    End Sub

    Private Sub CBoxCliente_MouseClick(sender As Object, e As MouseEventArgs) Handles CBoxCliente.MouseClick
        '//MOSTRAR LOS CLIENTES EXISTENTES
        Consulta.Show(CBoxCliente, Funcion.MostrarClientes, "Nombre", True, True)
        If CBoxCliente.SelectedIndex = -1 Then
            CBox.Block(CBoxChofer, "SELECCIONE UN CLIENTE")
            CBox.Block(CBoxUnidad, "SELECCIONE UN CLIENTE")
        Else
            Consulta.Show(CBoxCliente, Funcion.MostrarClientes, "Nombre", False, True)
        End If
    End Sub
    Private Sub CBoxCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxCliente.SelectedIndexChanged
        '//MOSTRAR LOS CHOFERES Y UNIDADES SI SE SELECCIONA UN CLIENTE
        If CBoxCliente.SelectedIndex = -1 Then
            CBoxChofer.Enabled = False
            CBoxUnidad.Enabled = False
        Else
            Consulta.Show(CBoxChofer, Funcion.MostrarChoferes, "Nombre", False, True)
            Consulta.Show(CBoxUnidad, Funcion.MostrarUnidades(CBoxCliente.Text), "Vehiculo", False, True)
            If CBoxChofer.DataSource Is Nothing Then
                CBox.Block(CBoxChofer, "SIN DATOS QUE MOSTRAR")
            End If
            If CBoxUnidad.DataSource Is Nothing Then
                CBox.Block(CBoxUnidad, "SIN DATOS QUE MOSTRAR")
            End If
        End If
    End Sub

End Class
