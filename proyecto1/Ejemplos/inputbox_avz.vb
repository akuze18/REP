Public Class inputbox_avz
    Private USER As String = ""  '' Usuario correcto
    Private PASSWORD As String = ""  '' Contraseña correcta
    Private MAX_TRIES As Integer = 0  '' Máximo número de intentos (Si es < 1 entonces desactivado)
    Private CONTADOR As Integer = 1 '' Contador de intentos

    Private Sub inputbox_avz_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal v_user As String, ByVal v_password As String, Optional _
    ByVal v_tries As Integer = 0, Optional ByVal titulo As String = "Login de seguridad")
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        USER = v_user
        PASSWORD = v_password
        MAX_TRIES = v_tries
        Me.Text = titulo
    End Sub

    Private Sub b_cancelar_Click(sender As System.Object, e As System.EventArgs) Handles b_cancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub b_aceptar_Click(sender As System.Object, e As System.EventArgs) Handles b_aceptar.Click
        ''
        If t_usuario.Text = "" Then
            MsgBox("Introduce el nombre de usuario", MsgBoxStyle.Exclamation, "Aviso")
        Else
            If t_contrasena.Text = "" Then
                MsgBox("Introduce la contraseña", MsgBoxStyle.Exclamation, "Aviso")
            Else
                comprobar_datos()
            End If
        End If
        ''
    End Sub

    Private Sub comprobar_datos()
        ''
        If t_usuario.Text = (USER) And t_contrasena.Text = (PASSWORD) Then
            '' Los datos son correctos devolvemos ok al formulario invocador
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            '' Los datos son incorrectos
            If MAX_TRIES > 0 Then
                MsgBox("Los datos introducidos son incorrectos" & Chr(13) & Chr(13) _
                & "Quedan: " & MAX_TRIES - CONTADOR & " intentos", MsgBoxStyle.Critical, "Aviso")
            Else
                MsgBox("Los datos introducidos son incorrectos", MsgBoxStyle.Exclamation, "Aviso")
            End If
            '' Si el valor de intentos máximos es > 0 entonces controlamos los intentos realizados
            If MAX_TRIES > 0 Then
                If CONTADOR = MAX_TRIES Then
                    '' Si el valor del contador es igual al maximo de intentos cerramos el programa
                    Me.DialogResult = Windows.Forms.DialogResult.No
                Else
                    '' Sino aumentamos el contador
                    CONTADOR += 1
                End If
            End If
            ''
        End If
        ''
    End Sub
End Class