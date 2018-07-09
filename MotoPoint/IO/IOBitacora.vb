Imports System.IO
Imports BE

Namespace SIS.ESCRITURA
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IOBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="oBitacora"></param>
        ''' <remarks></remarks>
        Public Sub registrarEnBitacoraIO(ByVal oBitacora As BE.SIS.ENTIDAD.Bitacora)
            Dim delimitador As String = ";"
            Dim ruta As String = "C:\MotoPoint\log.csv"
            Dim cabecera As String = "idEvento" + delimitador + "idUsuario" + delimitador + "descripcion" + delimitador + "fecha"
            Try
                Dim archivo As New StreamWriter(ruta, True)
                archivo.WriteLine(cabecera)
                Dim linea As String
                Dim idEvento As String = oBitacora.idEvento.ToString
                Dim idUsuario As String = oBitacora.idUsuario.ToString
                Dim descripcion As String = oBitacora.descripcion.ToString
                Dim fecha As String = oBitacora.fecha.ToString
                linea = idEvento + delimitador + idUsuario + delimitador _
                + descripcion + delimitador + fecha
                archivo.WriteLine(linea)
                archivo.Close()
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="errorTabla"></param>
        ''' <param name="errorColumna"></param>
        Public Sub registrarLogSystem(ByVal errorTabla As String, ByVal errorColumna As String)
            Dim delimitador As String = "|"
            Dim ruta As String = "C:\MotoPoint\log_System.txt"
            Try
                Dim archivo As New StreamWriter(ruta, True)
                Dim linea As String

                Dim ERROR_TABLA As String = errorTabla
                Dim ERROR_COLUMNA As String = errorColumna
                Dim ERROR_FECHA As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

                linea = "ERROR" + delimitador + ERROR_TABLA + delimitador + ERROR_COLUMNA + delimitador + "SE PRODUJO ERROR CRITICO" + delimitador + ERROR_FECHA
                archivo.WriteLine(linea)
                archivo.Close()
            Catch ex As Exception
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function leerLogSystem() As DataTable
            Dim ruta As String = "C:\MotoPoint\log_System.txt"
            Dim delimitador As String = "|"
            Dim header = False
            'New datatable
            Dim dt As New DataTable

            'Read the contents of the textfile into an array
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(ruta)
            Dim txtlines() As String = sr.ReadToEnd.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            'Return nothing if there's nothing in the textfile
            If txtlines.Count = 0 Then
                Return Nothing
            End If

            Dim column_count As Integer = 0
            For Each col As String In txtlines(0).Split({delimitador}, StringSplitOptions.None)
                If header Then
                    'If there's a header then add it by it's name
                    dt.Columns.Add(col)
                    dt.Columns(column_count).Caption = col
                Else
                    'If there's no header then add it by the column count
                    Dim valorheader As String

                    Select Case column_count
                        Case 0
                            valorheader = "TIPO"
                        Case 1
                            valorheader = "TABLA"
                        Case 2
                            valorheader = "COLUMNA"
                        Case 3
                            valorheader = "GRAVEDAD"
                        Case 4
                            valorheader = "FECHA"
                    End Select

                    dt.Columns.Add(valorheader, GetType(String))
                    dt.Columns(column_count).Caption = valorheader
                End If
                column_count += 1
            Next
            header = True
            If header Then
                For rows As Integer = 1 To txtlines.Count - 1 'start at one because there's a header for the first line(0)
                    'Declare a new datarow
                    Dim dr As DataRow = dt.NewRow

                    'Set the column count back to 0, we can reuse this variable ;]
                    column_count = 0
                    For Each col As String In txtlines(rows).Split({delimitador}, StringSplitOptions.None) 'Each column in the row
                        'The column in cue is set for the datarow
                        dr(column_count) = col
                        column_count += 1
                    Next

                    'Add the row
                    dt.Rows.Add(dr)
                Next
            Else
                For rows As Integer = 0 To txtlines.Count - 1 'start at zero because there's no header
                    'Declare a new datarow
                    Dim dr As DataRow = dt.NewRow

                    'Set the column count back to 0, we can reuse this variable ;]
                    column_count = 0
                    For Each col As String In txtlines(rows).Split({delimitador}, StringSplitOptions.None) 'Each column in the row
                        'The column in cue is set for the datarow
                        dr(column_count) = col
                        column_count += 1
                    Next

                    'Add the row
                    dt.Rows.Add(dr)
                Next
            End If
            Return dt
        End Function
    End Class
End Namespace
