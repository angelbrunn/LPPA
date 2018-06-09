Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Common
Imports BE
Imports EL

Namespace SIS.DATOS
    ''' <summary>
    ''' 
    ''' </summary>
    Public Class DALAuditoria
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function primeraConexion() As Integer
            Dim id As Integer

            Dim conexString As String = System.Configuration.ConfigurationManager.ConnectionStrings("MotoPoint").ConnectionString
            Dim sqlQuery As String = "SELECT id FROM tbl_Auditoria WHERE entidad='IS_CONFIG'"

            Dim conex As New SqlConnection
            conex.ConnectionString = conexString

            Dim comando As SqlCommand = conex.CreateCommand
            comando.CommandType = CommandType.Text
            comando.CommandText = sqlQuery

            Try
                conex.Open()
                id = comando.ExecuteScalar
                conex.Close()

            Catch ex As SqlException
                Throw New EL.SIS.EXCEPCIONES.DALExcepcion(ex.Message)
            End Try
            Return id
        End Function
    End Class
End Namespace

