Public Class mant_tipo_reporte
#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
#End Region

#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Sub New(ByVal id_reporte As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim reporte As dt_tipo_reporte.myRow
        reporte = base.TIPO_REPORTE(id_reporte)
        With TBDescrip
            .Text = reporte.DESCRIP
            .Enabled = False
        End With
        With TBpre
            .Text = reporte.PRE
            .Enabled = False
        End With

    End Sub

#End Region

End Class
