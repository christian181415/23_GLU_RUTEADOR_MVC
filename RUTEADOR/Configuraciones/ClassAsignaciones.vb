Public Class ClassAsignaciones
    Dim NewConsulta As ClassEntidades
#Region "CONFIGURACION DE BOTONES"
    Public Function Primary(Componente As Button, Texto As String)
        Componente.BackColor = Color.FromName("Control")
        Componente.ForeColor = Color.Black
        Componente.FlatStyle = FlatStyle.Flat
        Componente.FlatAppearance.BorderSize = 0
        Componente.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue
        Componente.Text = Texto
    End Function

    Public Function Success(Componente As Button, Texto As String)
        Componente.BackColor = Color.FromName("Control")
        Componente.ForeColor = Color.Black
        Componente.FlatStyle = FlatStyle.Flat
        Componente.FlatAppearance.BorderSize = 0
        Componente.FlatAppearance.MouseOverBackColor = Color.LightGreen
        Componente.Text = Texto
    End Function

    Public Function Secondary(Componente As Button, Texto As String)
        Componente.BackColor = Color.FromName("Control")
        Componente.ForeColor = Color.Black
        Componente.FlatStyle = FlatStyle.Flat
        Componente.FlatAppearance.BorderSize = 0
        Componente.FlatAppearance.MouseOverBackColor = Color.FromArgb(250, 114, 104)
        Componente.Text = Texto
    End Function

    Public Function Warning(Componente As Button, Texto As String)
        Componente.BackColor = Color.FromName("Control")
        Componente.ForeColor = Color.Black
        Componente.FlatStyle = FlatStyle.Flat
        Componente.FlatAppearance.BorderSize = 0
        Componente.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 193, 7)
        Componente.Text = Texto
    End Function
#End Region


#Region "CONFIGURACION DE COMBO-BOX"
    Public Function Block(Componente As ComboBox, Texto As String)
        Componente.DataSource = Nothing
        Componente.Items.Add(Texto.ToUpper)
        Componente.SelectedIndex = 0
        Componente.Enabled = False
    End Function
#End Region


#Region "MOSTRAR INFO DB"
    Public Function Show(Componente As Object, Funcion As Object, Buscar As String, Limpiar As Boolean, Habilitar As Boolean)
        If Habilitar = True Then
            Componente.Enabled = True
        Else
            Componente.Enabled = False
        End If


        If Limpiar = True Then
            Componente.DataSource = Funcion
            Componente.DisplayMember = Buscar
            Componente.SelectedIndex = -1
        ElseIf Limpiar = False Then
            Componente.DataSource = Funcion
            Componente.DisplayMember = Buscar
        End If
    End Function
#End Region


End Class
