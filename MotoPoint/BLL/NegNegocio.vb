Imports BE
Imports DAL

Namespace SIS.BUSINESS
    Public Class NegNegocio
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Dim interfazNegocioBitacora As INegBitacora = New NegBitacora
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private unUsuarioField As BE.SIS.ENTIDAD.Usuario
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Function validarPrimeraConexion() As Boolean
            Dim isFirts As Boolean = False
            Dim oDalAuditoria As New DAL.SIS.DATOS.DALAuditoria
            Try
                Dim id = oDalAuditoria.primeraConexion()

                If id <> 0 Then
                    'DB ESTA CONFIGURADA
                    isFirts = True
                Else
                    'NO DB ESTA CONFIGURADA
                    isFirts = False
                End If
                Return isFirts
            Catch ex As Exception
                interfazNegocioBitacora.registrarEnBitacora_BLL("SYS_DB_CONN", ex)
                Return isFirts
            End Try
        End Function
    End Class
End Namespace
