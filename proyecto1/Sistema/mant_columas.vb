Public Class mant_columas
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _columna As dt_columnas.myRow
    Private _id_vista As Integer

#Region "Constructores"
    Public Sub New(ByVal id_vista As Integer)
        InitializeComponent()
        _columna = Nothing
        _id_vista = id_vista
    End Sub
    Public Sub New(ByVal columna As dt_columnas.myRow)
        InitializeComponent()
        _columna = columna
        _id_vista = _columna.VISTA
    End Sub
#End Region

    Private Sub mant_columas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim main_vista As dt_vista.myRow
        main_vista = base.VISTA(_id_vista)
        tb_vista.Text = main_vista.DESCRIP
        tb_vista.Enabled = False
        If Not IsNothing(_columna) Then
            'Entonces es una columna para editar
            tb_cod_columna.Text = _columna.COD
            tb_txt_columna.Text = _columna.DESCRIP
            ckTotal.Checked = _columna.TOTALIZA
        End If
    End Sub

    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btn_ok_Click(sender As System.Object, e As System.EventArgs) Handles btn_ok.Click
        If String.IsNullOrEmpty(tb_cod_columna.Text) Then
            Mensaje.Alerta("Debe completar el campo Codigo de Columna")
            tb_cod_columna.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(tb_txt_columna.Text) Then
            Mensaje.Alerta("Debe completar el campo Nombre de Columna")
            tb_txt_columna.Focus()
            Exit Sub
        End If
        Dim resultado As dt_query_result.myRow
        Dim cod_col As String = tb_cod_columna.Text
        Dim txt_col As String = tb_txt_columna.Text
        Dim total As Boolean = ckTotal.Checked
        If IsNothing(_columna) Then
            'estamos ingresando uno nuevo
            resultado = base.NEW_COLUMNAS(_id_vista, cod_col, txt_col, total)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se ha producido un error al intentar guardar la columna")
            Else
                If resultado.COD_ESTADO = 1 Then
                    Mensaje.Info("Se ha ingresado correctamente la columna")
                    DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                End If
            End If
        Else
            'columna ya existia, se modifica
            If total <> _columna.TOTALIZA Then
                'SI SON DIFERENTE, ENTONCES SE CAMBIO, REVISO SI TIENE CONTENIDO ANTES DE SEGUIR
                Dim confirmacion As DialogResult
                confirmacion = Mensaje.Confirma("Si cambia el campo Totaliza, todas las reglas asociadas se perderán, está seguro que desea continuar?")
                If confirmacion = Windows.Forms.DialogResult.Yes Then
                    Dim proceso As dt_query_result.myRow
                    proceso = base.DROP_REGLA_ALL(_columna.ID)
                    If IsNothing(proceso) Then
                        Mensaje.Fallo("Se produjo un error al eliminar las reglas de la columna " + _columna.DESCRIP)
                        Exit Sub
                    Else
                        If proceso.COD_ESTADO = 1 Then
                            If proceso.AFECTADAS > 0 Then
                                Mensaje.Alerta("Se eliminaron " + proceso.AFECTADAS.ToString + " reglas asociadas")
                            End If
                        Else
                            Mensaje.Fallo(proceso.TXT_ESTADO)
                            Exit Sub
                        End If
                    End If
                Else
                    Exit Sub
                End If
            End If
            resultado = base.MOD_COLUMNAS(_columna.ID, cod_col, txt_col, _columna.ORDEN, total)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se ha producido un error al intentar guardar la columna")
            Else
                If resultado.COD_ESTADO = 1 Then
                    Mensaje.Info("Se ha modificado correctamente la columna")
                    DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                End If
            End If
        End If

    End Sub
End Class