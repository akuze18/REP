Imports System.Threading
Imports ACode
'Este es el delegado que se encargará de hacer la magia
Public Delegate Sub ProcesoSecundario(datos As DataTable)
Public Delegate Sub ProcesoSecundario2(datos As DataTable())

Public Class BackProcess
#Region "Variables de Clase"

    Private _resultado As DataTable
    Private _resultado2 As DataTable()
    Private _hilo As Thread
    'Para medir los tiempos en segundos
    Private _tTotal, _tUpdate, _TActual As Integer

    Private _fecha1, _fecha2 As DateTime
    Private _fechaText1 As String
    Private _texto1, _texto2, _texto3 As String
    Private _periodo1 As Vperiodo
    Private _int_vars As Integer()

    Private _base As base_REP
#End Region
#Region "Constructor"
    Public Sub New(ByVal base_actual As base_REP, ByVal tiempo_total_estimado As Integer, ByVal tiempo_actualizacion As Integer)
        _base = base_actual
        _tTotal = tiempo_total_estimado        'tiempo total estimado: 10 segundos
        _tUpdate = tiempo_actualizacion        'actualizar la barra cada: 1 segundo
        _TActual = 0
    End Sub
#End Region
#Region "Proceso en segundo plano"
    Private Event capturar As ProcesoSecundario
    Private Event capturar2 As ProcesoSecundario2
    Private Sub captura_res(ByVal datos As DataTable)
        _resultado = datos
    End Sub
    Private Sub captura_mas_res(ByVal datos As DataTable())
        _resultado2 = datos
    End Sub
#End Region
#Region "Salidas y Actualizaciones"
    Public Function resultado() As DataTable
        Return _resultado
    End Function
    Public Function resultados() As DataTable()
        Return _resultado2
    End Function
    Public ReadOnly Property tiempo_total As Integer
        Get
            Return _tTotal
        End Get
    End Property
    Public ReadOnly Property tiempo_cambio As Integer
        Get
            Return _tUpdate
        End Get
    End Property
    Public ReadOnly Property intervalos As Integer
        Get
            Return Math.Ceiling(_tTotal / _tUpdate)
        End Get
    End Property
    Public ReadOnly Property isWorking As Boolean
        Get
            Return _hilo.ThreadState = ThreadState.Running
        End Get
    End Property
    Public Sub Keep()
        Thread.Sleep(1000)
        My.Application.DoEvents()
        _TActual = _TActual + 1
    End Sub
    Public Function UpdateBar() As Boolean
        Return _TActual Mod _tUpdate = 0
    End Function
#End Region

#Region "form_reporte"
    Public Sub INI_REPORTE(ByVal id_vista As Integer, ByVal id_reporte As Integer, ByVal periodo As DateTime, ByVal acumulado As Integer, ByVal cantidad As Integer, ByVal presentacion As Integer)
        ReDim _int_vars(5)
        _int_vars(0) = id_vista
        _fecha1 = periodo
        _int_vars(1) = acumulado
        _int_vars(2) = cantidad
        _int_vars(3) = presentacion
        _int_vars(4) = id_reporte

        'Agregamos el handler del evento (si no lo hacemos no podremos interceptarlo)
        AddHandler capturar2, New ProcesoSecundario2(AddressOf captura_mas_res)
        'Creamos un delegado para el método ImprimirSuma()
        Dim ts As ThreadStart = New ThreadStart(AddressOf EXE_REPORTE)
        'Creamos un hilo para ejecutar el delegado...
        _hilo = New Thread(ts)
        'Iniciamos la ejecucion del nuevo hilo
        _hilo.Start()
    End Sub
    Private Sub EXE_REPORTE()
        Dim tabla() As DataTable
        'tabla =  Dim datos As DataTable()
        Select Case _int_vars(3)
            Case 1
                tabla = _base.REPORTE_RESUMEN(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case 2
                tabla = _base.REPORTE_MES(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case 3
                tabla = _base.REPORTE_DETALLE(_int_vars(4), _fecha1.Year, _fecha1.Month, _int_vars(1))
            Case 4
                tabla = _base.REPORTE_COMPARATIVO(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case 5
                tabla = _base.REPORTE_RESUMEN_JP(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case 7
                tabla = _base.REPORTE_COMPARATIVO_JP(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case 8
                tabla = _base.REPORTE_RESUMEN_COMPARATIVO(_int_vars(0), _fecha1.Year, _fecha1.Month, _int_vars(1), _int_vars(2))
            Case Else   'CASE 3
                tabla = _base.REPORTE_DETALLE(_int_vars(4), _fecha1.Year, _fecha1.Month, _int_vars(1))
        End Select

        RaiseEvent capturar2(tabla)
    End Sub
#End Region

End Class