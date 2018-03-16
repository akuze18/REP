Imports ACode
Imports System.Globalization
Imports System.Threading

''' <summary>
''' Esta clase se diseña para condensar todas las consultas SQL a la base y otros datos de configuraciones, 
''' de forma que los formularios unicamente solicitan los datos puntuales o grupos de datos (datatable) que 
''' se requiera para visualizar,además de contener la logica para realizar insert, update y delete cuando sea necesario
''' </summary>
''' <remarks></remarks>
Public Class base_REP
    Private maestro As master_control
    Private _consulta As String
    Private _tabla As DataTable

#Region "Constructor"
    Public Sub New()
        maestro = New master_control()
        maestro.vars("EJECUCION", "TIMEOUT") = 600
    End Sub
#End Region

#Region "Estado de Conexion"
    Public ReadOnly Property estado As Boolean
        Get
            Return maestro.estado
        End Get
    End Property
    Public ReadOnly Property estado_desc As String
        Get
            Return maestro.estado_desc
        End Get
    End Property
    Public Property servidor As String
        Get
            Return maestro.servidor
        End Get
        Set(value As String)
            maestro.servidor = value
        End Set
    End Property
    Public Property base_dato As String
        Get
            Return maestro.base_dato
        End Get
        Set(value As String)
            maestro.base_dato = value
        End Set
    End Property
    Public Property usuario As String
        Get
            Return maestro.usuario
        End Get
        Set(value As String)
            maestro.usuario = value
        End Set
    End Property
    Public Property password As String
        Get
            Return maestro.password
        End Get
        Set(value As String)
            maestro.password = value
        End Set
    End Property
#End Region

#Region "Variables de INI"
    Public ReadOnly Property sections As String()
        Get
            Return maestro.sections
        End Get
    End Property
    Public ReadOnly Property keys(ByVal section As String) As String()
        Get
            Return maestro.keys(section)
        End Get
    End Property
    Public Property vars(ByVal section As String, ByVal key As String) As String
        Get
            Return maestro.vars(section, key)
        End Get
        Set(value As String)
            maestro.vars(section, key) = value
        End Set
    End Property
#End Region

#Region "Cabeceras de DataGrids y Datatable"
    Public Function cabecera_sector_distrib() As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("ID", Type.GetType("System.String"))
        tabla.Columns.Add("Descripcion", Type.GetType("System.String"))
        tabla.Columns.Add("Valor", Type.GetType("System.Double"))
        Return tabla
    End Function

#End Region

#Region "Codigo Unico para la clase"
    Private Function consulta_cambio(ByVal consulta As String) As dt_query_result.myRow
        _tabla = maestro.ejecuta(consulta)

        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 1 Then
                Return resultado.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function
#End Region

#Region "Reportes"
    Public Function REPORTE_RESUMEN(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_RESUMEN " + id_vista.ToString + "," + año.ToString + "," + mes.ToString + "," + acumulado.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = tabla.Columns.Count - 1 To 0 Step -1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                Dim col_name As String = tabla.Columns(col).ColumnName
                If col_tip = "Decimal" Then
                    Dim hay_valor As Boolean = False
                    For fil = 0 To tabla.Rows.Count - 1
                        If tabla.Rows(fil).Item(col) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    Next
                    If hay_valor Then
                        For Each row As DataRow In tabla.Rows
                            If row("GRUPO") = "CONT" Or row("GRUPO") = "CONT_AD" Then
                                row(col) = row(col) / cantidad
                            End If
                        Next
                    Else
                        tabla.Columns.Remove(col_name)
                    End If
                End If
            Next
            'elimino filas que no tienen valores
            For fil = tabla.Rows.Count - 1 To 0 Step -1
                Dim hay_valor As Boolean = False
                For i = 0 To tabla.Columns.Count - 1
                    Dim col_tipo As String = tabla.Columns(i).DataType.Name
                    If col_tipo = "Decimal" Then
                        If tabla.Rows(fil).Item(i) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    End If
                Next
                If Not hay_valor Then
                    tabla.Rows.RemoveAt(fil)
                End If
            Next
        Next
        Return tablas
    End Function
    Public Function REPORTE_MES(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_MESES " + id_vista.ToString + "," + año.ToString + "," + mes.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = tabla.Columns.Count - 1 To 0 Step -1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                Dim tiene_grupo As Boolean = tabla.Columns.Contains("GRUPO")
                If col_tip = "Decimal" Then
                    For Each row As DataRow In tabla.Rows
                        If tiene_grupo Then
                            If row("GRUPO") = "CONT" Then
                                row(col) = row(col) / cantidad
                            End If
                        Else
                            row(col) = row(col) / cantidad
                        End If
                    Next
                End If
            Next
            'elimino filas que no tienen valores
            For fil = tabla.Rows.Count - 1 To 0 Step -1
                Dim hay_valor As Boolean = False
                For i = 0 To tabla.Columns.Count - 1
                    Dim col_tipo As String = tabla.Columns(i).DataType.Name
                    If col_tipo = "Decimal" Then
                        If tabla.Rows(fil).Item(i) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    End If
                Next
                If Not hay_valor Then
                    tabla.Rows.RemoveAt(fil)
                End If
            Next
        Next
        Return tablas
    End Function
    Public Function REPORTE_DETALLE(ByVal id_reporte As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer) As DataTable()
        _consulta = "SELECT * FROM REP_detalle(" + id_reporte.ToString + "," + año.ToString + "," + mes.ToString + "," + acumulado.ToString + ")"
        Return maestro.execute(_consulta)
    End Function
    Public Function REPORTE_COMPARATIVO(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_COMPARATIVO " + id_vista.ToString + "," + año.ToString + "," + mes.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = 0 To tabla.Columns.Count - 1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                If col_tip = "Decimal" Then
                    For Each row As DataRow In tabla.Rows
                        row(col) = row(col) / cantidad
                    Next
                End If
            Next
        Next
        Return tablas
    End Function
    'Reportes nuevos solicitados por Shibuya para cierre de Abril 2017
    Public Function REPORTE_RESUMEN_JP(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_RESUMEN_JP " + id_vista.ToString + "," + año.ToString + "," + mes.ToString + "," + acumulado.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = tabla.Columns.Count - 1 To 0 Step -1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                Dim col_name As String = tabla.Columns(col).ColumnName
                If col_tip = "Decimal" Then
                    Dim hay_valor As Boolean = False
                    For fil = 0 To tabla.Rows.Count - 1
                        If tabla.Rows(fil).Item(col) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    Next
                    If hay_valor Then
                        For Each row As DataRow In tabla.Rows
                            If row("GRUPO") = "CONT" Then
                                row(col) = row(col) / cantidad
                            End If
                        Next
                    Else
                        tabla.Columns.Remove(col_name)
                    End If
                End If
            Next
            'elimino filas que no tienen valores
            For fil = tabla.Rows.Count - 1 To 0 Step -1
                Dim hay_valor As Boolean = False
                If tabla.Columns.Contains("DESCRIPCIÓN") Then
                    Dim fila_name As String
                    fila_name = tabla.Rows(fil).Item("DESCRIPCIÓN")
                    If fila_name = "" Then
                        hay_valor = True
                    End If
                End If
                For i = 0 To tabla.Columns.Count - 1
                    Dim col_tipo As String = tabla.Columns(i).DataType.Name
                    If col_tipo = "Decimal" Then
                        If tabla.Rows(fil).Item(i) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    End If
                Next
                If Not hay_valor Then
                    tabla.Rows.RemoveAt(fil)
                End If
            Next
        Next
        Return tablas
    End Function
    Public Function REPORTE_COMPARATIVO_JP(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_COMPARATIVO_JP " + id_vista.ToString + "," + año.ToString + "," + mes.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = 0 To tabla.Columns.Count - 1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                If col_tip = "Decimal" Then
                    For Each row As DataRow In tabla.Rows
                        row(col) = row(col) / cantidad
                    Next
                End If
            Next
            'elimino filas que no tienen valores
            For fil = tabla.Rows.Count - 1 To 0 Step -1
                Dim hay_valor As Boolean = False
                For i = 0 To tabla.Columns.Count - 1
                    Dim col_tipo As String = tabla.Columns(i).DataType.Name
                    If col_tipo = "Decimal" Then
                        If tabla.Rows(fil).Item(i) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    End If
                Next
                If Not hay_valor Then
                    tabla.Rows.RemoveAt(fil)
                End If
            Next
        Next
        Return tablas
    End Function
    'Reporte solicitado por Claudio para cierre Agosto 2017
    Public Function REPORTE_RESUMEN_COMPARATIVO(ByVal id_vista As Integer, ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer, ByVal cantidad As Integer) As DataTable()
        _consulta = "EXEC REP_RESUMEN_COMPARATIVO " + id_vista.ToString + "," + año.ToString + "," + mes.ToString + "," + acumulado.ToString
        Dim tablas As DataTable()
        tablas = maestro.execute(_consulta)
        For Each tabla As DataTable In tablas
            For col = tabla.Columns.Count - 1 To 0 Step -1
                Dim col_tip As String = tabla.Columns(col).DataType.Name
                Dim col_name As String = tabla.Columns(col).ColumnName
                If col_tip = "Decimal" Then
                    Dim hay_valor As Boolean = False
                    For fil = 0 To tabla.Rows.Count - 1
                        If tabla.Rows(fil).Item(col) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    Next
                    If hay_valor Then
                        For Each row As DataRow In tabla.Rows
                            If row("GRUPO") = "CONT" Or row("GRUPO") = "CONT_AD" Then
                                row(col) = row(col) / cantidad
                            End If
                        Next
                    Else
                        tabla.Columns.Remove(col_name)
                    End If
                End If
            Next
            'elimino filas que no tienen valores
            For fil = tabla.Rows.Count - 1 To 0 Step -1
                Dim hay_valor As Boolean = False
                For i = 0 To tabla.Columns.Count - 1
                    Dim col_tipo As String = tabla.Columns(i).DataType.Name
                    If col_tipo = "Decimal" Then
                        If tabla.Rows(fil).Item(i) <> 0 Then
                            hay_valor = True
                            Exit For
                        End If
                    End If
                Next
                If Not hay_valor Then
                    tabla.Rows.RemoveAt(fil)
                End If
            Next
        Next
        Return tablas
    End Function
#End Region

#Region "Procesos"
    Public Enum modo_clasificar
        full_clear = 1
        actualiza = 2
        solo_nuevas = 3
    End Enum
    Public Function AUTOCLASIFICAR(ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer, ByVal id_reporte As Integer) As DataTable()
        _consulta = "EXEC REP_autoclasificar " + año.ToString + "," + mes.ToString + "," + acumulado.ToString + _
            "," + id_reporte.ToString + ""
        Dim resultados() As DataTable
        resultados = maestro.execute(_consulta)
        If IsNothing(resultados) Then
            Return Nothing
        Else
            Return resultados
        End If
    End Function
    Public Function AUTOCLASIFICAR(ByVal año As Integer, ByVal mes As Integer, ByVal acumulado As Integer, ByVal id_reporte As Integer, ByVal modo As modo_clasificar) As DataTable()
        _consulta = "EXEC REP_autoclasificar " + año.ToString + "," + mes.ToString + "," + acumulado.ToString + _
            "," + id_reporte.ToString + "," + CInt(modo).ToString
        Dim resultados() As DataTable
        resultados = maestro.execute(_consulta)
        If IsNothing(resultados) Then
            Return Nothing
        Else
            Return resultados
        End If
    End Function
#End Region

#Region "Tablas"
#Region "REP_TIPO_REPORTE"
    Public Function TIPO_REPORTE() As dt_tipo_reporte
        _consulta = "SELECT ID,DESCRIP,PRE FROM REP_TIPO_REPORTE"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_tipo_reporte(_tabla)
    End Function
    Public Function TIPO_REPORTE(ByVal reporte As Integer) As dt_tipo_reporte.myRow
        Return TIPO_REPORTE().FIND_by_ID(reporte)
    End Function
#End Region

#Region "REP_INDICE_CUENTAS"
    Public Function CUENTAS() As indice_cuenta_table
        _consulta = "SELECT B.ID,B.NUM_CUENTA,B.COD_DEPTO,B.COD_LUGAR,B.COD_GESTN FROM REP_INDICE_CUENTAS B"
        _tabla = maestro.ejecuta(_consulta)
        Return New indice_cuenta_table(_tabla, indice_cuenta_table.display.full)
    End Function
    Public Function CUENTA_SINGLE(ByVal id_cuenta As Integer) As indice_cuenta_row
        Return CUENTAS.FIND_by_ID(id_cuenta)
    End Function
    Public Function SOLO_CUENTA() As indice_cuenta_table
        _consulta = "SELECT COUNT(B.ID)[ID],B.NUM_CUENTA,''[COD_DEPTO],''[COD_LUGAR],''[COD_GESTN] FROM REP_INDICE_CUENTAS B GROUP BY B.NUM_CUENTA"
        _tabla = maestro.ejecuta(_consulta)
        Return New indice_cuenta_table(_tabla, indice_cuenta_table.display.cuenta)
    End Function
#End Region

#Region "REP_FILAS_REPORTE"
    Public Function FILAS_REPORTE(ByVal reporte As Integer) As dt_fila_reporte
        _consulta = "SELECT C.ID,C.DESCRIP,C.REPORTE,C.ORDEN,C.CAMBIAR,C.DISTRIB," +
        "C.TOTALIZAR,C.CCODE,C.TOTAL_PINTA FROM VIS_FILAS_REPORTE C WHERE C.REPORTE=" + reporte.ToString + " OR 0=" + reporte.ToString + " ORDER BY ORDEN"
        Return New dt_fila_reporte(maestro.ejecuta(_consulta))
    End Function
    Public Function FILA_REP(ByVal fila As Integer) As dt_fila_reporte.myRow
        Return FILAS_REPORTE(0).FIND_by_ID(fila)
    End Function
    Public Function NEW_FILAS_REPORTE(ByVal reporte As Integer, ByVal cod_personal As String, ByVal descripcion As String, ByVal cambiar As Boolean, ByVal pintar As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_FILAS_REPORTE " + reporte.ToString + ",'" + cod_personal + "','" + descripcion + "'," + _
            CInt(cambiar).ToString + "," + pintar.ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function MOD_ORDEN_FILA_REPORTE(ByVal id_fila As Integer, ByVal nuevo_orden As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_ORDEN_FILA_REPORTE " + id_fila.ToString + "," + nuevo_orden.ToString
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "REP_COMP_FILA"
    Public Function DETALLE_CUENT_COMP(ByVal fila As Integer) As indice_cuenta_table
        _consulta = "SELECT B.ID,B.NUM_CUENTA,B.COD_DEPTO,B.COD_LUGAR,B.COD_GESTN,A.ID[ID_COMP_FILA] FROM REP_COMP_FILA A INNER JOIN REP_INDICE_CUENTAS B ON A.CUENTA_COMP=B.ID WHERE NOT A.CUENTA_COMP IS NULL AND A.FILA_TOTAL=" + fila.ToString + " ORDER BY B.NUM_CUENTA"
        _tabla = maestro.ejecuta(_consulta)
        Return New indice_cuenta_table(_tabla, indice_cuenta_table.display.full)
    End Function
    Public Function DETALLE_FILA_COMP(ByVal fila As Integer) As dt_fila_reporte
        _consulta = "SELECT B.ID,B.DESCRIP,B.REPORTE,B.ORDEN,B.CAMBIAR,B.DISTRIB,B.TOTALIZAR,A.ID[ID_COMP_FILA] FROM REP_COMP_FILA A INNER JOIN VIS_FILAS_REPORTE B ON A.FILA_COMP=B.ID WHERE A.CUENTA_COMP IS NULL AND A.FILA_TOTAL=" + fila.ToString + " ORDER BY B.ORDEN"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_fila_reporte(_tabla)
    End Function
    Public Function COMPOSICION_CUENTAS(ByVal id_reporte As Integer) As comp_fila_table
        _consulta = "SELECT ID,FILA_TOTAL,FILA_COMP,CUENTA_COMP,REPORTE,DESDE,HASTA FROM REP_COMP_FILA WHERE NOT CUENTA_COMP IS NULL  AND REPORTE=" + id_reporte.ToString
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim composicion As comp_fila_table
            composicion = New comp_fila_table(_tabla)
            composicion.JOIN_CUENTAS(Me.CUENTAS)
            composicion.JOIN_FILAS_REPORTE(Me.FILAS_REPORTE(id_reporte))

            Return composicion
        End If
    End Function

    Public Function NEW_DETALLE_CUENTA_COMP(ByVal origen As Integer, ByVal cuenta As Integer, ByVal desde As DateTime, ByVal hasta As DateTime) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_COMP_FILA " + origen.ToString + "," + cuenta.ToString + ",'" + _
            desde.ToString("yyyyMMdd") + "','" + hasta.ToString("yyyyMMdd") + "',1"
        Return consulta_cambio(_consulta)
    End Function
    Public Function NEW_DETALLE_FILA_COMP(ByVal origen As Integer, ByVal fila As Integer, ByVal desde As DateTime, ByVal hasta As DateTime) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_COMP_FILA " + origen.ToString + "," + fila.ToString + ",'" + _
            desde.ToString("yyyyMMdd") + "','" + hasta.ToString("yyyyMMdd") + "',2"
        Return consulta_cambio(_consulta)
    End Function

    Public Function DROP_FILA_COMP(ByVal id_comp_fila As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_COMP_FILA " + id_comp_fila.ToString
        Return consulta_cambio(_consulta)
    End Function

#End Region

#Region "REP_TIPO_DISTRIBUCION"
    Public Function TIPO_DISTRIB() As tipo_distribucion_table
        _consulta = "SELECT ID,DESCRIPCION,SIGLA FROM REP_TIPO_DISTRIBUCION"
        _tabla = maestro.ejecuta(_consulta)
        Return New tipo_distribucion_table(_tabla)
    End Function
    Public Function TIPO_DISTRIB(ByVal id_distribucion As Integer) As tipo_distribucion_row
        Return TIPO_DISTRIB().FIND_by_ID(id_distribucion)
    End Function
#End Region

#Region "REP_DISTRIBxFILA"
    Public Function DETALLE_FILA_DIST(ByVal id_distribucion As Integer) As dt_fila_reporte
        _consulta = "SELECT B.ID,B.DESCRIP,B.REPORTE,B.ORDEN,B.CAMBIAR,B.DISTRIB,B.TOTALIZAR FROM REP_DISTRIBxFILA A INNER JOIN VIS_FILAS_REPORTE B ON A.FILA=B.ID WHERE A.DISTRIBUCION=" + id_distribucion.ToString + " ORDER BY B.ORDEN"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_fila_reporte(_tabla)
    End Function
#End Region

#Region "REP_SECTORES"
    Public Function SECTORES() As sector_table
        _consulta = "SELECT ID,DEPTO,LUGAR,NOMBRE_DEPTO,NOMBRE_LUGAR FROM REP_SECTORES ORDER BY DEPTO,LUGAR"
        _tabla = maestro.ejecuta(_consulta)
        Return New sector_table(_tabla, sector_table.display.full)
    End Function
    Public Function SECTOR(ByVal id_sector As Integer) As sector_row
        Return SECTORES().FIND_by_ID(id_sector)
    End Function
    Public Function DEPTOS() As DataTable
        _consulta = "SELECT MAX(ID)[ID],DEPTO,MAX(LUGAR)[LUGAR],NOMBRE_DEPTO,MAX(NOMBRE_LUGAR)[NOMBRE_LUGAR] FROM REP_SECTORES GROUP BY DEPTO,NOMBRE_DEPTO ORDER BY DEPTO"
        _tabla = maestro.ejecuta(_consulta)
        Dim tSect As New sector_table(_tabla, sector_table.display.depto)
        _tabla = New DataTable
        _tabla.Columns.Add("COD", Type.GetType("System.String"))
        _tabla.Columns.Add("TXT", Type.GetType("System.String"))
        For Each depto As sector_row In tSect.Rows
            Dim fila As DataRow = _tabla.NewRow
            fila(0) = depto.COD_DEPTO
            fila(1) = depto.toString
            _tabla.Rows.Add(fila)
        Next
        Return _tabla
    End Function
    Public Function LUGARES() As DataTable
        _consulta = "SELECT MAX(ID)[ID],MAX(DEPTO)[DEPTO],LUGAR,MAX(NOMBRE_DEPTO)[NOMBRE_DEPTO],NOMBRE_LUGAR FROM REP_SECTORES GROUP BY LUGAR,NOMBRE_LUGAR ORDER BY LUGAR"
        _tabla = maestro.ejecuta(_consulta)
        Dim tSect As New sector_table(_tabla, sector_table.display.lugar)
        _tabla = New DataTable
        _tabla.Columns.Add("COD", Type.GetType("System.String"))
        _tabla.Columns.Add("TXT", Type.GetType("System.String"))
        For Each lugar As sector_row In tSect.Rows
            Dim fila As DataRow = _tabla.NewRow
            fila(0) = lugar.COD_LUGAR
            fila(1) = lugar.toString
            _tabla.Rows.Add(fila)
        Next
        Return _tabla
    End Function
    Public Function GESTION() As DataTable
        _tabla = New DataTable
        _tabla.Columns.Add("COD", Type.GetType("System.String"))
        _tabla.Columns.Add("TXT", Type.GetType("System.String"))
        For i = 0 To 3
            Dim fila As DataRow = _tabla.NewRow
            Dim cod, txt As String
            Select Case i
                Case 0
                    cod = "01"
                    txt = "Administración"
                Case 1
                    cod = "02"
                    txt = "Produccion"
                Case 2
                    cod = "03"
                    txt = "Control de Calidad"
                Case Else
                    cod = "04"
                    txt = "PT Terceros"
            End Select

            fila(0) = cod
            fila(1) = txt
            _tabla.Rows.Add(fila)
        Next
        Return _tabla
    End Function
#End Region

#Region "REP_DISTRIBxSECTOR"
    Public Function SECTORES_SALIDA(ByVal id_distrib As Integer) As sector_table
        _consulta = "SELECT A.ID,A.DEPTO,A.LUGAR,A.NOMBRE_DEPTO,A.NOMBRE_LUGAR FROM REP_SECTORES A INNER JOIN REP_DISTRIBxSECTOR B ON A.ID=B.SECTOR INNER JOIN REP_PERIODO_DISTRIB C ON C.ID=B.PERIODO " + _
                "WHERE C.ACCION='OUT' AND C.DISTRIB=" + id_distrib.ToString
        _tabla = maestro.ejecuta(_consulta)
        Return New sector_table(_tabla, sector_table.display.full)
    End Function
    Public Function PERIODO_ENTRADA_DIS(ByVal id_distrib As Integer) As periodo_dis_table
        _consulta = "SELECT ID,DISTRIB,ACCION,DESDE,HASTA FROM REP_PERIODO_DISTRIB WHERE ACCION='IN' AND DISTRIB=" + id_distrib.ToString
        _tabla = maestro.ejecuta(_consulta)
        Return New periodo_dis_table(_tabla)
    End Function
    Public Function SECTORES_ENTRADA(ByVal id_periodo As Integer) As sector_table
        _consulta = "SELECT B.ID,B.DEPTO,B.LUGAR,B.NOMBRE_DEPTO,B.NOMBRE_LUGAR," + _
            "A.ID[DISTRIBxSECTOR],A.VALOR,A.PERIODO FROM REP_DISTRIBxSECTOR A " + _
            "RIGHT JOIN REP_SECTORES B ON A.SECTOR=B.ID WHERE PERIODO=" + id_periodo.ToString + _
            " UNION ALL SELECT B.ID,B.DEPTO,B.LUGAR,B.NOMBRE_DEPTO,B.NOMBRE_LUGAR,0[DISTRIBxSECTOR],0[VALOR]," + id_periodo.ToString + "[PERIODO] FROM REP_SECTORES B " + _
            "WHERE B.ID NOT IN(SELECT SECTOR FROM REP_DISTRIBxSECTOR WHERE PERIODO=" + id_periodo.ToString + ") ORDER BY 2,3"
        _tabla = maestro.ejecuta(_consulta)
        Return New sector_table(_tabla, sector_table.display.full)
    End Function
    Public Function SECTORES_ENTRADA() As sector_table
        Return SECTORES_ENTRADA(0)
    End Function

    Public Function NEW_SECTOR_SALIDA(ByVal sector As Integer, ByVal distribucion As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_SECTOR_DIS_salida " + distribucion.ToString + "," + sector.ToString
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 0 Then
                Return Nothing
            Else
                Return resultado.Rows(0)
            End If
        End If
    End Function
    Public Function DROP_SECTOR_SALIDA(ByVal sector As Integer, ByVal distribucion As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_SECTOR_DIS_salida " + distribucion.ToString + "," + sector.ToString
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 0 Then
                Return Nothing
            Else
                Return resultado.Rows(0)
            End If
        End If
    End Function

    Public Function NEW_PERIODO_ENTRADA(ByVal id_distribucion As Integer, ByVal desde As DateTime, ByVal hasta As DateTime) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_PERIODO_DIS_entrada " + id_distribucion.ToString + ",'" + desde.ToString("yyyyMMdd") + "','" + hasta.ToString("yyyyMMdd") + "'"
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 0 Then
                Return Nothing
            Else
                Return resultado.Rows(0)
            End If
        End If
    End Function
    Public Function MOD_PERIODO_ENTRADA(ByVal id_periodo As Integer, ByVal desde As DateTime, ByVal hasta As DateTime) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_PERIODO_DIS_entrada " + id_periodo.ToString + ",'" + desde.ToString("yyyyMMdd") + "','" + hasta.ToString("yyyyMMdd") + "'"
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 0 Then
                Return Nothing
            Else
                Return resultado.Rows(0)
            End If
        End If
    End Function

    ''' <summary>
    ''' Esta funcion realiza tanto INSERT, UPDATE o DELETE, segun la información ingresada
    ''' </summary>
    ''' <param name="periodo"></param>
    ''' <param name="sector"></param>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ACTUALIZA_SECTOR_DISTRIB(ByVal periodo As Integer, ByVal sector As Integer, ByVal valor As Double) As dt_query_result.myRow
        _consulta = "EXEC REP_ACT_SECTOR_DISTRIB " + periodo.ToString + "," + sector.ToString + "," + valor.ToString("0.000")
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 0 Then
                Return Nothing
            Else
                Return resultado.Rows(0)
            End If
        End If
    End Function
#End Region

#Region "REP_VISTAS"
    Public Function VISTAS(ByVal id_reporte As Integer) As dt_vista
        _consulta = "SELECT ID,REPORTE,DISPLAY_NAME,SHORT_NAME FROM REP_VISTAS " + _
                "WHERE (REPORTE=" + id_reporte.ToString + " OR 0=" + id_reporte.ToString + ") " + _
                "AND DELETED=0 " + _
                "ORDER BY ORDEN"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_vista(_tabla)
    End Function
    Public Function VISTA(ByVal id_vista As Integer) As dt_vista.myRow
        Return VISTAS(0).FIND_by_ID(id_vista)
    End Function
    Public Function NEW_VISTA(ByVal id_reporte As Integer, ByVal descrip As String, ByVal corto As String) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_VISTA " + id_reporte.ToString + ",'" + descrip + "','" + corto + "'"
        Return consulta_cambio(_consulta)
    End Function
    Public Function MOD_VISTA(ByVal id_vista As Integer, ByVal descrip As String, ByVal corto As String) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_VISTA " + id_vista.ToString + ",'" + descrip + "','" + corto + "'"
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "REP_VISTAxPRESENT"
    Public Function NEW_VISTAxPRESENT(ByVal id_presentacion As Integer, ByVal id_vista As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_VISTAxPRESENT " + id_presentacion.ToString + "," + id_vista.ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function DROP_VISTAxPRESENT(ByVal id_presentacion As Integer, ByVal id_vista As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_VISTAxPRESENT " + id_presentacion.ToString + "," + id_vista.ToString
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "REP_COLUMNAS"
    Public Function COLUMNAS(ByVal id_vista As Integer) As dt_columnas
        _consulta = "SELECT ID,VISTA,COD,NOMBRE,ORDEN,TOTALIZA FROM REP_COLUMNAS " + _
                "WHERE VISTA=" + id_vista.ToString + " ORDER BY ORDEN"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_columnas(_tabla)
    End Function
    Public Function COLUMNAS(ByVal id_vista As Integer, ByVal off_columna As Integer) As dt_columnas
        _consulta = "SELECT ID,VISTA,COD,NOMBRE,ORDEN,TOTALIZA FROM REP_COLUMNAS " + _
                "WHERE VISTA=" + id_vista.ToString + " AND ID<>" + off_columna.ToString + " ORDER BY ORDEN"
        _tabla = maestro.ejecuta(_consulta)
        Return New dt_columnas(_tabla)
    End Function

    Public Function COLUMNA(ByVal id_columna As Integer) As dt_columnas.myRow
        Dim resultado As dt_columnas
        _consulta = "SELECT ID,VISTA,COD,NOMBRE,ORDEN,TOTALIZA FROM REP_COLUMNAS " + _
                "WHERE ID=" + id_columna.ToString
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            resultado = New dt_columnas(_tabla)
            If resultado.Rows.Count = 1 Then
                Return resultado.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function
    Public Function FIND_COLUMNA(ByVal descripcion As String) As dt_columnas.myRow
        Dim resultado As dt_columnas
        _consulta = "SELECT ID,VISTA,COD,NOMBRE,ORDEN,TOTALIZA FROM REP_COLUMNAS " + _
                "WHERE NOMBRE='" + descripcion + "'"
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            resultado = New dt_columnas(_tabla)
            If resultado.Rows.Count > 0 Then
                Return resultado.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Function NEW_COLUMNAS(ByVal id_vista As Integer, ByVal cod_columna As String, ByVal nombre_columna As String, ByVal totaliza As Boolean) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_COLUMNA " + id_vista.ToString + ",'" + cod_columna + "','" + nombre_columna + "'," + CInt(totaliza).ToString
        _tabla = maestro.ejecuta(_consulta)

        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Dim resultado As dt_query_result
            resultado = New dt_query_result(_tabla)
            If resultado.Rows.Count = 1 Then
                Return resultado.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function
    Public Function MOD_COLUMNAS(ByVal id_col As Integer, ByVal cod_columna As String, ByVal nombre_columna As String, ByVal orden As Integer, ByVal totaliza As Boolean) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_COLUMNA " + id_col.ToString + ",'" + cod_columna + "','" + nombre_columna + "'," + orden.ToString + "," + CInt(totaliza).ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function DROP_COLUMNAS(ByVal id_col As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_COLUMNA " + id_col.ToString
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "REP_REGLA_COLUMNA"
    Public Function REGLAS_COLUMNA(ByVal id_columna As Integer) As regla_columna_table
        _consulta = "SELECT ID,COLUMNA,TIPO,APLICAR,VALIDACION,TXT_APLICAR,TXT_TIPO,TXT_VALIDACION FROM VIS_REGLA_COLUMNA " + _
                "WHERE COLUMNA=" + id_columna.ToString
        _tabla = maestro.ejecuta(_consulta)
        Return New regla_columna_table(_tabla)
    End Function
    Public Function REGLA_COLUMNA(ByVal id_regla As Integer) As regla_columna_row
        Dim resultado As regla_columna_table
        _consulta = "SELECT ID,COLUMNA,TIPO,APLICAR,VALIDACION,TXT_APLICAR,TXT_TIPO,TXT_VALIDACION FROM VIS_REGLA_COLUMNA " + _
               "WHERE id=" + id_regla.ToString
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            resultado = New regla_columna_table(_tabla)
            If resultado.Rows.Count = 1 Then
                Return resultado.Rows(0)
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Function NEW_REGLA_COL(ByVal id_columna As Integer, ByVal tipo As String, ByVal aplicar As String, ByVal validacion As String) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_REGLA_COL " + id_columna.ToString + ",'" + tipo + "','" + aplicar + "','" + validacion + "'"
        Return consulta_cambio(_consulta)
    End Function
    Public Function MOD_REGLA_COL(ByVal id_regla As Integer, ByVal tipo As String, ByVal aplicar As String, ByVal validacion As String) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_REGLA_COL " + id_regla.ToString + ",'" + tipo + "','" + aplicar + "','" + validacion + "'"
        Return consulta_cambio(_consulta)
    End Function
    Public Function DROP_REGLA_COL(ByVal id_regla As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_REGLA_COL " + id_regla.ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function DROP_REGLA_ALL(ByVal id_columna As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_REGLA_ALL " + id_columna.ToString
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "REP_REGLA_CLASIFICACION"
    Public Function REGLAS_CLASIFICACION(ByVal id_reporte As Integer) As regla_clasif_table
        _consulta = "SELECT A.ID,A.REPORTE,A.TIPO,(SELECT B.TXT FROM VAL_TIPO_CLASIF B WHERE B.COD=A.TIPO)[TXT_TIPO],A.VALIDACION,A.FILA,(SELECT B.DESCRIP FROM REP_FILAS_REPORTE B WHERE B.ID=A.FILA)[TXT_FILA] FROM REP_REGLA_CLASIFICACION A " + _
            "WHERE (A.REPORTE=" + id_reporte.ToString + ") OR (0=" + id_reporte.ToString + ") ORDER BY A.VALIDACION"
        _tabla = maestro.ejecuta(_consulta)
        If IsNothing(_tabla) Then
            Return Nothing
        Else
            Return New regla_clasif_table(_tabla)
        End If
    End Function
    Public Function REGLA_CLASIFICACION(ByVal id_regla As Integer) As regla_clasif_row
        Return REGLAS_CLASIFICACION(0).FIND_by_ID(id_regla)
    End Function

    Public Function NEW_REGLA_CLASIFICACION(ByVal id_reporte As Integer, ByVal tipo As String, ByVal validacion As String, ByVal id_fila As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_NEW_REGLA_CLASIFICACION " + id_reporte.ToString + ",'" + tipo + "','" + validacion + "'," + id_fila.ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function MOD_REGLA_CLASIFICACION(ByVal id_regla As Integer, ByVal tipo As String, ByVal validacion As String, ByVal id_fila As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_MOD_REGLA_CLASIFICACION " + id_regla.ToString + ",'" + tipo + "','" + validacion + "'," + id_fila.ToString
        Return consulta_cambio(_consulta)
    End Function
    Public Function DROP_REGLA_CLASIFICACION(ByVal id_regla As Integer) As dt_query_result.myRow
        _consulta = "EXEC REP_DROP_REGLA_CLASIFICACION " + id_regla.ToString
        Return consulta_cambio(_consulta)
    End Function
#End Region

#Region "VALORES BASE DATOS"
    Public Function VALOR_TIPO(ByVal TOTALIZA As Boolean) As DataTable
        _consulta = "SELECT COD,TXT FROM VAL_TIPO WHERE TOTALIZA=" + Math.Abs(CInt(TOTALIZA)).ToString
        _tabla = maestro.ejecuta(_consulta)
        Return _tabla
    End Function
    Public Function VALOR_APLICA(ByVal TOTALIZA As Boolean) As DataTable
        _consulta = "SELECT COD,TXT FROM VAL_APLICA WHERE TOTALIZA=" + Math.Abs(CInt(TOTALIZA)).ToString
        _tabla = maestro.ejecuta(_consulta)
        Return _tabla
    End Function
    Public Function VALOR_TIPO_CLAS(ByVal gasto As Boolean) As DataTable
        _consulta = "SELECT COD,TXT FROM VAL_TIPO_CLASIF " + IIf(gasto, "", "WHERE COD<>'EC'")
        _tabla = maestro.ejecuta(_consulta)
        Return _tabla
    End Function
    Public Function VALOR_PRESENTACION() As DataTable
        _consulta = "SELECT ID,DESCRIP,SOLO_ACUM FROM VAL_PRESENTACIONES"
        _tabla = maestro.ejecuta(_consulta)
        Return _tabla
    End Function
    Public Function VALOR_PRESENTACIONxVISTA(ByVal id_vista As Integer) As DataTable
        _consulta = "SELECT ID,DESCRIP,SOLO_ACUM FROM VAL_PRESENTACIONES " + _
            "WHERE ID IN(SELECT PRESENTACION FROM REP_VISTAxPRESENT WHERE VISTA=" + id_vista.ToString + ")"
        _tabla = maestro.ejecuta(_consulta)
        Return _tabla
    End Function
    Public Function presentacion_single(ByVal id_presentacion As Integer) As DataRow
        Dim sPresenta As DataRow()
        _tabla = VALOR_PRESENTACION()
        sPresenta = _tabla.Select("ID=" + id_presentacion.ToString)
        If sPresenta.Count > 0 Then
            Return sPresenta(0)
        Else
            Return Nothing
        End If
    End Function
#End Region
#End Region

End Class


